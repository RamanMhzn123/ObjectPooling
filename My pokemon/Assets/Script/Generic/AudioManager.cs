using UnityEngine;

public class AudioManager : Singleton<AudioManager> //1 duplicate script with different game object
{
    private void Awake()
    {
        AudioManager.getInstance();
    }
}
