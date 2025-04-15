using NUnit.Framework.Constraints;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform target;      
    public float smoothSpeed = 0.125f; 
    public Vector3 offset;

    public AudioClip Alert;
    private AudioSource sound;


    void PlayMusic()
    {
        if (sound != null && Alert != null)
        {
            sound.PlayOneShot(Alert);
        }
      
    }

    private void Start()
    {
        sound = GetComponent<AudioSource>();
        PlayMusic();
    }
    void Update()
    {
        if (target == null)
            return;

        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        transform.position = new Vector3(smoothedPosition.x, smoothedPosition.y, transform.position.z);
    }

   
}
