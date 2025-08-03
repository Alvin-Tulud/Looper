using TMPro;
using UnityEngine;

public class RoundManager : MonoBehaviour
{
    private string[] roundNames = {"Early Jan", "Late Jan", "Early Feb", "Late Feb", "Early March", "Late March", "Early April"};
    private int maxRoundCount = 6;
    private int currentRoundCount = 1;

    public TextMeshProUGUI RoundName;
    public TextMeshProUGUI Rating;

    private int CurrentRating = 0;
    private int NeededRating = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        
    }

    private void FixedUpdate()
    {
        checkRoundOver();
    }

    public void setRating(int rating)
    {
        CurrentRating += rating;
    }

    private void checkRoundOver()
    {
        if (TimeVars.getCurrent() >= TimeVars.getMaxTime())
        {

        }
    }

    private void generateRatingNeed()
    {

    }
}
