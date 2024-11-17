using UnityEngine;

public class Card : MonoBehaviour
{
    public CardInfo cardInfo;  // 卡片資料 (指向 CardInfo 實例)

    // 這是玩家1的血量管理 (你也可以做成指向對方玩家的方式)
    public PlayerHealth targetPlayerHealth; // 對應的玩家血量物件

    // 當卡片被使用時
    public void UseCard()
    {
        if (cardInfo.cardType == CardType.Attack)
        {
            // 這張卡是攻擊卡，對對方造成傷害
            targetPlayerHealth.TakeDamage(cardInfo.CardValue);
        }
        else if (cardInfo.cardType == CardType.Heal)
        {
            // 這張卡是治療卡，恢復玩家血量
            targetPlayerHealth.Heal(cardInfo.CardValue);
        }
        else
        {
            Debug.Log("這張卡沒有特殊效果");
        }
    }
}
