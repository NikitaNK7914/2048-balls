using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ActiveItem : Item
{
    [SerializeField] protected TextMeshProUGUI text;
    [SerializeField] protected SphereCollider _collider;
    [SerializeField] protected SphereCollider trigger;
    [SerializeField] protected Rigidbody _rigidbody;
    public int Level;
    public float Radius;
    protected collapseManager collapseManager;
    public bool active = true;
    protected float createTime = 0;

    public virtual void SetLevel(int level)
    {
        Level = level;
        int num=(int)Mathf.Pow(2, level+1);
        text.text = num.ToString();
    }
    private void OnTriggerEnter(Collider other)
    {

        if (active)
        {
            if (other.attachedRigidbody)
            {
                if (other.attachedRigidbody.GetComponent<ActiveItem>() is ActiveItem otherBall)
                {
                    if (otherBall.Level == Level && otherBall.active)
                    {
                        collapseManager.Collapse(this, otherBall);
                    }
                }
            }
        }
    }
    public virtual void DoEffect() { }
    public void Deactivate()
    {
        active = false;
        trigger.enabled = false;
        _collider.enabled = false;
        _rigidbody.velocity = Vector3.zero;
        _rigidbody.isKinematic = true;
        _rigidbody.interpolation = RigidbodyInterpolation.None;
    }
    public void Init(collapseManager collapseManager)
    {
        this.collapseManager = collapseManager;
        active = true;
    }
    public float GetCurrentLifeTime()
    {
        return Time.time - createTime;
    }
    private void Start()
    {
        createTime = Time.time;
    }
}
