using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    private Weapon currentWeapon;
    

    public void ChangeWeapon(Weapon newWeapon)
    {
        if (currentWeapon != null)
        {
            if(newWeapon != currentWeapon)
            {
                currentWeapon.DeActivate();
                currentWeapon = newWeapon;
                currentWeapon.Activate();
            }
        }
        else
        {
            currentWeapon = newWeapon;
            currentWeapon.Activate();
        }
    }

    public float Shoot()
    {
        if (currentWeapon != null)
        {
            int requiredBullets = currentWeapon.useBulletsPerAttack;

            if (InventoryManager.Instance.UseBullets(currentWeapon.bulletsType, requiredBullets))
            {
                return currentWeapon.GetDamage();
            }
            else
            {
                Debug.Log("There is no ammos!");
            }
        }
        else
        {
            Debug.Log("Choose weapon to shoot!");
        }
        return 0;
    }
}
