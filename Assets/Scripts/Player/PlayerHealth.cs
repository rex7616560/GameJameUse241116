using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100; // ���a�̤j��q
    public int currentHealth; // ���a��e��q

    void Start()
    {
        // ��l�Ʀ�q
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        // ������q
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth); // �T�O��q�b�d��
        Debug.Log($"���a����ˮ`�A��e��q�G{currentHealth}");
    }

    public void Heal(int amount)
    {
        // ��_��q
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth); // �T�O��q�b�d��
        Debug.Log($"���a��_�ͩR�A��e��q�G{currentHealth}");
    }
}