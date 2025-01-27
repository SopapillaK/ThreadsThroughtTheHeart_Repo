using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int HP = 8;
    public Animator animator;
    
    public void TakeDamage(int damageAmount)
    {
        if (animator.GetBool("isShouting"))
            HP -= damageAmount;
        if (HP <= 0)
        {
            animator.SetTrigger("die");
        }
        else
        {
            animator.SetTrigger("damage");
            //Debug.Log("hit animation");

        }
    }

    
}
