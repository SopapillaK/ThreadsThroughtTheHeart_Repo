using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int HP = 8;
    public Animator animator;
    public GameObject fray;
    public GameObject posThoughts;
    public GameObject postProc;
    public GameObject posOptions;


    public GameManager gameManager;

    void Update()
    {
        if (posThoughts.GetComponent<PositiveThought>().currentHP == 1)
        {
            Time.timeScale = 0.2f;
            postProc.SetActive(true);
            posOptions.SetActive(true);
        }
        else if (HP == 8)
        {
            Time.timeScale = 1.0f;
            postProc.SetActive(false);
            posOptions.SetActive(false);
        }

        if (posThoughts.GetComponent<PositiveThought>().rightChoice == true)
        {
            FrayDie();

            Time.timeScale = 1.0f;
            postProc.SetActive(false);
            posOptions.SetActive(false);
        }
    }
    public void TakeDamage(int damageAmount)
    {
        if (animator.GetBool("isShouting"))
        {
            HP -= damageAmount;
            animator.SetTrigger("damage");
            //Debug.Log("hit animation");

        }
    }

    public void FrayDie()
    {
        animator.SetTrigger("die");
        Invoke("DeleteFray", 2.0f);
    }

    void DeleteFray()
    {
        Destroy(fray);
        gameManager.enemyDeadCount++;
    }
}
