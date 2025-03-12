using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrayUI : MonoBehaviour
{
    public Animator animator;
    [Header("Fray Effects")]
    public GameObject exlimationPoints;

    // Update is called once per frame
    void Update()
    {
        if (animator.GetBool("GotHit"))
        {
            exlimationPoints.SetActive(true);

        }
        else
        {
            exlimationPoints.SetActive(false);
        }
    }
}
