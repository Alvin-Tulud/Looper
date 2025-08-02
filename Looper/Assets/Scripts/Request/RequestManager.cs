using UnityEngine;

public class RequestManager : MonoBehaviour
{
    public GameObject RequestOBJ;

    public int[] charCounts = {80, 100, 120, 140, 160, 180, 200};
    public string[] emailSubjectPerson = {"son waterpolo", "daughter tennis","daughter basketball","dog adoption","cat adoption","racing"};
    public string[] emailSubjectTopic = {"presentation","report","email","meeting"};
    public string[] emailTone = {"happy", "sad", "angry"};
    public string[] emailVerbPerson = {"victory", "failure","win","loss","event","party"};
    public string[] emailVerbTopic = {"failure","success","misunderstanding","situation"};
    public string[] names = { };

    public void RequestBuilder()
    {//0:email string, 1:charcount, 2:subject, 3:tone, 4:verb, 5:rateup, 6:ratedown, 7:name
        string[] requestArr = new string[8] {"", "", "", "", "", "", "", ""};
        int randChar = Random.Range(0, charCounts.Length);
        int randTone = Random.Range(0, emailTone.Length);

        requestArr[1] = charCounts[randChar].ToString();
        requestArr[3] = emailTone[randTone];

        requestArr[0] = "Please replay with a " +
                        requestArr[3];

        int pickSubjectType = Random.Range(0, 1);

        if (pickSubjectType == 0)
        {
            int randSubject = Random.Range(0, emailSubjectPerson.Length);
            int randVerb = Random.Range(0, emailVerbPerson.Length);

            requestArr[2] = emailSubjectPerson[randSubject];
            requestArr[4] = emailVerbPerson[randVerb];
            requestArr[5] = "10";
            requestArr[6] = "-5";

            requestArr[0] += " email about my" +
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

            requestArr[0] += " email about the" +
                        requestArr[2] +
                        " " +
                        requestArr[4];
        }

        requestArr[0] += " in atleast " +
                        requestArr[1] +
                        " characters.";


    }
}
