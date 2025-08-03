//using Unity.Android.Gradle;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.UIElements;

public class CreateWindow : MonoBehaviour
{
    [SerializeField]
    private GameObject prefabToSpawn;
    public GameObject taskbar;
    public Transform spawnPoint;
    public GameObject mailParent;

    public void OnAwake()
    {
        prefabToSpawn = Resources.Load<GameObject>("Prefabs/ProtoWindow");
    }

    public void makeWindow()
    {
        if (spawnPoint != null)
        {
            // Window click SFX
            AudioSO.PlayOneShot("event:/windowClick");

            // Spawn both items first
            GameObject newWindow = Instantiate(prefabToSpawn, spawnPoint.transform.position, spawnPoint.transform.rotation,mailParent.transform);

            // Then move the icon to the taskbar
            newWindow.transform.GetChild(1).transform.SetParent(taskbar.transform,false);
        }
        else
        {
            Debug.Log("No spot to spawn window");
        }
    }
}
