//using Unity.Android.Gradle;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.UIElements;

public class CreateWindow : MonoBehaviour
{
    [SerializeField]
    private GameObject prefabToSpawn;
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
            GameObject newWindow = Instantiate(prefabToSpawn, spawnPoint.transform.position, spawnPoint.transform.rotation,mailParent.transform);
        }
        else
        {
            Debug.Log("No spot to spawn window");
        }
    }
}
