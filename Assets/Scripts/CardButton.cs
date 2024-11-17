using UnityEngine;
using UnityEngine.UI;

public class CardButton : MonoBehaviour
{
    public CardInfo cardInfo;  // �d�����
    public Button cardButton;  // ���s����
    public Image cardImage;    // ���s�W���Ϥ�
    public PlayerHealth playerHealth; // ��e���a����q����
    public PlayerHealth targetPlayerHealth; // �ؼЪ��a����q����

    void Start()
    {
        // �]�m���s���Ϥ����d�����Ϥ�
        if (cardInfo != null && cardImage != null)
        {
            cardImage.sprite = cardInfo.cardSprite; // ���] CardInfo ���� cardSprite
        }

        // ���U���s�I���ƥ�
        if (cardButton != null)
        {
            cardButton.onClick.AddListener(OnCardClicked);
        }
    }

    // ��d�����s�Q�I���ɡAĲ�o�������ĪG
    void OnCardClicked()
    {
        if (cardInfo.cardType == CardType.Attack)
        {
            // �����d�A��ؼЪ��a�y���ˮ`
            targetPlayerHealth.TakeDamage(cardInfo.CardValue);
        }
        else if (cardInfo.cardType == CardType.Heal)
        {
            // �v���d�A��_�ۤv����q
            playerHealth.Heal(cardInfo.CardValue);
        }
        else
        {
            Debug.Log("�o�i�d�S���S��ĪG");
        }

        // �I����T�Ϋ��s�A����ƨϥ�
        cardButton.interactable = false;
    }
}
