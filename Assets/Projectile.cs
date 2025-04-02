using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    public float Speed = 10f;
    public Cooldown Lifetime;

   
    private Rigidbody2D _rigidbody;

    private DamageONTouch _damageOnTouch;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();

        _rigidbody.AddRelativeForce(new Vector2(0, Speed));
        _damageOnTouch = GetComponent<DamageONTouch>();

        if (_damageOnTouch != null)
           _damageOnTouch.OnHit += Die;

        Lifetime.StartCooldown();


    }

    // Update is called once per frame
    void Update()
    {
        if (Lifetime.CurrentProgress != Cooldown.Progress.Finished)
            return;
        Die();


    }
    void Die()
    {
        if (_damageOnTouch != null)
            _damageOnTouch.OnHit -= Die;

        Lifetime.StopCooldown();
        Destroy(gameObject);
    }

}
