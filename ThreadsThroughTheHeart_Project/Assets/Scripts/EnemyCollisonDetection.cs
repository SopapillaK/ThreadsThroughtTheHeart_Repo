using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollisonDetection : MonoBehaviour
{
    public Animator animator;

    public void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other);
        if (other.tag == "InvisibleWall")
        {
            //Debug.Log("Go back");
            animator.SetBool("isChasing", false);
            animator.SetBool("isAttacking", false);
        }
    }
}
