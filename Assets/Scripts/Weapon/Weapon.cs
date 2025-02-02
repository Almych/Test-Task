using UnityEngine;
using UnityEngine.UI;

public class Weapon : MonoBehaviour
{
    public float damage;
    public BulletsType bulletsType;
    public int useBulletsPerAttack;
    public Button onClickButton => GetComponent<Button>();
    private Outline outline => GetComponent<Outline>();
    public float GetDamage()
    {
        return damage;
    }

    public void Activate()
    {
        outline.effectColor = Color.green;
    }

    public void DeActivate()
    {
        outline.effectColor = Color.white;
    }
}
