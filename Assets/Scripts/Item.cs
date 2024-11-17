using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public enum ItemType
    {
        Head,
        Body,
        Leg,
    }
    public ItemType itemType;
    public Sprite itemSprite;
    private void Start()
    {
        itemSprite=gameObject.GetComponent<Sprite>();
    }
}
