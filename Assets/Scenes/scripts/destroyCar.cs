using UnityEngine;

public class destroyCar : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("car"))
        {
            GameObject carObject = other.gameObject;
            Destroy(carObject);
        }
    }
}
