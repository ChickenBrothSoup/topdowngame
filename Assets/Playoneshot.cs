using UnityEngine;

public class Playoneshot : MonoBehaviour
{
    public AudioClip Audioclip;

    public float LifeTime = 1f;

    private AudioSource _audiosource;

    private float _timer = 0f;







    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _audiosource = GetComponent<AudioSource>();

        if (_audiosource && Audioclip && !_audiosource.isPlaying)
        {
            _audiosource.PlayOneShot(Audioclip);
        }
    }

   
}
