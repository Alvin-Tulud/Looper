using UnityEngine;
using System.Collections.Generic;
using System.IO;
using UnityEngine.UI;

public class EmailLooper : MonoBehaviour
{

    // This spins the little email looper pointer around,
    // and then 

    private GameObject pointer; // Reference to the spinny pointer
    private int readingEmailIndex; // Which email (which quadrant on the scheduler) was just sent?
    public string[] loadedEmails;   // The emails that are in the auto-scheduler
    public int loadedEmailIndex;    // Number of loaded emails

    // (Delimit all kinds of spaces, grammar, etc. to get just the words out.
    // Helps in cases like son's -> find the word "son" within)
    private char[] delimiterChars = { ' ', ',', '.', ':', ';', '\t', '\'', '\"', '/', '\n', '*' };

    [SerializeField] Image[] quadrants = new Image[4];

    void Start()
    {
        pointer = GameObject.FindWithTag("LooperPointer");
        readingEmailIndex = -1; // Start at -1 so it will immediately begin at 0
        loadedEmails = new string[4];
        loadedEmailIndex = 1;
    }


    void FixedUpdate()
    {
        // Rotate the clock hand
        float rotation = (float)TimeVars.getCurrent() / (float)(TimeVars.getHourFrame() * 4);
        //Debug.Log(rotation);
        pointer.transform.eulerAngles = new Vector3(0, 0, -rotation * 365);

        // Every hour we need to:
        // - Increment the hour
        // - Send this hour's current email to every open request
        // - Delete last hour's email
        if (TimeVars.getCurrent() % TimeVars.getHourFrame() == 0)
        {
            readingEmailIndex++;
            // get the email from the stack
            // (currentEmailIndex % 4)
            // FIRE AWAY at every available coworker request
            // foreach(requestController in [all children of gridContent])
            // if(request.getCanCheck)
            //      CheckEmailScore(email, request.GetEmailArgs);


            // Delete last hour's email
            // (currentEmailIndex-1) % 4
            // (if != null, numberOfLoadedEmails--)
        }
    }

    // Adds the email to the list of emails
    public void AddEmail(string email)
    {
        // If there's space, add an email in that quadrant then move to the next
        if(loadedEmails[loadedEmailIndex] == null)
        {
            // add email here
            loadedEmails[loadedEmailIndex] = email;

            // change color to indicate email was added
            quadrants[loadedEmailIndex].color = Color.green;
            
            // increment quadrant
            loadedEmailIndex = (loadedEmailIndex + 1) % 4;
        }
    }

    // TLDR:
    // - Check if email meets char count
    // - Parse email into words (emailCriteria)
    // - check each word against criteria (then set criteriaMet)
    // - and also against the tone dictionary (toneMet)
    // - If every criteria is met, rateUp, otherwise rateDown
    public int CheckEmailScore(string input, string[] emailArgs)
    {
        //[1]=charcount, [2]=subject, [3]=tone, [4]=verb, [5]=rateup, [6]=ratedown
        int rateUp = int.Parse(emailArgs[5]);
        int rateDown = int.Parse(emailArgs[6]);


        // 1. Check length requirement
        if (input.Length < int.Parse(emailArgs[1])) // TODO FIX CHARCOUNT TO THE PROPER VARIABLE
        {
            return rateDown;
        }

        // I transplanted this out of TextInputHandler.cs which is why it is kinda messy

        string emailTone = emailArgs[3];
        string toneFilePath;   // Path for the file where the tone words are kept
        bool toneMet = false;


        // Builds a list of required words (emailCriteria) and a bool associated with each (criteriaMet).
        // Should handle multi word subjects/verbs or whatnot
        List<string> testList = new List<string>();
        string[] subjectWords = emailArgs[2].Split(' ');
        foreach(string s in subjectWords)
        {
            testList.Add(s);
        }
        string[] verbWords = emailArgs[4].Split(' ');
        foreach (string v in verbWords)
        {
            testList.Add(v);
        }
        string[] emailCriteria = testList.ToArray(); // List of all words needed for the email

        bool[] criteriaMet = new bool[emailCriteria.Length];

        // 2. Split the email into a word array
        input.ToLower();
        string[] inputWords = input.Split(delimiterChars);

        /*
        // Set criteria booleans to false
        for (int i = 0; i < criteriaMet.Length; i++)
        {
            criteriaMet[i] = false;
        }
        toneMet = false;
        */

        // 3. Iterate through input substrings to check for the criteria
        foreach (string word in inputWords)
        {
            // For every word in the full criteria list:
            // Check if word meets criteria[i], if so, bool[i] = true;
            for (int i = 0; i < emailCriteria.Length; i++)
            {
                if (word.Equals(emailCriteria[i]))
                    criteriaMet[i] = true;
            }

            // 4. Check for tone words separately
            if (toneMet == false)
            {
                switch (emailTone)
                {
                    case "happy":
                        toneFilePath = Application.dataPath + "/Tone Thesaurus/happy.txt";
                        break;
                    case "sad":
                        toneFilePath = Application.dataPath + "/Tone Thesaurus/sad.txt";
                        break;
                    case "angry":
                        toneFilePath = Application.dataPath + "/Tone Thesaurus/angry.txt";
                        break;
                    default:
                        Debug.LogError("Email has wrong/no tone?? [" + emailTone + "] Defaulting to happy");
                        toneFilePath = Application.dataPath + "/Tone Thesaurus/happy.txt";
                        break;
                }
                string[] toneWords = File.ReadAllLines(toneFilePath);
                //Debug.Log(toneWords[0] + toneWords[1] + toneWords.Length);
                foreach (string toneWord in toneWords)
                {
                    if (word.Equals(toneWord))
                    {
                        toneMet = true;
                        break;
                    }
                }
            }
        }



        // 5. rateDown if not all criteria met, otherwise rate Up
        if (toneMet == false)
        {
            Debug.Log("Did not meet tone criteria");
            return rateDown;
        }
        foreach (bool c in criteriaMet)
        {
            if (c == false)
            {
                Debug.Log("not all criteria met, rating down");
                return rateDown;
            }

        }
        Debug.Log("rating up!");
        return rateUp;
    }
}
