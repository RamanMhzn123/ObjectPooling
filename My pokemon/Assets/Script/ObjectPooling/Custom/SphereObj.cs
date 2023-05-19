using UnityEngine;

public class SphereObj : MonoBehaviour
{
    public float speed = 2;

    private void Update()
    {
        transform.Translate(speed* Time.deltaTime, 0, 0);
    }
}
