using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Sirenix.OdinInspector;

public class GameManager : MonoBehaviour
{
    public RandomCardDraw randomCardDraw;
    public float timerDuration = 60f; // �]�w�p�ɮɶ� (��)
    private float remainingTime;
    public GameObject GameState;

    //public TextMeshProUGUI timerText; // �ϥ� TextMeshPro ��
    public Text timerText; // �p�G�Ϊ��O���q Text�A�����W�誺��ñҥγo��

    //public Camera mainCamera; // �D��v��
    //public Transform cardBattleCameraPosition; // �d�P�԰���������v����m�]�b�������]�m�n�Ū����ܡ^
    public GameObject platformCanvas; // Platform �� Canvas
    public GameObject cardBattleCanvas;

    private bool timerRunning = true;

    void Start()
    {
        Time.timeScale = 0f;
        // ��l�ƭp�ɾ�
        remainingTime = timerDuration;
        UpdateTimerDisplay();

        platformCanvas.SetActive(true);
        cardBattleCanvas.SetActive(false);
        GameStart();
    }

    void Update()
    {
        if (timerRunning)
        {
            // �˭p��
            remainingTime -= Time.deltaTime;

            // ��s�e���W���ɶ�
            UpdateTimerDisplay();

            // �ˬd�O�_�ɶ���
            if (remainingTime <= 0)
            {
                EndBattleTimer();
            }
        }
    }
    [Button("�}�l�C��")]
    void GameStart()
    {
        Time.timeScale = 1f;
    }
    void UpdateTimerDisplay()
    {
        // �N�Ѿl�ɶ��榡�Ƭ� mm:ss �����
        int seconds = Mathf.FloorToInt(remainingTime % 60f);
        timerText.text = string.Format("{00}", seconds);
    }

    void EndBattleTimer()
    {
        timerRunning = false;
        remainingTime = 0;
        UpdateTimerDisplay();
        //randomCardDraw.Turn();

        // ��������ʧ@�]�Ҧp�T�α���}���^
        //StopPlayersActions();

        // ������v�������שM��m
        //SwitchToCardBattleView();
        platformCanvas.SetActive(false);
        cardBattleCanvas.SetActive(true);
        GameState.SetActive(false);
        SwitchCanvas();
    }
    [Button("�^�h2D�C��")]
    void GoBack2D()
    {
        platformCanvas.SetActive(true);
        cardBattleCanvas.SetActive(false);
        GameState.SetActive(true);
    }
    void SwitchCanvas()
    {
        platformCanvas.SetActive(false); // ���� Platform Canvas
        cardBattleCanvas.SetActive(true); // �}�� CardBattle Canvas

        Debug.Log("������d�P�԰� Canvas");
    }
    /*void SwitchToCardBattleView()
    {
        if (mainCamera != null && cardBattleCameraPosition != null)
        {
            // ������v������m�M����
            mainCamera.transform.position = cardBattleCameraPosition.position;
            mainCamera.transform.rotation = cardBattleCameraPosition.rotation;

            Debug.Log("��v���w������d�P�԰�����");
        }
        else
        {
            Debug.LogWarning("���]�m��v���Υd�P�԰���������v����m");
        }
    }*/
}
