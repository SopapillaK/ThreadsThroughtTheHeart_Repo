using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartHubGameManager : MonoBehaviour
{
    public GameObject posAffNotebook;
    public void NotebookPopUp()
    {
        posAffNotebook.SetActive(true);
    }

    public void NotebookClose()
    {
        posAffNotebook.SetActive(false);
    }
}
