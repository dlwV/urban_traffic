using System;
using UnityEngine;

public class turnLeft : MonoBehaviour
{
    public Vector3 FinalPosition;
    public GameObject oncomingSide;
    [NonSerialized] public int carCount;

    private void Update()
    {
        carCount = oncomingSide.GetComponent<oncomingTraffic>().carCount;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("car"))
        {
            if (other.GetComponent<carController>().turn_left)
            {
                other.GetComponent<carController>().FinalPosition = FinalPosition;
                other.GetComponent<carController>().turn_left = false;
            }
        }
    }
}
