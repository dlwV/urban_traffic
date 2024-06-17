using System;
using UnityEngine;

public class oncomingTraffic : MonoBehaviour
{
    [NonSerialized] public int carCount = 0;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("car"))
        {
            carCount++;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("car"))
        {
            carCount--;
        }
    }
}
