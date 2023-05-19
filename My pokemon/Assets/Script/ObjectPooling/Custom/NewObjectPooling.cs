using UnityEngine;
using System.Collections.Generic;

public class NewObjectPooling : MonoBehaviour
{
    public static NewObjectPooling instance;
    public GameObject poolObject;
    public int poolSize = 10;
    public bool willGrow;

    public List<GameObject> poolObjects;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        poolObjects= new List<GameObject>();

        for (int i = 0; i < poolSize; i++)
        {
            GameObject GO = (GameObject)Instantiate(poolObject);
            GO.SetActive(false);
            poolObjects.Add(GO);
        }
    }

    public GameObject GetPooledObject()
    {
        for(int i = 0; i < poolObjects.Count; i++)
        {
            if (!poolObjects[i].activeInHierarchy)
            {
                return poolObjects[i];
            }
        }

        if(willGrow)
        {
            GameObject newGO = (GameObject)Instantiate(poolObject);
            poolObjects.Add(newGO);
            return newGO;
        }

        return null;
    }
}
