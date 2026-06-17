using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioMenager : MonoBehaviour
{
    public static AudioMenager Instance;

    [SerializeField] private AudioSource audioSource;

    public AudioClip deathSound;
    public AudioClip checkpointSound;
    public AudioClip collectItem;
    public AudioClip jumpSound;


    private void Awake()
    {
        Instance = this;
    }

    public void PlaySound(AudioClip audioClip)
    {
        audioSource.PlayOneShot(audioClip);
    }
}
