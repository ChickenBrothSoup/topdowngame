using UnityEngine;

public class CoroutineHost : MonoBehaviour
{
    public static CoroutineHost Instance
    {
        get
        {
            if(m_Instance == null)
            {
                //returns existsing instance
                m_Instance = (CoroutineHost)FindAnyObjectByType<CoroutineHost>();
                if(m_Instance == null)
                {
                    GameObject go = new GameObject();
                    {
                        go.name = "CoroutineHost";
                        m_Instance = go.AddComponent<CoroutineHost>();
                    }
                    DontDestroyOnLoad(m_Instance.gameObject);
                }
            }
            return m_Instance;
        }
    }

    public static CoroutineHost m_Instance = null;






    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
