using UnityEngine;
using UnityEngine.UI;

public class BattleSlot : MonoBehaviour
{
    public Button attackButton => GetComponent<Button>();

    private void Start()
    {
        attackButton.onClick.AddListener(StartFight);
    }

    public void StartFight()
    {
        var playerDamage = Player.Instance.Attack();

        if(ValidDamage(playerDamage))
        {
            Enemy.Instance.GetDamage(playerDamage);
            Player.Instance.GetDamage(Enemy.Instance.Attack());
        }
    }

    private bool ValidDamage(DamageWay damageWay)
    {
        if (damageWay.damage <=0)
        {
            return false;
        }

        return true;
    }

}
