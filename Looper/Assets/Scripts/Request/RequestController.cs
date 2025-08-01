using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class RequestController : MonoBehaviour
{
    public Slider requestTimeSlider;
    private int requestTimeTotal;
    private int requestTimeCurrent;

    public TextMeshProUGUI requestEmailContents;

    private bool requestCompleted = false;


    private void incrementRequestTime()
    {
        requestTimeCurrent++;
        requestTimeSlider.value = requestTimeCurrent;
    }
    
    public void setRequestTime(int requestTime)
    {
        this.requestTimeTotal = requestTime;
        this.requestTimeCurrent = 0;
        requestTimeSlider.highValue = requestTime;
    }

    public void setEmailContents()
    {

    }

    public void setRequestCompleted(bool requestCompleted) { this.requestCompleted = requestCompleted; }

    public bool getRequestCompleted() { return requestCompleted; }
}
