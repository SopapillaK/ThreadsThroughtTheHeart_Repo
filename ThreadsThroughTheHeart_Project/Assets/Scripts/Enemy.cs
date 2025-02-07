using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int HP = 8;
    public Animator animator;
    public GameObject fray;

    public GameManager gameManager;

    public void TakeDamage(int damageAmount)
    {
        if (animator.GetBool("isShouting"))
        {
            HP -= damageAmount;
            if (HP <= 0)
            {
                animator.SetTrigger("die");
                Invoke("DeleteFray", 2.0f);
            }
            else
            {
                animator.SetTrigger("damage");
                //Debug.Log("hit animation");

            }
        }
    }

    void DeleteFray()
    {
        Destroy(fray);
        gameManager.enemyDeadCount++;
    }
}
