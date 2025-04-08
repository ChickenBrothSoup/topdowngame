using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100f;
    private float currentHealth;

    private bool isInvulnerable = false;
    private float invulnerabilityDuration = 1.5f;
    private float invulnerabilityTimer = 0f;

    public AudioClip deathSound;
    private AudioSource sound;

    void Start()
    {
        currentHealth = maxHealth;
        sound = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (isInvulnerable)
        {
            invulnerabilityTimer -= Time.deltaTime;
            if (invulnerabilityTimer <= 0f)
            {
                isInvulnerable = false;
            }
        }
    }

    public void TakeDamage(float damage)
    {
        if (isInvulnerable) return;

        currentHealth -= damage;
        Debug.Log("Player took damage: " + damage + ", HP left: " + currentHealth);

        isInvulnerable = true;
        invulnerabilityTimer = invulnerabilityDuration;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        foreach (Renderer renderer in GetComponentsInChildren<Renderer>())
        {
            renderer.enabled = false;
        }

        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.simulated = false;
        }

        PlayDeathSoundEffect();

        // Destroy object after sound plays
        Destroy(gameObject, deathSound.length);
    }

    void PlayDeathSoundEffect()
    {
        if (sound != null && deathSound != null)
        {
            sound.PlayOneShot(deathSound);
        }
    }

}
