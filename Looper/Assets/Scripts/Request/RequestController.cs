using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RequestController : MonoBehaviour
{
    public Slider requestTimeSlider;
    private int TimeEnd;
    private int TimeStart;

    public TextMeshProUGUI requestEmailContents;
    public TextMeshProUGUI ratingUp;
    public TextMeshProUGUI ratingDown;
    private string[] emailArgs;

    private bool requestCompleted = false;

    private void FixedUpdate()
    {
        incrementRequestTime();
    }

    private void incrementRequestTime()
    {
        if (TimeVars.getCurrent() < TimeEnd)
        {
            requestTimeSlider.value = (int)(100 * ((float)(TimeVars.getCurrent() - TimeStart) / (TimeEnd - TimeStart)));
        }
        else
        {
            requestTimeSlider.value = requestTimeSlider.maxValue;
        }
    }
    
    public void setRequestTime(int requestTime)
    {
        this.TimeEnd = requestTime;
        this.TimeStart = TimeVars.getCurrent();

        requestTimeSlider.value = 0;
    }

    public void setEmailContents(string[] args)
    {
        emailArgs = args;

        requestEmailContents.text = emailArgs[0];
        ratingUp.text = emailArgs[5];
        ratingDown.text = emailArgs[6];
    }

    public string[] getEmailArgs() { return emailArgs; }

    public void setRequestCompleted(bool requestCompleted) { this.requestCompleted = requestCompleted; }

    public bool getRequestCompleted() { return requestCompleted; }
}
