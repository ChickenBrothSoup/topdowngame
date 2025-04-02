using UnityEngine;

public class WeaponPickUp : PickUp
{
    public GameObject Weapon;

    protected override void PickedUp(Collider2D col)
    {

        if (Weapon == null)
        {
            Debug.LogWarning("Missing Weapon");
            return;
        }


        WeaponHandler weaponHandler = col.GetComponent<WeaponHandler>();

        if (weaponHandler == null)
            return;
        
        weaponHandler.EquipWeapon(Weapon);
    }


}
