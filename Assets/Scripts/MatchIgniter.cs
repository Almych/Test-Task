using UnityEngine;

public class MatchIgniter : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        BurnerFlame flame = other.GetComponent<BurnerFlame>();
        if (flame != null)
        {
            flame.TryIgnite();
        }
    }
}
