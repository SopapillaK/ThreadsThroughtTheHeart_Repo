using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Enemy Stats")]
    public int HP = 8;
    public Animator animator;
    public GameObject fray;
    public GameObject attackArea;
    public HealthBar healthBarScript;
    public GameObject healthBar;

    bool frayDie = false;
    [Header("Wall Up")]
    public bool fightActivated = false;
    public GameObject wall;
    [Header("Waypoints")]
    public GameObject wayPoints;
    public string wayPointTag;
    //public string enemyName;
    [Header("Positive Thoughts QTE")]
    public GameObject posThoughtsController;
    public GameObject postProc;
    public GameObject posOptions;
    bool timeFreeze = false;
    


    public GameManager gameManager;

    void Awake()
    {
        wayPointTag = wayPoints.tag;

        FrayPatrolState frayPatrolState = animator.GetBehaviour<FrayPatrolState>();
        frayPatrolState.wayPointList = wayPointTag;
    }
    void Update()
    {
        //Positivethought QTE
        if (HP == 1 && !timeFreeze)
        {
            //Debug.Log("time freeze");
            Time.timeScale = 0.1f;
            timeFreeze = true;
            postProc.SetActive(true);
            posOptions.SetActive(true);
        }
        else if (HP == 4)
        {
            if (timeFreeze)
            {
                //Debug.Log("untime freeze 1");

                Time.timeScale = 1.0f;
                timeFreeze = false;
                healthBarScript.SetHealth(HP);
                postProc.SetActive(false);
                posOptions.SetActive(false);
            }
            
        }

        if (posThoughtsController.GetComponent<PositiveThought>().rightChoice == true)
        {
            if (timeFreeze)
            {
                //Debug.Log("untime slow 2");

                Time.timeScale = 1.0f;
                postProc.SetActive(false);
                posOptions.SetActive(false);
            }
           

            if (!frayDie)
            {
                fightActivated = false;
                frayDie = true;
                FrayDie();

            }
        }

        
    }
    public void TakeDamage(int damageAmount)
    {
        if (animator.GetBool("isShouting"))
        {
            if (!fightActivated)
            {
                fightActivated = true;
                wall.SetActive(true);
                healthBar.SetActive(true);
            }
            HP -= damageAmount;
            healthBarScript.SetHealth(HP);
            animator.SetTrigger("damage");
            //Debug.Log("hit animation");

        }
    }

    public void FrayDie()
    {
        fightActivated = false;
        animator.SetTrigger("die");
        animator.SetBool("isAttacking", false);
        Invoke("DeleteFray", 2.6f);
    }

    void DeleteFray()
    {
        //Debug.Log("Fray Dead");
        gameManager.enemyDeadCount++;
        gameManager.UpdateFrayCounter();
        posThoughtsController.GetComponent<PositiveThought>().rightChoice = false;
        wall.SetActive(false);
        Destroy(fray);
    }

    

    //public void ShrinkFray()
    //{
    //    fray.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
    //}
}
