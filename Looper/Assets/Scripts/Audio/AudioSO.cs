using UnityEngine;

[CreateAssetMenu(fileName = "AudioSO", menuName = "Scriptable Objects/AudioSO")]
public class AudioSO : ScriptableObject
{
    public void PlayOneShot(string path)
    {
        FMODUnity.RuntimeManager.PlayOneShot(path);
    }
}
