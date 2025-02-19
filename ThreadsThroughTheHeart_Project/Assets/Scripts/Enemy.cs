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
        TakeDamage(1);
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
    }
    public void TakeDamage(int damageAmount)
    {
        if (animator.GetBool("isShouting") || posThoughts.GetComponent<PositiveThought>().rightChoice == true)
        {
            HP -= damageAmount;
            if (posThoughts.GetComponent<PositiveThought>().rightChoice == true)
            {
                animator.SetTrigger("die");
                Invoke("DeleteFray", 2.0f);

                Time.timeScale = 1.0f;
                postProc.SetActive(false);
                posOptions.SetActive(false);
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
