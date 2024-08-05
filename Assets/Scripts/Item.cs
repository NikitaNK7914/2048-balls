using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ItemType
{
    None,
    Ball,
    Box,
    Stone,
    Barrel,
    Dynamite

}
public class Item : MonoBehaviour
{
    public ItemType ItemType;
}
