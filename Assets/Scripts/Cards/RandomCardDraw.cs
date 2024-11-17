using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class RandomCardDraw : MonoBehaviour
{
    [LabelText("攻擊卡片Prefab")]
    public GameObject damageCardPrefab;

    [LabelText("補血卡片Prefab")]
    public GameObject healCardPrefab;

    [LabelText("生成卡片數量")]
    public int numberOfCardsToGenerate = 20;

    // 定義卡片池
    public List<Card> cardPool = new List<Card>();

    // 定義兩個玩家
    public GameObject player1;
    public GameObject player2;

    void Start()
    {
        /*GenerateRandomCards(numberOfCardsToGenerate);
       // Card[] foundCards = FindObjectsOfType<Card>();
        //cardPool.AddRange(foundCards);
        // 抽卡並分配給玩家
        AssignCardsToPlayer(player1, 4);
        AssignCardsToPlayer(player2, 4);*/
    }
    /// <summary>
    /// 生成卡片
    /// </summary>
    void GenerateRandomCards(int numberOfCards)
    {
        for (int i = 0; i < numberOfCards; i++)
        {
            int cardType = Random.Range(0, 2); // 0 或 1

            GameObject newCardObj;
            if (cardType == 0)
            {
                // 生成傷害卡片
                newCardObj = Instantiate(damageCardPrefab);
            }
            else
            {
                // 生成回復卡片
                newCardObj = Instantiate(healCardPrefab);
            }
            Card newCard = newCardObj.GetComponent<Card>();
            if (newCard != null)
            {

            }
            cardPool.Add(newCard); // 添加到卡片池
        }
    }
    void AssignCardsToPlayer(GameObject player, int numberOfCards)
    {
        // 使用 List 來儲存抽出的結果
        List<Card> drawnCards = new List<Card>();

        for (int i = 0; i < numberOfCards; i++)
        {
            // 從卡片池中隨機選取一張卡
            int randomIndex = Random.Range(0, cardPool.Count);
            drawnCards.Add(cardPool[randomIndex]);

            // 選取後從卡片池中移除以避免重複抽到
            cardPool.RemoveAt(randomIndex);
        }

        // 如果需要，將卡片分配給玩家（例如添加到玩家的卡片清單或子物件中）
        foreach (Card card in drawnCards)
        {
            // 將卡片設為該玩家的子物件
            card.transform.parent = player.transform;
        }
    }
}
