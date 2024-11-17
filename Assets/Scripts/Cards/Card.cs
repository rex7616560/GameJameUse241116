using UnityEngine;
using Sirenix.OdinInspector;

public class Card : MonoBehaviour
{
    [LabelText("�d�����")]
    public CardInfo CardInfo;
    [LabelText("�d�P�W��")]
    [ReadOnly]
    public string CardName;
    [ReadOnly]
    public int value;
    [LabelText("�d�P����")]
    [ReadOnly]
    public CardType cardType;  // ��ܥd�P������
    private PlayerHealth playerHealth;  // ���a��q�޲z

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

    // ��d�P�Q�I����Ĳ�o���ƥ�
    public void OnCardClicked()
    {
        /*if (playerHealth != null)
        {
            if (cardType == CardType.Damage)
            {
                playerHealth.TakeDamage(value);  // �ˮ`�d�A��֦�q
            }
            else if (cardType == CardType.Heal)
            {
                playerHealth.Heal(value);  // �^�_�d�A�W�[��q
            }
        }*/
        Destroy(this.gameObject);
    }
}
