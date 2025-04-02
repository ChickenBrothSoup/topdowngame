using System.Collections;
using UnityEngine;

public class TEstCoroutine : MonoBehaviour
{
    public float Duration = 1f;
    private float _currentDuration;

   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine("DoCoroutine");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator DoCoroutine()
    {
        _currentDuration = Duration;
        Debug.Log("Start");
        while (_currentDuration > 0)
        {
            _currentDuration -= Time.deltaTime;
            Debug.Log(_currentDuration);
            yield return null;
        }
            
        yield return null;
    }
}
