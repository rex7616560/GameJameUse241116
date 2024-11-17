using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider healthSlider; // Slider 元件
    public PlayerHealth player; // 引用玩家腳本

    void Start()
    {
        if (player != null && healthSlider != null)
        {
            // 初始化血條
            healthSlider.maxValue = player.maxHealth; // 設定最大值
            healthSlider.value = player.currentHealth; // 設定初始值
        }
    }

    void Update()
    {
        if (player != null && healthSlider != null)
        {
            // 每幀更新血條
            healthSlider.value = player.currentHealth;
        }
    }
}
