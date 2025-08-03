using UnityEngine;
using UnityEngine.UI;

public class randomizeSprite : MonoBehaviour
{
    public Sprite[] workerIcons;

    private void Awake()
    {
        Image worker = GetComponent<Image>();
        int randomImage = Random.Range(0, workerIcons.Length);
        worker.sprite = workerIcons[randomImage];
    }
}
