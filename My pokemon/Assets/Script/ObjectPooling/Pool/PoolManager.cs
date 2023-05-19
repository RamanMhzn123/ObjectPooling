using UnityEngine;
using System.Collections.Generic;

public class PoolManager : MonoBehaviour
{

    public Queue<GameObject> inactiveObjectQueue = new Queue<GameObject>();

    public void OnGetFromPool(GameObject objectPrefab, Vector3 position, Quaternion rotation)
    {
        // Create objects and add them to the queue only if the queue is empty
        //Will run at first only
        if (inactiveObjectQueue.Count == 0)
        {
            for (int i = 0; i < 5; i++)
            {
                GameObject objectToPool = Instantiate(objectPrefab);
                objectToPool.SetActive(false);
                inactiveObjectQueue.Enqueue(objectToPool);
            }
        }

        // Dequeue objects from the pool and set their position/rotation
        for (int i = 0; i < 5; i++)
        {
            GameObject objectToSpawn = inactiveObjectQueue.Dequeue();
            objectToSpawn.SetActive(true);
            objectToSpawn.transform.position = position;
            objectToSpawn.transform.rotation = rotation;
            inactiveObjectQueue.Enqueue(objectToSpawn); // Add the object back to the queue for reuse
        }
    }
}