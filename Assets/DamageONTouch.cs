using Unity.VisualScripting;
using UnityEngine;

public class DamageONTouch : MonoBehaviour
{

    // radio signal code thing like
    public delegate void OnHitSomething();
    public OnHitSomething OnHit;

    public float MinDamage = 1f;

    public float MaxDamage = 5f;
    
    public float PushForce = 10f;

   


    public LayerMask TargetLayerMask;
    public LayerMask IgnoreLayerMask;

    private void OnTriggerEnter2D(Collider2D col) 
    {
        if(((IgnoreLayerMask.value&(1 << col.gameObject.layer))>0))
                return;

        if (((TargetLayerMask.value & (1 << col.gameObject.layer)) > 0))
            HitDamagable(col);
        else
            HitAnything(col);
        
    }

    private void HitAnything(Collider2D col)
    {
        Rigidbody2D targetRigidbody = col.gameObject.GetComponent<Rigidbody2D>();

        if (targetRigidbody != null)
        {
            targetRigidbody.AddForce((col.transform.position - transform.position).normalized * PushForce);
        }

        OnHit?.Invoke();
    }

    private void HitDamagable(Collider2D col)
    {

        Health targetHealth = col.gameObject.GetComponent<Health>();

        if (targetHealth == null)
            return;

        Rigidbody2D targetRigidbody = col.gameObject.GetComponent<Rigidbody2D>();

        if(targetRigidbody != null)
        {
            targetRigidbody.AddForce((col.transform.position - transform.position).normalized*PushForce);
        }

        TryDamage(targetHealth);
    }
    private void TryDamage(Health targetHealth)
    {
        float damageAmount = Random.Range(MinDamage, MaxDamage);
        targetHealth.Damage(damageAmount, transform.gameObject);
        OnHit?.Invoke();
        

    }

   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
