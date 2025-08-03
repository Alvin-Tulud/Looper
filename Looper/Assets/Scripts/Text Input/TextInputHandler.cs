using UnityEngine;
using TMPro;
using System.Collections.Generic;
using System.IO;

public class TextInputHandler : MonoBehaviour
{
    // This script is attached to InputField object and
    // reads the input text.

    [SerializeField] private string inputText; // Stores the text string here
    public GameObject thingtodestroy;
    public GameObject tabdestroy;

    void Start()
    {
        
    }

    // Gets called on value changed
    public void GetInput(string input)
    {
        inputText = input;
    }

    // Put "add email to thing" button here
    public void PressScheduleButton()
    {
        EmailLooper e = GameObject.FindWithTag("EmailLooper").GetComponent<EmailLooper>();
        bool result = e.AddEmail(inputText);
        AudioSO.PlayOneShot("event:/emailSend");

        if(result)
        {
            Debug.Log("Added email: " + inputText);
            Destroy(thingtodestroy);
            Destroy(tabdestroy);
        }

    }
}
