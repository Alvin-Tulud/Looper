using UnityEngine;
using TMPro;

public class TextInputHandler : MonoBehaviour
{
    // This script is attached to InputField object and
    // reads the input text + checks the score.

    [SerializeField] private string inputText; // Stores the text string here
    [SerializeField] private int finalRating; // Rating +/- to be applied when the email is sent

    // (Delimit all kinds of spaces, grammar, etc. to get just the words out.
    // Helps in cases like son's -> find the word "son" within)
    private char[] delimiterChars = {' ', ',', '.', ':', ';', '-', '\t', '\'', '\"', '/', '\n', '*'};

    // Email stats/criteria
    //private string[] emailSubject;
    //private string[] emailTone;
    //private string[] emailVerb;
    [SerializeField] private string[] emailCriteria; // List of all words needed for the email
    private int charCount;          // Minimum char count
    private int rateUp;             // Score if passed
    private int rateDown;           // Score if failed

    // Booleans to check if criteria are met
    private bool[] criteriaMet;

    void Start()
    {
        // TODO
        // Fill my variables with input from RequestArr
        // (and don't forget to split the strings for multiple words)
        // *** PARSE IF NECESSARY THEN COMBINE ALL OF THEM INTO A SINGLE LIST OF WORDS

        // (and then initialize bools based on length of subject/tone/verb)
        criteriaMet = new bool[emailCriteria.Length];
    }

    // Gets called on value changed
    public void GetInput(string input)
    {
        inputText = input;
    }


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
        }

        // 2. Split the string into substrings
        string[] inputWords = input.Split(delimiterChars);

        // Set criteria booleans to false
        for(int i=0; i<criteriaMet.Length; i++)
        {
            criteriaMet[i] = false;
        }


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
        }

        // 4. rateDown if not all criteria met, otherwise rate Up
        foreach(bool c in criteriaMet)
        {
            if (c == false)
                finalRating = rateDown;
        }

        finalRating = rateUp;
    }
}
