using UnityEngine;

public class SoundSpawner : MonoBehaviour
{
    public void PlaySoundEffect(AudioClip clip)
    {
        AudioManager.instance.PlaySFX(clip);
    }
}
