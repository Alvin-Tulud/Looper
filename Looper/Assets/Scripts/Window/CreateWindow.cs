using Unity.Android.Gradle;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.UIElements;

public class CreateWindow : MonoBehaviour
{
    public Canvas canvas;
    [SerializeField]
    private GameObject prefabToSpawn;
    public Transform spawnPoint;

    public GameObject mailParent;

    public void makeWindow()
    {
        if (spawnPoint != null)
        {
            GameObject newWindow = Instantiate(prefabToSpawn);

            // Get all ChildScript components in children
            DragWindow[] childComponents = newWindow.GetComponentsInChildren<DragWindow>();

            print(childComponents);

            // Iterate and modify variables
            foreach (DragWindow child in childComponents)
            {
                child.canvas = canvas;
            }

            if (mailParent != null)
            {
                newWindow.transform.SetParent(mailParent.transform);
            }
        }
        else
        {
            Debug.Log("No spot to spawn window");
        }
    }
}
