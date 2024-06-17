using UnityEngine;

public class turnLeft2 : MonoBehaviour
{
    public Vector3 FinalPosition;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("car"))
        {
            other.GetComponent<carController>().FinalPosition = FinalPosition;
        }
    }
}
