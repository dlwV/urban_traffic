using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class traffic_signal_controller : MonoBehaviour
{
    public GameObject _light;
    private Light lightComponent;

    public InputField redTimeInput;
    public InputField greenTimeInput;
    public InputField yellowTimeInput;
    public Button applyButton;

    private float redTime = 10, yellowTime = 5, greenTime = 5;


    private void Awake()
    {
        lightComponent = _light.GetComponent<Light>();
        applyButton.onClick.AddListener(UpdateTrafficLightTimings);
    }

    void UpdateTrafficLightTimings()
    {
        redTime = float.Parse(redTimeInput.text);
        greenTime = float.Parse(greenTimeInput.text);
        yellowTime = float.Parse(yellowTimeInput.text);

        StartCoroutine(TrafficLightControlSwitch(redTime, greenTime, yellowTime));
    }
    void Start()
    {
        StartCoroutine(TrafficLightControl(redTime, greenTime, yellowTime));
    }

    IEnumerator TrafficLightControl(float redTime, float greenTime, float yellowTime)
    {
        while (true)
        {
            if (_light.tag == "traffic_light_vertical")
            {
                lightComponent.color = Color.red;
                yield return new WaitForSeconds(redTime);
                lightComponent.color = Color.green;
                yield return new WaitForSeconds(greenTime);
                lightComponent.color = Color.yellow;
                yield return new WaitForSeconds(yellowTime);
            }

            if (_light.tag == "traffic_light_horizontal")
            {
                lightComponent.color = Color.green;
                yield return new WaitForSeconds(greenTime);
                lightComponent.color = Color.yellow;
                yield return new WaitForSeconds(yellowTime);
                lightComponent.color = Color.red;
                yield return new WaitForSeconds(redTime);
            }
        }
    }

    IEnumerator TrafficLightControlSwitch(float redTime, float greenTime, float yellowTime)
    {
        if (_light.tag == "traffic_light_vertical")
        {
            lightComponent.color = Color.red;
            yield return new WaitForSeconds(3);
            lightComponent.color = Color.green;
            yield return new WaitForSeconds(0);
            lightComponent.color = Color.yellow;
            yield return new WaitForSeconds(0);
        }

        if (_light.tag == "traffic_light_horizontal")
        {
            lightComponent.color = Color.green;
            yield return new WaitForSeconds(0);
            lightComponent.color = Color.yellow;
            yield return new WaitForSeconds(0);
            lightComponent.color = Color.red;
            yield return new WaitForSeconds(3);
        }
        StartCoroutine(TrafficLightControl(redTime, greenTime, yellowTime));
    }

}
