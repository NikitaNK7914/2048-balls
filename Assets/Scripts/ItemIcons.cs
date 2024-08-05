using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemData
{
    public ItemType type;
    public Sprite image;
}
[CreateAssetMenu]
public class ItemIcons : ScriptableObject
{
    public ItemData[] itemData;
    public Sprite GetSprite(ItemType item)
    {
        for (int i = 0; i < itemData.Length; i++)
        {
            if (itemData[i].type == item)
            {
                return itemData[i].image;
            }
        }
        return null;
    }
}
