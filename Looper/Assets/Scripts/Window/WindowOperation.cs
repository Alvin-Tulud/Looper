using UnityEngine;

public class WindowOperation : MonoBehaviour
{
    public GameObject entireObject;
    public GameObject window;
    public GameObject icon;

    public void minimize()
    {
        window.SetActive(false);
        AudioSO.PlayOneShot("event:/windowClick");
    }

    public void maximize()
    {
        window.SetActive(true);
        AudioSO.PlayOneShot("event:/windowClick");
    }

    public void close()
    {
        AudioSO.PlayOneShot("event:/windowClick");
        Destroy(window);
        Destroy(icon);
        Destroy(entireObject);
    }
}
