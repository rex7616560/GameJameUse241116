using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider healthSlider; // Slider ����
    public PlayerHealth player; // �ޥΪ��a�}��

    void Start()
    {
        if (player != null && healthSlider != null)
        {
            // ��l�Ʀ��
            healthSlider.maxValue = player.maxHealth; // �]�w�̤j��
            healthSlider.value = player.currentHealth; // �]�w��l��
        }
    }

    void Update()
    {
        if (player != null && healthSlider != null)
        {
            // �C�V��s���
            healthSlider.value = player.currentHealth;
        }
    }
}
