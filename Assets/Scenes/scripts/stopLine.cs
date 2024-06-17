using UnityEngine;

public class stopLine : MonoBehaviour
{
    public GameObject traffic_light;
    private Light traffic_light_color;
    void Awake()
    {
        traffic_light_color = traffic_light.GetComponent<Light>();
    }
    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("car") && traffic_light_color.color != Color.green)
        {
            other.GetComponent<carController>().trafficLightGreen = false;
        }
        else if (other.CompareTag("car") && traffic_light_color.color == Color.green)
        {
            if (other.GetComponent<carController>().carAhead == false)
            {
                other.GetComponent<carController>().trafficLightGreen = true;
            }
        }
    }
}
