using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class ball : ActiveItem
{
    
    [SerializeField] private Transform visualTransform;
    [SerializeField] public Renderer _renderer;
    [SerializeField] private ballSettings ballSettings;
    ItemType type=ItemType.Ball;


    public override void SetLevel(int level)
    {
        Level = level;
        int number=(int)Mathf.Pow(2, level+1);
        text.text = number.ToString();

        Radius = Mathf.Lerp(0.4f, 0.7f, level / 10f);
        Vector3 ballScale = Vector3.one * Radius * 2f;
        visualTransform.localScale = ballScale;
        _collider.radius=Radius;
        trigger.radius=Radius+0.1f;

        _renderer.material = ballSettings.ballMaterials[level];
        if(level == 7)
        {
            ScoreManager.instance.AddScore(type, transform.position);
        }
    }
    public void increaseLevel()
    {
        Level += 1;
        SetLevel(Level);
        trigger.enabled = false;
        trigger.enabled = true;
    }
    public void SetToTube()
    {
        trigger.enabled = false;
        _collider.enabled = false;
        _rigidbody.isKinematic = true;
        _rigidbody.interpolation = RigidbodyInterpolation.None;
    }
    public void Drop()
    {
        trigger.enabled = true;
        _collider.enabled=true;
        _rigidbody.isKinematic=false;
        _rigidbody.interpolation = RigidbodyInterpolation.Interpolate;
        transform.parent = null;
        _rigidbody.velocity = Vector3.down * 1.5f;
    }

    private void AffectPassiveItems(Vector3 position, float radius)
    {
        Collider[] colliders = Physics.OverlapSphere(position, radius);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].attachedRigidbody)
            {
                PassiveItem passiveItem = colliders[i].attachedRigidbody.GetComponent<PassiveItem>();
                if (passiveItem)
                {
                    passiveItem.Affect();
                }

            }
        }
    }
    public override void DoEffect()
    {
        increaseLevel();
        AffectPassiveItems(transform.position,Radius+0.1f);
        base.DoEffect();
    }


    
    
    
}
