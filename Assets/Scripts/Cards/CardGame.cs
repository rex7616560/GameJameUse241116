using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PlayerController2D;

public class CardGame : MonoBehaviour
{
    public List<Card> cards = new List<Card>();
    public void GetCard()
    {
        Card[] cardsInChildren = gameObject.GetComponentsInChildren<Card>();
        cards = new List<Card>(cardsInChildren);
    }
    private void Update()
    {
        GetCard();
    }
}
