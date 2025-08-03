using UnityEngine;

public class WindowOperation : MonoBehaviour
{
    public GameObject entireObject;
    public GameObject window;
    public GameObject icon;

    public void minimize()
    {
        window.SetActive(false);
    }

    public void maximize()
    {
        window.SetActive(true);
    }

    public void close()
    {
        Destroy(window);
        Destroy(icon);
        Destroy(entireObject);
    }
}
