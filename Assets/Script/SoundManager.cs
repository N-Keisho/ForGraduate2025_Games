using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip correctAnswer;
    public AudioClip wrongAnswer;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayCorrectAnswer()
    {
        audioSource.PlayOneShot(correctAnswer);
    }

    public void PlayWrongAnswer()
    {
        audioSource.volume = 0.5f;
        audioSource.PlayOneShot(wrongAnswer);
    }
}
