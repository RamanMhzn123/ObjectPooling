using UnityEngine;
using UnityEngine.Pool;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject gameObject;
    private ObjectPool<GameObject> pool; 

    void Start() 
    {
        pool = new ObjectPool<GameObject>(CreateObject, OnTakeObjectFromPool, OnReturnBulletToPool, OnDestroyObject,
                                    false, 10, 20); //checks dont return that has slready been return

        InvokeRepeating("Spawn", 0.2f, 0.2f);
    }   
    
    private GameObject CreateObject() //createFunc = tells pool what to do if no object in pool
    {
        //create new instance of cube
        return Instantiate(gameObject); ;
    }

    private void OnTakeObjectFromPool(GameObject gameObject)//actionOnGet
    {
        gameObject.gameObject.SetActive(true);
        gameObject.transform.position = transform.position + Random.insideUnitSphere * 10;
    }

    private void OnReturnBulletToPool(GameObject GameObject)//actionOnRelease
    {
        GameObject.gameObject.SetActive(false);
    }

    private void OnDestroyObject(GameObject gameObject) //destroy object if out of pool
    {
        Destroy(gameObject.gameObject);
    }

    /*public void Spawn()
    {
        for(int i = 0; i < 5; i++)
        {
            var cube = pool.Get();
            cube.SetPool(KillShape);
        }

    }

    private void KillShape(Cube cube)
    {
        pool.Release(cube);
    }*/
}
