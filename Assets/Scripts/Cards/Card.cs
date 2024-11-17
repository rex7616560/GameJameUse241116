using UnityEngine;

public class Card : MonoBehaviour
{
    public enum CardType { Damage, Heal }

    public CardType cardType;  // 卡牌類型：傷害或回復
    public int value;          // 傷害或回復的數值
    private PlayerHealth playerHealth;  // 玩家血量管理

    void Start()
    {
        // 嘗試找到玩家的 PlayerHealth 組件
        playerHealth = GameObject.Find("Player").GetComponent<PlayerHealth>();
    }

    // 當卡牌被點擊時觸發的事件
    public void OnCardClicked()
    {
        if (playerHealth != null)
        {
            if (cardType == CardType.Damage)
            {
                playerHealth.TakeDamage(value);  // 傷害卡，減少血量
            }
            else if (cardType == CardType.Heal)
            {
                playerHealth.Heal(value);  // 回復卡，增加血量
            }
        }
    }
}
