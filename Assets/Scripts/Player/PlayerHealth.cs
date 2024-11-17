using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;      // 最大血量
    public int currentHealth;        // 當前血量
    public Slider healthSlider;      // 連結到 UI 的血條 Slider

    void Start()
    {
        currentHealth = maxHealth;  // 初始化血量
        UpdateHealthUI();  // 初始更新血條顯示
    }

    // 減少血量的方法
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth < 0) currentHealth = 0;
        UpdateHealthUI();  // 更新血條
    }

    // 增加血量的方法
    public void Heal(int healAmount)
    {
        currentHealth += healAmount;
        if (currentHealth > maxHealth) currentHealth = maxHealth;
        UpdateHealthUI();  // 更新血條
    }

    // 更新血條顯示的方法
    private void UpdateHealthUI()
    {
        if (healthSlider != null)
        {
            healthSlider.value = (float)currentHealth / maxHealth;  // 更新 UI 顯示比例
        }
    }
}
