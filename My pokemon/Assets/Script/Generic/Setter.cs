using UnityEngine;

public abstract class Setter<T> : MonoBehaviour where T : Setter<T> //must be setter class or sub class
{
    private static T instance;

    protected virtual void Awake() //singleton code
    {
        if (instance != null)
        {
            Destroy(this);
            return;
        }
        instance = this as T; //instance = T
        DontDestroyOnLoad(gameObject);

        Debug.Log("Setter Awake");
    }
}
