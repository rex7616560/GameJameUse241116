using UnityEngine;

public class Card : MonoBehaviour
{
    public CardInfo cardInfo;  // �d����� (���V CardInfo ���)

    // �o�O���a1����q�޲z (�A�]�i�H�������V��誱�a���覡)
    public PlayerHealth targetPlayerHealth; // ���������a��q����

    // ��d���Q�ϥή�
    public void UseCard()
    {
        if (cardInfo.cardType == CardType.Attack)
        {
            // �o�i�d�O�����d�A����y���ˮ`
            targetPlayerHealth.TakeDamage(cardInfo.CardValue);
        }
        else if (cardInfo.cardType == CardType.Heal)
        {
            // �o�i�d�O�v���d�A��_���a��q
            targetPlayerHealth.Heal(cardInfo.CardValue);
        }
        else
        {
            Debug.Log("�o�i�d�S���S��ĪG");
        }
    }
}
