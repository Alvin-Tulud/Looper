using UnityEngine;

public class MinimizeWindow : MonoBehaviour
{
    public GameObject window;

    public void minimize()
    {
        window.SetActive(false);
    }

    public void maximize()
    {
        window.SetActive(true);
    }
}
