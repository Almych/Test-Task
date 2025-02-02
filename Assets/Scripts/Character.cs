using UnityEngine;

public abstract class Character : MonoBehaviour, IAttackHandler, IDeathHandler, IGetDamageHandler
{
    public abstract void Init();
    public abstract DamageWay Attack();

    public abstract void Death();

    public abstract void GetDamage(DamageWay damageWay);
}
