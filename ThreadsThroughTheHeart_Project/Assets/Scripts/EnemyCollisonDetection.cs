using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollisonDetection : MonoBehaviour
{
    public Animator animator;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "InvisibleWall")
        {
            animator.SetBool("isChasing", false);
            Debug.Log(other);
        }
    }
}
