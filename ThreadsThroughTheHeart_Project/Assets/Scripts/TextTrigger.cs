using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextTrigger : MonoBehaviour
{
    public GameObject UnderstandingChoices;
    public GameObject directionText;

    void OnTriggerEnter()
    {
        UnderstandingChoices.SetActive(true);
        directionText.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        //Time.timeScale = 0;
    }
    /*
    void OnCollisionEnter(Collision collision)
    {
        UnderstandingChoices.SetActive(true);
    }*/
}
