using UnityEngine;
[CreateAssetMenu(fileName = "new HealthData", menuName = "HealthData")]
public class HealthData : ScriptableObject
{
    public float maxHealth = 100f;
    public float currentHealth = 0;
}
