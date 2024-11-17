using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class RandomCardDraw : MonoBehaviour
{
    [LabelText("�����d��Prefab")]
    public GameObject damageCardPrefab;

    [LabelText("�ɦ�d��Prefab")]
    public GameObject healCardPrefab;

    [LabelText("�ͦ��d���ƶq")]
    public int numberOfCardsToGenerate = 20;

    // �w�q�d����
    public List<Card> cardPool = new List<Card>();

    // �w�q��Ӫ��a
    public GameObject player1;
    public GameObject player2;

    void Start()
    {
        /*GenerateRandomCards(numberOfCardsToGenerate);
       // Card[] foundCards = FindObjectsOfType<Card>();
        //cardPool.AddRange(foundCards);
        // ��d�ä��t�����a
        AssignCardsToPlayer(player1, 4);
        AssignCardsToPlayer(player2, 4);*/
    }
    /// <summary>
    /// �ͦ��d��
    /// </summary>
    void GenerateRandomCards(int numberOfCards)
    {
        for (int i = 0; i < numberOfCards; i++)
        {
            int cardType = Random.Range(0, 2); // 0 �� 1

            GameObject newCardObj;
            if (cardType == 0)
            {
                // �ͦ��ˮ`�d��
                newCardObj = Instantiate(damageCardPrefab);
            }
            else
            {
                // �ͦ��^�_�d��
                newCardObj = Instantiate(healCardPrefab);
            }
            Card newCard = newCardObj.GetComponent<Card>();
            if (newCard != null)
            {

            }
            cardPool.Add(newCard); // �K�[��d����
        }
    }
    void AssignCardsToPlayer(GameObject player, int numberOfCards)
    {
        // �ϥ� List ���x�s��X�����G
        List<Card> drawnCards = new List<Card>();

        for (int i = 0; i < numberOfCards; i++)
        {
            // �q�d�������H������@�i�d
            int randomIndex = Random.Range(0, cardPool.Count);
            drawnCards.Add(cardPool[randomIndex]);

            // �����q�d�����������H�קK���Ʃ��
            cardPool.RemoveAt(randomIndex);
        }

        // �p�G�ݭn�A�N�d�����t�����a�]�Ҧp�K�[�쪱�a���d���M��Τl���󤤡^
        foreach (Card card in drawnCards)
        {
            // �N�d���]���Ӫ��a���l����
            card.transform.parent = player.transform;
        }
    }
}
