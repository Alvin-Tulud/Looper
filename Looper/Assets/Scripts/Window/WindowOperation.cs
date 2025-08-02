using UnityEngine;

public class WindowOperation : MonoBehaviour
{
    public GameObject entireObject;
    public GameObject window;

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
        Destroy(entireObject);
    }
}
