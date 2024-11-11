using UnityEngine;

public class SoundtrackManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip mainMenuMusic;
    public AudioClip gameplayMusic;

    void Start()
    {
        PlayMainMenuMusic();
    }

    public void PlayMainMenuMusic()
    {
        audioSource.clip = mainMenuMusic;
        audioSource.Play();
        Debug.Log("Playing Menu Music!");
    }

    public void PlayGameplayMusic()
    {
        audioSource.clip = gameplayMusic;
        audioSource.Play();
        Debug.Log("Playing Gameplay Music!");
    }
}