using UnityEngine;
using UnityEngine.WSA;

public class ShapeSpawner : MonoBehaviour
{
    public PoolManager poolManager;

    public GameObject bootPrefabs;
    public GameObject glovePrefabs;

    public GameObject fireBullet;
    public GameObject iceBullet;

    public void OnClick()
    {
        poolManager.OnGetFromPool(bootPrefabs, transform.position, transform.rotation);

        /*  var obj = Instantiate(fireBullet,Vector3.back,Quaternion.identity);
          obj.GetComponent<Launcher>().Launch();

          var objj2 = PoolManager.GetFromPool(fireBullet, Vector2.zero, Quaternion.identity);
          objj2.GetComponent<Launcher>().Launch(); //1 or many
  */
    }
}