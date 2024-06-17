using UnityEngine;

public class turnRight : MonoBehaviour
{
    public Vector3 FinalPosition;

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("car"))
            other.GetComponent<carController>().FinalPosition = FinalPosition;
    }
}
