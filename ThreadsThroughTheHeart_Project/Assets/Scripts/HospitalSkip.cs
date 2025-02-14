using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class HospitalSkip : MonoBehaviour
{
    public Animator animator;
    public bool cutsceneComplete = false;
    //private int memoryToLoad;

    public void Update()
    {
        if (cutsceneComplete == true)
        {
            animator.SetTrigger("FadeOut");

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
    public void FadetoMemory (int memoryIndex)
    {
        //memoryToLoad = memoryIndex;
        animator.SetTrigger("FadeOut");

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    /*
     * public void OnFadeComplete()
     * {
     *      SceneManager.LoadScene(memoryToLoad);
     * }
     */
}
