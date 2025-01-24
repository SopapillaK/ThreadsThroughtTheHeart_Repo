using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int HP = 8;
    public Animator animator;
    
    public void TakeDamage(int damageAmount)
    {
        HP -= damageAmount;
        if (HP <= 0)
        {
            animator.SetBool("isChasing", false);
            Debug.Log("chase off");
            animator.SetBool("isAttacking", false);
            Debug.Log("attack off");
            animator.SetBool("isShouting", false);
            Debug.Log("shout off");
            animator.SetBool("isDie", true);
        }
        else
        {
            animator.SetTrigger("damage");
            Debug.Log("hit animation");

        }
    }
}
