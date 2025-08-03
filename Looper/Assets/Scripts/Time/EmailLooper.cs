using UnityEngine;

public class EmailLooper : MonoBehaviour
{

    private GameObject pointer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pointer = GameObject.FindWithTag("LooperPointer");
    }


    void FixedUpdate()
    {
        float rotation = (float)TimeVars.getCurrent() / (float)(TimeVars.getHourFrame() * 4);
        Debug.Log(rotation);

        pointer.transform.eulerAngles = new Vector3(0,0,-rotation*365);
    }
}
