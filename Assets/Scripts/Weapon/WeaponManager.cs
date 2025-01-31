using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [SerializeField] private Weapon lightGun, heavyGun;
    private Weapon currentWeapon;

   

    private void Start()
    {
        lightGun.onClickButton.onClick.AddListener(()=>ChangeWeapon(lightGun));
        heavyGun.onClickButton.onClick.AddListener(() => ChangeWeapon(heavyGun));
    }

    public void ChangeWeapon(Weapon newWeapon)
    {
        if (currentWeapon != null)
        {
            if(newWeapon != currentWeapon)
            currentWeapon.DeActivate();
        }
        currentWeapon = newWeapon;
        currentWeapon.Activate();
    }

    public float Shoot()
    {
        if (currentWeapon != null)
        {
            int requiredBullets = currentWeapon.useBulletsPerAttack;

            if (InventoryManager.Instance.UseBullets(currentWeapon.bulletsType, requiredBullets))
            {
                Debug.Log("Выстрел с оружия: " + currentWeapon.name);
                return currentWeapon.GetShoot(requiredBullets);
            }
            else
            {
                Debug.Log("Недостаточно патронов!");
            }
        }
        return 0;
    }
}
