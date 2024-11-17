using UnityEngine;
using UnityEngine.UI;

public class CardButton : MonoBehaviour
{
    public CardInfo cardInfo;  // 卡片資料
    public Button cardButton;  // 按鈕物件
    public Image cardImage;    // 按鈕上的圖片
    public PlayerHealth playerHealth; // 當前玩家的血量控制
    public PlayerHealth targetPlayerHealth; // 目標玩家的血量控制

    void Start()
    {
        // 設置按鈕的圖片為卡片的圖片
        if (cardInfo != null && cardImage != null)
        {
            cardImage.sprite = cardInfo.cardSprite; // 假設 CardInfo 中有 cardSprite
        }

        // 註冊按鈕點擊事件
        if (cardButton != null)
        {
            cardButton.onClick.AddListener(OnCardClicked);
        }
    }

    // 當卡片按鈕被點擊時，觸發對應的效果
    void OnCardClicked()
    {
        if (cardInfo.cardType == CardType.Attack)
        {
            // 攻擊卡，對目標玩家造成傷害
            targetPlayerHealth.TakeDamage(cardInfo.CardValue);
        }
        else if (cardInfo.cardType == CardType.Heal)
        {
            // 治療卡，恢復自己的血量
            playerHealth.Heal(cardInfo.CardValue);
        }
        else
        {
            Debug.Log("這張卡沒有特殊效果");
        }

        // 點擊後禁用按鈕，防止重複使用
        cardButton.interactable = false;
    }
}
