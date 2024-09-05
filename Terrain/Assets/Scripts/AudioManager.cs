using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header ("----------Audio Source------------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SVXSource;

    [Header("----------Audio Clip------------")]
    public AudioClip background;
    public AudioClip coinCollect; 
    public AudioClip hitSaw;

    private void Start()
    {
        musicSource.clip = background;
        musicSource.Play();
    }

    public void PlaySVX(AudioClip clip)
    {
        SVXSource.PlayOneShot(clip);
    }
}
