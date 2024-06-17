using UnityEngine;
using UnityEngine.UI;

public class AverageTime : MonoBehaviour
{
    private float totalTimeAtReducedSpeed = 0f, diferenceTotalTimeAtReducedSpeed = 0f;
    private int numberOfCars = 0;

    public InputField averageTimeInputField;
    public InputField diferenceAverageTimeInputField;

    public Button applyButton;

    private void Awake()
    {
        applyButton.onClick.AddListener(Rest);
    }

    void Update()
    {
        float averageTime = CalculateAverageTime();
        averageTimeInputField.text = averageTime.ToString("F2");
        if(diferenceTotalTimeAtReducedSpeed != 0f)
        {
            float dif = diferenceTotalTimeAtReducedSpeed - averageTime;
            if (dif < 0)
            {
                diferenceAverageTimeInputField.text = $"<color=red>{dif.ToString("F2")}</color>";
            }
            else if (dif > 0)
            {
                diferenceAverageTimeInputField.text = $"<color=green>{dif.ToString("F2")}</color>";
            }
        }
    }

    float CalculateAverageTime()
    {
        if (numberOfCars > 0)
        {
            return totalTimeAtReducedSpeed / numberOfCars;
        }
        else
        {
            return 0f; 
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("car")) numberOfCars++;
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("car")) totalTimeAtReducedSpeed += Time.deltaTime;
    }

    void Rest()
    {
        diferenceTotalTimeAtReducedSpeed = totalTimeAtReducedSpeed / numberOfCars;
        numberOfCars = 0;
        totalTimeAtReducedSpeed = 0;
    }
}
