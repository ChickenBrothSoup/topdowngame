using UnityEngine;

public class WeaponPickUp : PickUp
{
    public GameObject Weapon;

    public LayerMask PlayerLayerMask; 

    protected override void PickedUp(Collider2D col)
    {
        if (Weapon == null)
        {
            Debug.LogWarning("Missing Weapon");
            return;
        }

       
        if (((1 << col.gameObject.layer) & PlayerLayerMask) != 0)
        {
          
            WeaponHandler weaponHandler = col.GetComponent<WeaponHandler>();

            if (weaponHandler == null)
                return;

            weaponHandler.EquipWeapon(Weapon);

            Destroy(gameObject); //destroy weapon once equip
        }
        else
        {
            
            Debug.Log("Enemy attempted to pick up the weapon, but cannot.");
        }
    }
}
