using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class box : PassiveItem
{
    public int health;
    [SerializeField] private GameObject[] levels;
    [SerializeField] private GameObject dieEffectPrefab;
    [SerializeField] private Animator animator;
    ItemType type=ItemType.Box;

    public override void Affect()
    {
        base.Affect();
        health -= 1;
        Instantiate(dieEffectPrefab,transform.position,Quaternion.identity);
        animator.SetTrigger("shake");
        if (health < 0)
        {
            Die();
        }
        else
        {
            SetLevel(health);
        }
    }
    private void SetLevel(int level)
    {
        for(int i = 0; i < levels.Length; i++)
        {
            if (i <= level)
            {
                levels[i].SetActive(true);
            }
            else
            {
                levels[i].SetActive(false);
            }
        }
    }
    private void Die()
    {
        ScoreManager.instance.AddScore(type,transform.position);
        Destroy(gameObject);
    }
    
}
