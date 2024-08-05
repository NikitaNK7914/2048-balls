using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barrel : PassiveItem
{
    [SerializeField] GameObject dieEffect;
    ItemType type = ItemType.Barrel;
    public override void Affect()
    {
        base.Affect();
        Instantiate(dieEffect, transform.position, Quaternion.Euler(-90f,0,0));
        ScoreManager.instance.AddScore(type, transform.position);
        Destroy(gameObject);
    }
}
