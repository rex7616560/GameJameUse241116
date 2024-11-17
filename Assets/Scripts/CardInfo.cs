using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using Unity.VisualScripting;


[CreateAssetMenu(fileName = "CardInfo", menuName = "Item/CardInfo")]
public class CardInfo : ScriptableObject
{
    [LabelText("�d�P�W��")]
    public string CardName;
    [LabelText("�d�P����")]
    public CardType cardType;
    [LabelText("��")]
    public int CardValue;
    [LabelText("���S���S��ĪG?")]
    public bool isCardHaveEffect;
    [ShowIf("isCardHaveEffect")]
    [LabelText("�ĪG�W��(�ȭ��^��)")]
    public string CardEffect;
    [LabelText("��r�ԭz")]
    [TextArea]
    public string CardEffectText;
 
}
public enum CardType
{
    [LabelText("����")]
    Attack,
    [LabelText("�ɦ�")]
    Heal,
    [LabelText("���m")]
    Defend,
    [LabelText("�ĪG")]
    Effect,
    None
}

