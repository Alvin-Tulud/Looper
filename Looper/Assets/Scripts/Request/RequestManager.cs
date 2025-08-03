using System.Collections;
using UnityEngine;

public class RequestManager : MonoBehaviour
{
    public GameObject RequestOBJ;
    public GameObject RequestScrollParent;

    public float emailChance = 0.7f;
    public float SecondsBetweenEmailChance = 12;
    public int roundRequestCount = 3;
    private bool canrequest = true;

    public int[] charCounts = {80, 100, 120, 140, 160, 180, 200};
    public string[] emailSubjectPerson = {"son waterpolo", "daughter tennis","daughter basketball","dog adoption","cat adoption","racing"};
    public string[] emailSubjectTopic = {"presentation","report","email","meeting"};
    public string[] emailTone = {"happy", "sad", "angry"};
    public string[] emailVerbPerson = {"victory", "failure","win","loss","event","party"};
    public string[] emailVerbTopic = {"failure","success","misunderstanding","situation"};
    public string[] names = { };

    private TimeDisplay TD;

    private void Awake()
    {
        TD = FindAnyObjectByType<TimeDisplay>();
    }

    private void FixedUpdate()
    {
        if (canrequest)
        {
            StartCoroutine(requestPause());

            //no more email requests after 3 generate them at a chance
            if (TD.getHourIndex() < 6 &&
                roundRequestCount > 0)
            {
                float chance = Random.Range(0.0f, 1.0f);

                //30% chance of getting an email request every 12 seconds
                if (chance >= emailChance)
                {
                    GameObject g = Instantiate(RequestOBJ);
                    g.transform.SetParent(RequestScrollParent.transform, false);

                    //set the email to be due within the next 1 - 3 "hours"
                    int randomHourOffset = Random.Range(TD.getHourIndex() + 3, TD.getHourIndex() + 5);

                    Debug.Log(randomHourOffset + ":" + TD.getHour(randomHourOffset));

                    g.GetComponent<RequestController>().setRequestTime(randomHourOffset * TimeVars.getHourFrame());
                    g.GetComponent<RequestController>().setEmailContents(RequestBuilder(randomHourOffset));

                    roundRequestCount--;
                }
            }
            //if still have request left to handle and its past 3 generate all of them
            else if (TD.getHourIndex() == 6 &&
                roundRequestCount > 0)
            {
                for (int i = roundRequestCount;  i >= 0; i--)
                {
                    GameObject g = Instantiate(RequestOBJ);
                    g.transform.SetParent(RequestScrollParent.transform, false);

                    //set the email to be due within the next 1 - 3 "hours"
                    int randomHourOffset = Random.Range(TD.getHourIndex() + 3, TD.getHourIndex() + 4);

                    Debug.Log(randomHourOffset + ":" + TD.getHour(randomHourOffset));

                    g.GetComponent<RequestController>().setRequestTime(randomHourOffset * TimeVars.getHourFrame());
                    g.GetComponent<RequestController>().setEmailContents(RequestBuilder(randomHourOffset));
                }
            }
        }
    }

    public string[] RequestBuilder(int hourindex)
    {//0:email string, 1:charcount, 2:subject, 3:tone, 4:verb, 5:rateup, 6:ratedown, 7:name
        string[] requestArr = new string[8] {"", "", "", "", "", "", "", ""};
        int randChar = Random.Range(0, charCounts.Length);
        int randTone = Random.Range(0, emailTone.Length);

        requestArr[1] = charCounts[randChar].ToString();
        requestArr[3] = emailTone[randTone];

        requestArr[0] = "Please replay with a " +
                        requestArr[3];

        float pickSubjectType = Random.Range(0f, 1f);

        if (pickSubjectType <= 0.4f)
        {
            int randSubject = Random.Range(0, emailSubjectPerson.Length);
            int randVerb = Random.Range(0, emailVerbPerson.Length);

            requestArr[2] = emailSubjectPerson[randSubject];
            requestArr[4] = emailVerbPerson[randVerb];
            requestArr[5] = "10";
            requestArr[6] = "-5";

            requestArr[0] += " email about my " +
                        requestArr[2] +
                        " " +
                        requestArr[4];
        }
        else
        {
            int randSubject = Random.Range(0, emailSubjectTopic.Length);
            int randVerb = Random.Range(0, emailVerbTopic.Length);

            requestArr[2] = emailSubjectTopic[randSubject];
            requestArr[4] = emailVerbTopic[randVerb];
            requestArr[5] = "30";
            requestArr[6] = "-15";

            requestArr[0] += " email about the " +
                        requestArr[2] +
                        " " +
                        requestArr[4];
        }

        requestArr[0] += " in atleast " +
                        requestArr[1] +
                        " characters. \nHave it ready by " + setText(hourindex);

        return requestArr;

    }
    private string setText(int index)
    {
        Debug.Log(index + ":" + TD.getHour(index));
        string timeText = TD.getHour(index).ToString("D2") + ":00";

        if (index > 2)
        {
            timeText += " PM";
        }
        else if (index > 9)
        {
            timeText = "6:00 PM";
        }
        else
        {
            timeText += " AM";
        }

        return timeText;
    }

    public void setRequestCount(int count) { roundRequestCount = count; }

    private IEnumerator requestPause()
    {
        canrequest = false;

        yield return new WaitForSeconds(SecondsBetweenEmailChance);

        canrequest = true;
    }
}
