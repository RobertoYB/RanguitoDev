using UnityEngine;

public class AudioController : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip[] clip;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayAudio(int num)
    {
        audioSource.clip = clip[num];
        audioSource.Play();
    }

    public void StopAudio()
    {

    }
}
