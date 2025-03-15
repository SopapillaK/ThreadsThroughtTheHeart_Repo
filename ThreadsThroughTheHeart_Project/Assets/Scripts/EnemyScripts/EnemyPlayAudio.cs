using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPlayAudio : MonoBehaviour
{
    public Animator frayAnimator;
    [Header("Audio")]
    public AudioSource audioSource;
    public AudioClip frayNegThought;
    [Header("Subtitles")]
    public GameObject frayNegSubtitles;
    public GameObject uiBackground;

    // Update is called once per frame
    void Update()
    {
        if (frayAnimator.GetBool("ShoutSound") )
        {
            PlayNegThoughtAudio();
            uiBackground.SetActive(true);
            frayNegSubtitles.SetActive(true);

            if (frayAnimator.GetBool("GotHit"))
            {
                uiBackground.SetActive(false);
                frayNegSubtitles.SetActive(false);
                audioSource.Stop();
            }
        }        
    }
    void PlayNegThoughtAudio()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(frayNegThought);
        }
    }
}
