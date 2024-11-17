using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeItem : MonoBehaviour
{
    public GameObject head;  // 產繷场 GameObject
    public GameObject body;  // 產ō砰 GameObject
    public GameObject leg;   // 產籐场 GameObject
    private void EquipItem(Item item)
    {
        SpriteRenderer itemSpriteRenderer = item.GetComponent<SpriteRenderer>();

        switch (item.itemType)
        {
            case Item.ItemType.Head:
                head.GetComponent<SpriteRenderer>().sprite = itemSpriteRenderer.sprite;  // 穝繷场瓜
                break;
            case Item.ItemType.Body:
                body.GetComponent<SpriteRenderer>().sprite = itemSpriteRenderer.sprite;  // 穝ō砰瓜
                break;
            case Item.ItemType.Leg:
                leg.GetComponent<SpriteRenderer>().sprite = itemSpriteRenderer.sprite;  // 穝籐场瓜
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Item item = other.GetComponent<Item>();

        if (item != null)
        {
            // 具珇穝杆称
            EquipItem(item);
            Debug.Log("Player picked up " + item.itemType);

            // 具綪反珇
            Destroy(other.gameObject);
        }
    }
}
