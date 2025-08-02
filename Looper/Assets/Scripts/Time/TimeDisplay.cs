using System;
using TMPro;
using UnityEngine;

public class TimeDisplay : MonoBehaviour
{
    private TextMeshProUGUI timeText;
    private int[] hours = {9,10,11,12,1,2,3,4,5};
    private int currentHour = 0;
    private int hourIndex = 0;
    private int minuteMax = 60;
    private int currentMinute = 0;
    private bool canUpdate;

    private bool doonce = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timeText = GetComponent<TextMeshProUGUI>();
        TimeVars.setCanUpdate(true);
        currentHour = hours[hourIndex];
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        checkTimeVar();

        if (canUpdate)
        {
            lerpTime();
            setText();
        }
    }

    private void checkTimeVar()
    {
        if (doonce)
        {
            doonce = false;
            TimeVars.setCanUpdate(true);
        }

        //Debug.Log("check: " + TimeVars.getCanUpdate());
        canUpdate = TimeVars.getCanUpdate();
    }

    private void lerpTime()
    {
        int minute = TimeVars.getCurrent() % TimeVars.getHourFrame();
        //Debug.Log("lerping: " + currentMinute + " : " + TimeVars.getCurrent() + " : " + minute);
        if (minute == 0)
        {
            Debug.Log("lerping: " + currentHour + ":" + currentMinute + " : " + TimeVars.getCurrent() + " : " + minute);

            hourIndex++;
            currentMinute = 0;

            //Debug.Log((hourIndex == hours.Length) + ":" + hourIndex + ":" + hours.Length);

            if (hourIndex == hours.Length)
            {
                hourIndex = 0;
                TimeVars.setCanUpdate(false);
            }
            else
            {
                currentHour = hours[hourIndex];
            }
        }
        else
        {
            currentMinute = (int)Mathf.Lerp(0, minuteMax, (float)minute / TimeVars.getHourFrame());
        }
    }

    private void setText()
    {
        timeText.text = currentHour.ToString("D2") + ":" + currentMinute.ToString("D2");

        if (hourIndex > 2)
        {
            timeText.text += " PM";
        }
        else if (hourIndex > hours.Length)
        {
            timeText.text = "6:00 PM";
        }
        else
        {
            timeText.text += " AM";
        }


    }
}
