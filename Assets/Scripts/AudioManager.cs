using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip backgroundMusic;
    public AudioClip buttonClickSound;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        // Play background music on start
        //PlayBackgroundMusic();
    }

    void PlayBackgroundMusic()
    {
        //audioSource.clip = backgroundMusic;
       // audioSource.loop = true;
        //audioSource.Play();
    }

    public void PlayButtonClickSound()
    {
        audioSource.PlayOneShot(buttonClickSound);
    }

    public void ToggleAudio(bool isOn)
    {

        audioSource.mute = !audioSource.mute;
    }
}
