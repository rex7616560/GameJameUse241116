using UnityEngine;

public class Card : MonoBehaviour
{
    public enum CardType { Damage, Heal }

    public CardType cardType;  // �d�P�����G�ˮ`�Φ^�_
    public int value;          // �ˮ`�Φ^�_���ƭ�
    private PlayerHealth playerHealth;  // ���a��q�޲z

    void Start()
    {
        // ���է�쪱�a�� PlayerHealth �ե�
        playerHealth = GameObject.Find("Player").GetComponent<PlayerHealth>();
    }

    // ��d�P�Q�I����Ĳ�o���ƥ�
    public void OnCardClicked()
    {
        if (playerHealth != null)
        {
            if (cardType == CardType.Damage)
            {
                playerHealth.TakeDamage(value);  // �ˮ`�d�A��֦�q
            }
            else if (cardType == CardType.Heal)
            {
                playerHealth.Heal(value);  // �^�_�d�A�W�[��q
            }
        }
    }
}
