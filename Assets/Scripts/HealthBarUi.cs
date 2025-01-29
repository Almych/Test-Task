using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarUi : MonoBehaviour
{
    public Image fillHealth;
    public TMP_Text healthText;

    public void ChangeValue(float health, float maxHealth)
    {
        fillHealth.fillAmount = health / maxHealth;
        healthText.text = health.ToString();
    }
}
