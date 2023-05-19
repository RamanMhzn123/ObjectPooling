using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance; //Manager

    public static T getInstance() 
    {

        if (instance==null)
        {
            instance = FindObjectOfType<T>();  
        }
        else if (instance != FindObjectOfType<T>())
        {
            Destroy(FindAnyObjectByType<T>()); //destroy duplicate 
        }
        DontDestroyOnLoad(instance);
        return instance;   
    }
}