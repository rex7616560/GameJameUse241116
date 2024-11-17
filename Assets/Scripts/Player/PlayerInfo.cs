using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[CreateAssetMenu(fileName = "PlayerInfo", menuName = "Player/PlayerInfo")]
public class PlayerInfo : ScriptableObject
{
    public string playerName;   // ª±®a¦WºÙ
    public int CardCount;
    public List<Card> cards;
    public Sprite Head;
    public Sprite Body;
    public Sprite Leg;
}
