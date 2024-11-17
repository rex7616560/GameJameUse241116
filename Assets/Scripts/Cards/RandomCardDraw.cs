using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Sirenix.OdinInspector;

public class RandomCardDraw : MonoBehaviour
{
    [LabelText("卡片 Prefabs")]
    public List<GameObject> cardPrefabs = new List<GameObject>();

    [LabelText("生成卡片數量")]
    public int numberOfCardsToGenerate = 20;

    [LabelText("生成卡片位置")]
    public GameObject cardPoolObject;

    [LabelText("玩家1")]
    public GameObject player1;

    [LabelText("玩家2")]
    public GameObject player2;

    [LabelText("目前卡池")]
    public List<Card> cardPool = new List<Card>();

    [LabelText("玩家1遊戲格子")]
    public List<Image> player1CardImages = new List<Image>(); // 玩家1的卡片顯示格子

    [LabelText("玩家2遊戲格子")]
    public List<Image> player2CardImages = new List<Image>(); // 玩家2的卡片顯示格子

    [LabelText("玩家1按鈕")]
    public List<Button> player1CardButtons = new List<Button>(); // 玩家1的卡片按鈕

    [LabelText("玩家2按鈕")]
    public List<Button> player2CardButtons = new List<Button>(); // 玩家2的卡片按鈕

    // 新增：玩家的 PlayerHealth
    public PlayerHealth player1Health;
    public PlayerHealth player2Health;

    void Start()
    {
        GenerateRandomCards(numberOfCardsToGenerate);

        // 抽卡並分配給玩家
        AssignCardsToPlayer(player1, player1CardImages, player1CardButtons, player1Health, player2Health);
        AssignCardsToPlayer(player2, player2CardImages, player2CardButtons, player2Health, player1Health);
    }

    /// <summary>
    /// 生成卡片
    /// </summary>
    void GenerateRandomCards(int numberOfCards)
    {
        for (int i = 0; i < numberOfCards; i++)
        {
            int cardIndex = Random.Range(0, cardPrefabs.Count);
            GameObject newCardObj = Instantiate(cardPrefabs[cardIndex], cardPoolObject.transform);

            Card newCard = newCardObj.GetComponent<Card>();
            if (newCard != null)
            {
                cardPool.Add(newCard);
            }
        }
    }

    /// <summary>
    /// 分配卡片給玩家，並更新 UI
    /// </summary>
    void AssignCardsToPlayer(GameObject player, List<Image> uiImages, List<Button> buttons, PlayerHealth playerHealth, PlayerHealth targetPlayerHealth)
    {
        int numberOfCards = uiImages.Count; // 根據 UI 格子的數量來決定分配的卡片數量

        List<Card> drawnCards = new List<Card>();

        int availableCards = Mathf.Min(numberOfCards, cardPool.Count);

        for (int i = 0; i < availableCards; i++)
        {
            int randomIndex = Random.Range(0, cardPool.Count);
            Card selectedCard = cardPool[randomIndex];

            drawnCards.Add(selectedCard);

            // 從 cardPool 中移除選中的卡片
            cardPool.RemoveAt(randomIndex);

            // 清理無效的卡片
            CleanUpCardPool();
        }

        // 更新玩家的 UI
        UpdatePlayerCardUI(drawnCards, uiImages, buttons, playerHealth, targetPlayerHealth);
    }

    /// <summary>
    /// 更新玩家的卡片 UI，並設置按鈕事件
    /// </summary>
    void UpdatePlayerCardUI(List<Card> cards, List<Image> uiImages, List<Button> buttons, PlayerHealth playerHealth, PlayerHealth targetPlayerHealth)
    {
        for (int i = 0; i < uiImages.Count; i++)
        {
            if (i < cards.Count)
            {
                Card card = cards[i];

                // 設置卡片圖片
                Sprite cardSprite = card.GetComponent<SpriteRenderer>().sprite;
                uiImages[i].sprite = cardSprite;

                // 確保按鈕可用
                buttons[i].interactable = true;

                // 添加 CardButton 腳本到按鈕，並設置卡片資料
                CardButton cardButton = buttons[i].GetComponent<CardButton>();
                if (cardButton == null)
                {
                    cardButton = buttons[i].gameObject.AddComponent<CardButton>();
                }

                // 設置 CardButton 的資料
                cardButton.cardInfo = card.cardInfo;
                cardButton.cardButton = buttons[i];
                cardButton.cardImage = uiImages[i];
                cardButton.playerHealth = playerHealth;
                cardButton.targetPlayerHealth = targetPlayerHealth;
            }
            else
            {
                // 如果沒有卡片，設置為不可用
                uiImages[i].sprite = null;
                buttons[i].interactable = false;
            }
        }
    }

    /// <summary>
    /// 清理卡片池中的無效卡片
    /// </summary>
    void CleanUpCardPool()
    {
        for (int i = cardPool.Count - 1; i >= 0; i--)
        {
            if (cardPool[i] == null)
            {
                cardPool.RemoveAt(i);
            }
        }
    }
}
