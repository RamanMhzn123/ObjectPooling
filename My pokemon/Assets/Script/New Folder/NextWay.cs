using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class NextWay : MonoBehaviour
{
    public int[] numbers = new int[5];
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0, j = numbers.Length; i < numbers.Length; i++, j--)
        {
            Debug.Log("i: " + i + ", j: " + j + ", number: " + numbers[i]);
        }
    }
}
