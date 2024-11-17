using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BattleTimer : MonoBehaviour
{
    public float timerDuration = 60f; // �]�w�p�ɮɶ� (��)
    private float remainingTime;

    //public TextMeshProUGUI timerText; // �ϥ� TextMeshPro ��
    public Text timerText; // �p�G�Ϊ��O���q Text�A�����W�誺��ñҥγo��

    public Camera mainCamera; // �D��v��
    public Transform cardBattleCameraPosition; // �d�P�԰���������v����m�]�b�������]�m�n�Ū����ܡ^
    public GameObject platformCanvas; // Platform �� Canvas
    public GameObject cardBattleCanvas;

    private bool timerRunning = true;

    void Start()
    {
        // ��l�ƭp�ɾ�
        remainingTime = timerDuration;
        UpdateTimerDisplay();

        platformCanvas.SetActive(true);
        cardBattleCanvas.SetActive(false);
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

        // ��������ʧ@�]�Ҧp�T�α���}���^
        //StopPlayersActions();

        // ������v�������שM��m
        SwitchToCardBattleView();
        SwitchCanvas();
    }

    void SwitchCanvas()
    {
        platformCanvas.SetActive(false); // ���� Platform Canvas
        cardBattleCanvas.SetActive(true); // �}�� CardBattle Canvas

        Debug.Log("������d�P�԰� Canvas");
    }
    void SwitchToCardBattleView()
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
    }
}

