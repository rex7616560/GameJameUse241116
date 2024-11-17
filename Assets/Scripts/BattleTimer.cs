using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BattleTimer : MonoBehaviour
{
    public float timerDuration = 60f; // 設定計時時間 (秒)
    private float remainingTime;

    //public TextMeshProUGUI timerText; // 使用 TextMeshPro 時
    public Text timerText; // 如果用的是普通 Text，取消上方的行並啟用這行

    public Camera mainCamera; // 主攝影機
    public Transform cardBattleCameraPosition; // 卡牌戰鬥場景的攝影機位置（在場景中設置好空物件表示）
    public GameObject platformCanvas; // Platform 的 Canvas
    public GameObject cardBattleCanvas;

    private bool timerRunning = true;

    void Start()
    {
        // 初始化計時器
        remainingTime = timerDuration;
        UpdateTimerDisplay();

        platformCanvas.SetActive(true);
        cardBattleCanvas.SetActive(false);
    }

    void Update()
    {
        if (timerRunning)
        {
            // 倒計時
            remainingTime -= Time.deltaTime;

            // 更新畫面上的時間
            UpdateTimerDisplay();

            // 檢查是否時間到
            if (remainingTime <= 0)
            {
                EndBattleTimer();
            }
        }
    }

    void UpdateTimerDisplay()
    {
        // 將剩餘時間格式化為 mm:ss 並顯示
        int seconds = Mathf.FloorToInt(remainingTime % 60f);
        timerText.text = string.Format("{00}", seconds);
    }

    void EndBattleTimer()
    {
        timerRunning = false;
        remainingTime = 0;
        UpdateTimerDisplay();

        // 停止雙方動作（例如禁用控制腳本）
        //StopPlayersActions();

        // 切換攝影機的角度和位置
        SwitchToCardBattleView();
        SwitchCanvas();
    }
    /*
    void StopPlayersActions()
    {
        // 停止玩家控制邏輯，根據你的玩家控制腳本實現：
        GameObject player1 = GameObject.Find("Player");
        GameObject player2 = GameObject.Find("Player2");
        platformUI.SetActive(false);
        cardUI.SetActive(true);        
        
         if (player1 != null)
        {
            player1.GetComponent<PlayerController2D>().enabled = false; // 禁用控制腳本
            Debug.Log("停止動作");
        }

        if (player2 != null)
        {
            player2.GetComponent<PlayerController2D>().enabled = false; // 禁用控制腳本
            Debug.Log("停止動作");
        }
        */

    void SwitchCanvas()
    {
        platformCanvas.SetActive(false); // 關閉 Platform Canvas
        cardBattleCanvas.SetActive(true); // 開啟 CardBattle Canvas

        Debug.Log("切換到卡牌戰鬥 Canvas");
    }
    void SwitchToCardBattleView()
    {
        if (mainCamera != null && cardBattleCameraPosition != null)
        {
            // 切換攝影機的位置和角度
            mainCamera.transform.position = cardBattleCameraPosition.position;
            mainCamera.transform.rotation = cardBattleCameraPosition.rotation;

            Debug.Log("攝影機已切換到卡牌戰鬥視角");
        }
        else
        {
            Debug.LogWarning("未設置攝影機或卡牌戰鬥場景的攝影機位置");
        }
    }
}

