using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneSwitcher1 : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //AudioSO.PlayOneShot("event:/computerOpen");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void goToGame(int world)
    {
        //This method will switch the current scene to the game screen.
        SceneManager.LoadScene(world);
    }

}
