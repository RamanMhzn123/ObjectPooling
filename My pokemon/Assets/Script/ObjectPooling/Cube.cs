using UnityEngine;

public class Cube : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            gameObject.SetActive(false); //also put inside the collection 
            //inactiveObjectQueue.Enqueue(objectToSpawn);//PoolManager onRelease
        }
    }
}
