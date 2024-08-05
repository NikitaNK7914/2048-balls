using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dynamite : ActiveItem
{
    [SerializeField]private float AffectRadius;
    [SerializeField] private float ForceValue;
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject AffectArea;
    [SerializeField] private GameObject explodePrefab;

    private void Start()
    {
       AffectArea.SetActive(false);
       SetLevel(Level);
    }
    private IEnumerator AffectProcess()
    {
        AffectArea.SetActive(true);
        animator.enabled = true;
        yield return new WaitForSeconds(2f);

        Collider[] colliders = Physics.OverlapSphere(transform.position, AffectRadius);
        foreach (Collider collider in colliders)
        {
            Rigidbody body = collider.attachedRigidbody;
            if(body) { 
                Vector3 to=(body.transform.position - transform.position).normalized;
                body.AddForce(to*ForceValue+Vector3.up*ForceValue*0.5f);
                PassiveItem passiveItem=body.GetComponent<PassiveItem>();
                if(passiveItem) {
                    passiveItem.Affect();
                }
            }
        }
        Instantiate(explodePrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
    public override void DoEffect()
    {
        base.DoEffect();
        StartCoroutine(AffectProcess());
    }
}
