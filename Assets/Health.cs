using UnityEngine;

public class Health : MonoBehaviour
{

    public float MaxHealth = 10f;
    private float _currentHealth = 10f;

    public AudioClip Dying;
    private AudioSource sound;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _currentHealth = MaxHealth;
        sound = GetComponent<AudioSource>();    
    }

    private void Initialization()
    {
        _currentHealth = MaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Damage(float damage, GameObject source)
    {
        _currentHealth -= damage;

        if (_currentHealth <= 0)
        {
            _currentHealth = 0;
            Die();
        }
    }
    public void Die()
    {
        if (Dying != null) //this creates a temporary gameobject so it can play a sound after death of the crying
        {
            GameObject soundObject = new GameObject(); 
            AudioSource tempSource = soundObject.AddComponent<AudioSource>();
            tempSource.PlayOneShot(Dying);
            Destroy(soundObject, Dying.length);
        }

        Destroy(gameObject);
    }
}
