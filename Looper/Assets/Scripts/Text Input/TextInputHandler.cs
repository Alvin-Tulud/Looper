using UnityEngine;
using TMPro;
using System.Collections.Generic;
using System.IO;

public class TextInputHandler : MonoBehaviour
{
    // This script is attached to InputField object and
    // reads the input text + checks the score.

    [SerializeField] private string inputText; // Stores the text string here
    [SerializeField] private int finalRating; // Rating +/- to be applied when the email is sent

    [SerializeField] private string toneFilePath;   // Path for the file where the tone words are kept

    // (Delimit all kinds of spaces, grammar, etc. to get just the words out.
    // Helps in cases like son's -> find the word "son" within)
    private char[] delimiterChars = {' ', ',', '.', ':', ';', '\t', '\'', '\"', '/', '\n', '*'};

    // Email stats/criteria
    //private string[] emailSubject;
    //private string[] emailTone;
    //private string[] emailVerb;
    [SerializeField] private string[] emailCriteria; // List of all words needed for the email
    private string emailTone;
    private int charCount;          // Minimum char count
    [SerializeField] private int rateUp;             // Score if passed
    [SerializeField] private int rateDown;           // Score if failed

    // Booleans to check if criteria are met
    [SerializeField] private bool[] criteriaMet;
    private bool toneMet;

    void Start()
    {
        // TODO
        // Fill my variables with input from RequestArr
        // (and don't forget to split the strings for multiple words)
        // *** PARSE IF NECESSARY THEN COMBINE ALL OF THEM INTO A SINGLE LIST OF WORDS

        // junk data for now
        List<string> testList = new List<string>();
        testList.Add("son");
        testList.Add("goku");
        emailCriteria = testList.ToArray();
        rateUp = 5;
        rateDown = -5;

        // (store tone separately)

        // (and then initialize bools based on length of subject/tone/verb)
        criteriaMet = new bool[emailCriteria.Length];
    }

    // Gets called on value changed
    public void GetInput(string input)
    {
        inputText = input;
    }

    // TODO:
    // vv Rewrite to check against all available coworker things

    // Compares typed email to given parameters (subject, tone, etc.) to determine score.
    // If charCount met and every needed word is present, returns rateUp, otherwise returns rateDown.
    // (Gets called whenever input field changes)
    public void CheckEmailScore(string input)
    {
        // Just for testing, remove it later
        inputText = input;

        // 1. Check length requirement
        if (input.Length < charCount)
        {
            finalRating = rateDown;
            return;
        }

        // 2. Lowercase, then split the string into substrings
        // TODO: MAKE IT LOWERCASE
        string[] inputWords = input.Split(delimiterChars);

        // Set criteria booleans to false
        for(int i=0; i<criteriaMet.Length; i++)
        {
            criteriaMet[i] = false;
        }
        toneMet = false;


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
            if(toneMet == false)
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
                Debug.Log(toneWords[0] + toneWords[1] + toneWords.Length);
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
            finalRating = rateDown;
            return;
        }
        foreach (bool c in criteriaMet)
        {
            if (c == false)
            {
                Debug.Log("not all criteria met, rating down");
                finalRating = rateDown;
                return;
            }

        }

        finalRating = rateUp;
        return;
    }
}
