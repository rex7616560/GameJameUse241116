using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100; // 玩家最大血量
    public int currentHealth; // 玩家當前血量

    void Start()
    {
        // 初始化血量
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        // 扣除血量
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth); // 確保血量在範圍內
        Debug.Log($"玩家受到傷害，當前血量：{currentHealth}");
    }

    public void Heal(int amount)
    {
        // 恢復血量
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth); // 確保血量在範圍內
        Debug.Log($"玩家恢復生命，當前血量：{currentHealth}");
    }
}