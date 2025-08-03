using System.Collections;
using TMPro;
using UnityEngine;

public class RoundManager : MonoBehaviour
{
    private string[] roundNames = {"Early Jan", "Late Jan", "Early Feb", "Late Feb", "Early March", "Late March", "Early April"};
    private int maxRoundCount = 6;
    private int currentRoundCount = 0;

    public TextMeshProUGUI RoundName;
    public TextMeshProUGUI Rating;

    private int CurrentRating = 0;
    private int NeededRating = 20;
    private int TotalRating = 0;

    private int RequestCount = 3;

    private RequestManager RQM;
    private TimeDisplay TD;

    public GameObject endScreen;
    public TMP_InputField EndText;
    private string[] endWords = { "Thank you for your work intern.\r\nWe will be moving forward with your\r\nJob Offer.", "Thank you for being here.\r\nUnfortunately we found other\r\ncandidtates well suited for the job.\r\nTry again next Year." };
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        RQM = FindAnyObjectByType<RequestManager>();
        TD = FindAnyObjectByType<TimeDisplay>();
        setDayText();
        setRatingText();
    }

    private void FixedUpdate()
    {
        checkRoundOver();
    }

    public void setRating(int rating)
    {
        CurrentRating += rating;
        setRatingText();

        if (rating > 0)
        {
            //play good jingle
        }
        else
        {
            //play bad jingle
        }
    }

    private void setRatingText()
    {
        Rating.text = CurrentRating + " / " + NeededRating;
    }

    private void setDayText()
    {
        RoundName.text = roundNames[currentRoundCount];
    }

    private void checkRoundOver()
    {
        if (TimeVars.getCurrent() >= TimeVars.getMaxTime())
        {
            TimeVars.setCanUpdate(false);
            if (CurrentRating >= NeededRating)
            {
                incrementRating();

                if (currentRoundCount == maxRoundCount)
                {
                    endScreen.SetActive(true);
                    EndText.text = endWords[0];
                    EndText.text += "\nTotal Rating: " + TotalRating;
                    //do end screen stuff show end rating and a good job intern we're giving you an offer
                }
                else
                {
                    incrementRoundCount();
                    incrementRequestCount();

                    StartCoroutine(roundPauseReset());
                }
            }
            else
            {
                endScreen.SetActive(true);
                EndText.text = endWords[0];
                EndText.text += "\nTotal Rating: " + TotalRating;
                //do end screen stuff and show end rating and a bad job employee youve been fired
            }
        }
    }

    private void incrementRating()
    {
        NeededRating += (int)(20 * 1.5f);
        TotalRating += CurrentRating;
        setRating(-CurrentRating);
    }

    private void incrementRequestCount()
    {
        RequestCount += 2;
    }

    private void incrementRoundCount()
    {
        currentRoundCount++;
        setDayText();
    }

    private IEnumerator roundPauseReset()
    {
        yield return new WaitForSeconds(3);

        TimeVars.resetCurrent();
        RQM.setRequestCount(RequestCount);
        TD.resetVars();
    }
}
