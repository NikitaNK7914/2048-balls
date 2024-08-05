using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : PassiveItem
{
    [SerializeField] private GameObject dieEffect;
    [SerializeField] private Stone stonePrefab;
    [SerializeField] private int Level = 2;
    ItemType type=ItemType.Stone;
    public override void Affect()
    {
        base.Affect();
        if (Level > 0)
        {
            for (int i = 0; i < 2; i++)
            {
                CreateChildeStone(Level-1);
            }
            Die();
        }
        if(Level == 0)Die();
    }
    public void CreateChildeStone(int level) {
        Stone temp =Instantiate(stonePrefab, transform.position, Quaternion.identity);
        temp.SetLevel(level);

    }
    public void Die() {
        if (Level == 0)
        {
            ScoreManager.instance.AddScore(type,transform.position);
        }
        Destroy(gameObject);
    }
    public void SetLevel(int level)
    {
        Level = level;
        float scale = 1f;
        if (level == 2)
        {
            scale = 1f;
        }
        else if (level == 1)
        {
            scale = 0.7f;
        }
        else if (level == 0) { scale = 0.5f; }
        gameObject.transform.localScale = Vector3.one*scale;
    }
}
