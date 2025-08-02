using UnityEngine;
using TMPro;

public class TextInputGrabber : MonoBehaviour
{
    // This script is attached to InputField object and stores the typed text in the variable inputText.

    [SerializeField] private string inputText; // Stores the text string here

    // Gets called on value changed
    public void GetInput(string input)
    {
        inputText = input;
    }
}
