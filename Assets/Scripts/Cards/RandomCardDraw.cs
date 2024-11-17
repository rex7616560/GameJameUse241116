using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Sirenix.OdinInspector;

public class RandomCardDraw : MonoBehaviour
{
    [LabelText("�d�� Prefabs")]
    public List<GameObject> cardPrefabs = new List<GameObject>();

    [LabelText("�ͦ��d���ƶq")]
    public int numberOfCardsToGenerate = 20;

    [LabelText("�ͦ��d����m")]
    public GameObject cardPoolObject;

    [LabelText("���a1")]
    public GameObject player1;

    [LabelText("���a2")]
    public GameObject player2;

    [LabelText("�ثe�d��")]
    public List<Card> cardPool = new List<Card>();

    [LabelText("���a1�C����l")]
    public List<Image> player1CardImages = new List<Image>(); // ���a1���d����ܮ�l

    [LabelText("���a2�C����l")]
    public List<Image> player2CardImages = new List<Image>(); // ���a2���d����ܮ�l

    [LabelText("���a1���s")]
    public List<Button> player1CardButtons = new List<Button>(); // ���a1���d�����s

    [LabelText("���a2���s")]
    public List<Button> player2CardButtons = new List<Button>(); // ���a2���d�����s

    // �s�W�G���a�� PlayerHealth
    public PlayerHealth player1Health;
    public PlayerHealth player2Health;

    void Start()
    {
        GenerateRandomCards(numberOfCardsToGenerate);

        // ��d�ä��t�����a
        AssignCardsToPlayer(player1, player1CardImages, player1CardButtons, player1Health, player2Health);
        AssignCardsToPlayer(player2, player2CardImages, player2CardButtons, player2Health, player1Health);
    }

    /// <summary>
    /// �ͦ��d��
    /// </summary>
    void GenerateRandomCards(int numberOfCards)
    {
        for (int i = 0; i < numberOfCards; i++)
        {
            int cardIndex = Random.Range(0, cardPrefabs.Count);
            GameObject newCardObj = Instantiate(cardPrefabs[cardIndex], cardPoolObject.transform);

            Card newCard = newCardObj.GetComponent<Card>();
            if (newCard != null)
            {
                cardPool.Add(newCard);
            }
        }
    }

    /// <summary>
    /// ���t�d�������a�A�ç�s UI
    /// </summary>
    void AssignCardsToPlayer(GameObject player, List<Image> uiImages, List<Button> buttons, PlayerHealth playerHealth, PlayerHealth targetPlayerHealth)
    {
        int numberOfCards = uiImages.Count; // �ھ� UI ��l���ƶq�ӨM�w���t���d���ƶq

        List<Card> drawnCards = new List<Card>();

        int availableCards = Mathf.Min(numberOfCards, cardPool.Count);

        for (int i = 0; i < availableCards; i++)
        {
            int randomIndex = Random.Range(0, cardPool.Count);
            Card selectedCard = cardPool[randomIndex];

            drawnCards.Add(selectedCard);

            // �q cardPool �������襤���d��
            cardPool.RemoveAt(randomIndex);

            // �M�z�L�Ī��d��
            CleanUpCardPool();
        }

        // ��s���a�� UI
        UpdatePlayerCardUI(drawnCards, uiImages, buttons, playerHealth, targetPlayerHealth);
    }

    /// <summary>
    /// ��s���a���d�� UI�A�ó]�m���s�ƥ�
    /// </summary>
    void UpdatePlayerCardUI(List<Card> cards, List<Image> uiImages, List<Button> buttons, PlayerHealth playerHealth, PlayerHealth targetPlayerHealth)
    {
        for (int i = 0; i < uiImages.Count; i++)
        {
            if (i < cards.Count)
            {
                Card card = cards[i];

                // �]�m�d���Ϥ�
                Sprite cardSprite = card.GetComponent<SpriteRenderer>().sprite;
                uiImages[i].sprite = cardSprite;

                // �T�O���s�i��
                buttons[i].interactable = true;

                // �K�[ CardButton �}������s�A�ó]�m�d�����
                CardButton cardButton = buttons[i].GetComponent<CardButton>();
                if (cardButton == null)
                {
                    cardButton = buttons[i].gameObject.AddComponent<CardButton>();
                }

                // �]�m CardButton �����
                cardButton.cardInfo = card.cardInfo;
                cardButton.cardButton = buttons[i];
                cardButton.cardImage = uiImages[i];
                cardButton.playerHealth = playerHealth;
                cardButton.targetPlayerHealth = targetPlayerHealth;
            }
            else
            {
                // �p�G�S���d���A�]�m�����i��
                uiImages[i].sprite = null;
                buttons[i].interactable = false;
            }
        }
    }

    /// <summary>
    /// �M�z�d���������L�ĥd��
    /// </summary>
    void CleanUpCardPool()
    {
        for (int i = cardPool.Count - 1; i >= 0; i--)
        {
            if (cardPool[i] == null)
            {
                cardPool.RemoveAt(i);
            }
        }
    }
}
