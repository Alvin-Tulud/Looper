using UnityEngine;

public class RequestManager : MonoBehaviour
{
    public GameObject RequestOBJ;

    public int[] charCounts;
    public string[] emailSubject;
    public string[] emailTone;
    public string[] emailVerb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public string[] EmailBuilder()
    {
        string[] requestArr = new string[5] { "", "", "", "", "" };
        int randChar = Random.Range(0, charCounts.Length);
        int randSubject = Random.Range(0, emailSubject.Length);
        int randTone = Random.Range(0, emailTone.Length);
        int randVerb = Random.Range(0, emailVerb.Length);

        requestArr[1] = charCounts[randChar].ToString();
        requestArr[2] = emailSubject[randSubject];
        requestArr[3] = emailTone[randTone];
        requestArr[4] = emailVerb[randVerb];

        requestArr[0] = "Please replay with a " + 
                        requestArr[3] + 
                        " email about " +
                        requestArr[2] + 
                        " " + 
                        requestArr[4];

        return requestArr;
    }
}
