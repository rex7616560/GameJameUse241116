using UnityEngine;
using Sirenix.OdinInspector;

[CreateAssetMenu(fileName = "CardInfo", menuName = "Item/CardInfo")]
public class CardInfo : ScriptableObject
{
    [LabelText("卡牌名稱")]
    public string CardName;

    [LabelText("卡牌類型")]
    public CardType cardType;

    [LabelText("值")]
    public int CardValue;

    [LabelText("有沒有特殊效果?")]
    public bool isCardHaveEffect;

    [ShowIf("isCardHaveEffect")]
    [LabelText("效果名稱(僅限英文)")]
    public string CardEffect;

    [LabelText("文字敘述")]
    [TextArea]
    public string CardEffectText;

    [LabelText("卡牌圖片")]
    public Sprite cardSprite; // 新增：卡片的圖片
}

public enum CardType
{
    [LabelText("攻擊")]
    Attack,

    [LabelText("補血")]
    Heal,

    [LabelText("防禦")]
    Defend,

    [LabelText("效果")]
    Effect,

    None
}
