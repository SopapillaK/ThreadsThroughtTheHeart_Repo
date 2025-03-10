using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingSkip : MonoBehaviour
{
    public void FadetoTitle()
    {
        //memoryToLoad = memoryIndex;
        //animator.SetTrigger("FadeOut");

        SceneManager.LoadScene(0);
    }
}
