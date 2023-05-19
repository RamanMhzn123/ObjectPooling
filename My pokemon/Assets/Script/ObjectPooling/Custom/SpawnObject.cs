using UnityEngine;
using System.Collections.Generic;
using UnityEditor.EditorTools;

public class SpawnObject : MonoBehaviour
{
    [SerializeField] private GameObject glovesPrefab,bootPrefab;

    void Start()
    {
        InvokeRepeating("Spawn", 0.5f, 0.3f);
    }

    void Spawn()
    {
        GameObject obj = NewObjectPooling.instance.GetPooledObject();

        if (obj == null) return;
        
        obj.transform.position = transform.position;
        obj.transform.rotation = transform.rotation ;
        obj.SetActive(true);
    }

    void SpawnRandom()
    {
        /*var glove = PoolManager.GetFromPool(glovesPrefab);
        var boot = PoolManager.GetFromPool(bootPrefab);*/

    }
}
