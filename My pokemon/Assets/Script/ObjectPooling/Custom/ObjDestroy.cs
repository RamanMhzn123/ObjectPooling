using UnityEngine;

public class ObjDestroy : MonoBehaviour
{
    private void OnEnable()
    {
        Invoke("Destroy", 5f);
    }

    void Destroy()
    {
        gameObject.SetActive(false);
    }

    private void OnDisable() //stop from double inactivating gameobject
    {
        CancelInvoke();
    }
}
