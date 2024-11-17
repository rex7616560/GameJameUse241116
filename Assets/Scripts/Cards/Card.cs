using UnityEngine;
using Sirenix.OdinInspector;

public class Card : MonoBehaviour
{
    [LabelText("卡片資料")]
    public CardInfo CardInfo;
    [LabelText("卡牌名稱")]
    [ReadOnly]
    public string CardName;
    [ReadOnly]
    public int value;
    [LabelText("卡牌類型")]
    [ReadOnly]
    public CardType cardType;  // 顯示卡牌的類型
    private PlayerHealth playerHealth;  // 玩家血量管理

    void Start()
    {
        //playerHealth = GameObject.Find("Player1").GetComponent<PlayerHealth>();
        if(CardInfo != null)
        {
            CardName = CardInfo.CardName;
            value = CardInfo.CardValue;
            cardType = CardInfo.cardType;
        }
    }

    // 當卡牌被點擊時觸發的事件
    public void OnCardClicked()
    {
        /*if (playerHealth != null)
        {
            if (cardType == CardType.Damage)
            {
                playerHealth.TakeDamage(value);  // 傷害卡，減少血量
            }
            else if (cardType == CardType.Heal)
            {
                playerHealth.Heal(value);  // 回復卡，增加血量
            }
        }*/
        Destroy(this.gameObject);
    }
}
