using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;

public class UIreloadInidicator : MonoBehaviour
{

    private UnityEngine.UI.Image _reloadbar;

    private WeaponHandler playerWeaponHandler;




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _reloadbar = GetComponent<UnityEngine.UI.Image>();

        GameObject playerGO = GameObject.FindGameObjectWithTag("Player");

        if (playerGO == null)
            return;

        playerWeaponHandler = playerGO.GetComponent<WeaponHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerWeaponHandler == null)
            return;

        if (playerWeaponHandler.CurrentWeapon == null)
            return;

        if(playerWeaponHandler.CurrentWeapon.CurrentBulletCount > 0)
        {
            float currentBulletCount = playerWeaponHandler.CurrentWeapon.CurrentBulletCount;
            float maxBulletCount = playerWeaponHandler.CurrentWeapon.MaxBulletCount;

            float bulletLeftFill = currentBulletCount / maxBulletCount;


            if (_reloadbar != null)
            {
                _reloadbar.fillAmount = bulletLeftFill;
            }

           


           
        }
      
        if (playerWeaponHandler.CurrentWeapon.ReloadCooldown.IsOnCooldown)
        {
            

            float reloadFill = playerWeaponHandler.CurrentWeapon.ReloadCooldown.CurrentDuration / playerWeaponHandler.CurrentWeapon.ReloadCooldown.Duration;

            reloadFill -= 1;

            reloadFill *= -1;

            if ( _reloadbar != null)
            {
                _reloadbar.fillAmount = reloadFill;
            }
        }
    }
}
