using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class Weapon : MonoBehaviour
{

    public enum FireModes
    {
        Auto,
        SingleFire,
        BurstFire

    }


    public FireModes FireMode;
    public float spread = 0f;
    public int BurstFireAmount = 3;
    public float BurstFireInterval = 0.1f;
    public int ProjectileCount = 1;

    public GameObject Projectile;

    public GameObject[] Feedbacks;
    public GameObject[] ReloadFeedbacks;

    public Transform SpawnPos;
    public Cooldown ShootingInterval;

    private float _timer = 0f;
    private bool _canShoot = true;
    private bool _fireReset = true;

    public Cooldown ReloadCooldown;
    public int MaxBulletCOunt = 10;
    public int CurrentBulletCount
    {
        get { return currentBulletCount; }
    }
    protected int currentBulletCount = 10;


    void Start()
    {
        currentBulletCount = MaxBulletCOunt;
    }

    private void Update()
    {
        UpdateReloadCooldown();
        UpdateShootCooldown();
    }

    private void UpdateReloadCooldown()
    {
        if (ReloadCooldown.CurrentProgress != Cooldown.Progress.Finished)
            return;

        if (ReloadCooldown.CurrentProgress == Cooldown.Progress.Finished)
        {
            currentBulletCount = MaxBulletCOunt;
        }
        ReloadCooldown.CurrentProgress = Cooldown.Progress.Ready;
    }
    private void UpdateShootCooldown()
    {
        if (ShootingInterval.CurrentProgress != Cooldown.Progress.Finished)
            return;
        ShootingInterval.CurrentProgress = Cooldown.Progress.Ready;
    }

    public void Shoot()
    {
        if (Projectile == null)
        return;

        if (SpawnPos == null)
        return;

        if (ReloadCooldown.IsOnCooldown || ReloadCooldown.CurrentProgress != Cooldown.Progress.Ready)
        return;

        switch (FireMode)
        {
            case FireModes.Auto:
                {
                    AutoFireShoot();
                    break;
                }
            case FireModes.SingleFire:
                {
                    SingleFireShoot();
                    break;
                }
                case FireModes.BurstFire:
                {
                    BurstFireShoot();
                    break;
                }

        }

        void AutoFireShoot()
        {

            if(!_canShoot) return;

            if (ShootingInterval.CurrentProgress != Cooldown.Progress.Ready)
                return;

            ShootProjectile();

            currentBulletCount--;

            ShootingInterval.StartCooldown();

            if(currentBulletCount<=0&& !ReloadCooldown.IsOnCooldown)
            {
                ReloadCooldown.StartCooldown();
            }

            
            
        }
        void SingleFireShoot()
        {

        }
        void BurstFireShoot()
        {

        }
      
        
        void ShootProjectile()
        {
            Debug.Log("shoot");

            for (int i = 0; i < ProjectileCount; i++)
            {
                float randomRot = Random.Range(-spread, spread);

                GameObject.Instantiate(Projectile, SpawnPos.position, SpawnPos.rotation * Quaternion.Euler(0, 0, randomRot));
            }
        }

       
    }
    public void StopShoot()
    {
        if (FireMode == FireModes.Auto)
            return;

        _fireReset = true;
    }
}
