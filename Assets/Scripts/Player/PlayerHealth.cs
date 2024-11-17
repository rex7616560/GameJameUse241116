using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;      // �̤j��q
    public int currentHealth;        // ��e��q
    public Slider healthSlider;      // �s���� UI ����� Slider

    void Start()
    {
        currentHealth = maxHealth;  // ��l�Ʀ�q
        UpdateHealthUI();  // ��l��s������
    }

    // ��֦�q����k
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth < 0) currentHealth = 0;
        UpdateHealthUI();  // ��s���
    }

    // �W�[��q����k
    public void Heal(int healAmount)
    {
        currentHealth += healAmount;
        if (currentHealth > maxHealth) currentHealth = maxHealth;
        UpdateHealthUI();  // ��s���
    }

    // ��s�����ܪ���k
    private void UpdateHealthUI()
    {
        if (healthSlider != null)
        {
            healthSlider.value = (float)currentHealth / maxHealth;  // ��s UI ��ܤ��
        }
    }
}
