using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeItem : MonoBehaviour
{
    public GameObject head;  // ���a�Y���� GameObject
    public GameObject body;  // ���a���骺 GameObject
    public GameObject leg;   // ���a�L���� GameObject
    private void EquipItem(Item item)
    {
        SpriteRenderer itemSpriteRenderer = item.GetComponent<SpriteRenderer>();

        switch (item.itemType)
        {
            case Item.ItemType.Head:
                head.GetComponent<SpriteRenderer>().sprite = itemSpriteRenderer.sprite;  // ��s�Y�����Ϥ�
                break;
            case Item.ItemType.Body:
                body.GetComponent<SpriteRenderer>().sprite = itemSpriteRenderer.sprite;  // ��s���骺�Ϥ�
                break;
            case Item.ItemType.Leg:
                leg.GetComponent<SpriteRenderer>().sprite = itemSpriteRenderer.sprite;  // ��s�L�����Ϥ�
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Item item = other.GetComponent<Item>();

        if (item != null)
        {
            // �ߨ쪫�~���s�˳�
            EquipItem(item);
            Debug.Log("Player picked up " + item.itemType);

            // �ߨ���P�����~
            Destroy(other.gameObject);
        }
    }
}
