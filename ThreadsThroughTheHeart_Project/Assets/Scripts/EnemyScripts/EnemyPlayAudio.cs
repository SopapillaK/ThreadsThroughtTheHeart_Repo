using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPlayAudio : MonoBehaviour
{
    public Animator frayAnimator;
    public AudioSource audioSource;
    public AudioClip frayNegThought;


    // Update is called once per frame
    void Update()
    {
        if (frayAnimator.GetBool("ShoutSound") )
        {
            PlayNegThoughtAudio();

            if (frayAnimator.GetBool("GotHit"))
            {
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
