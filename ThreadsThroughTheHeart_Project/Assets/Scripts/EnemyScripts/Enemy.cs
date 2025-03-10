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
    bool timeSlow = false;



    public GameManager gameManager;

    void Awake()
    {
        wayPointTag = wayPoints.tag;
        //enemyName = gameObject.name;

        FrayPatrolState frayPatrolState = animator.GetBehaviour<FrayPatrolState>();
        frayPatrolState.wayPointList = wayPointTag;
    }
    void Update()
    {
        //Activate wall
        if (fightActivated == true)
        {
            wall.SetActive(true);
        }
        else
        {
            wall.SetActive(false);
        }

        //Positivethought QTE
        if (HP == 1 && !timeSlow)
        {
            Debug.Log("time slow");
            Time.timeScale = 0.2f;
            timeSlow = true;
            postProc.SetActive(true);
            posOptions.SetActive(true);
        }
        else if (HP == 5)
        {
            if (timeSlow)
            {
                Debug.Log("untime slow 1");

                Time.timeScale = 1.0f;
                timeSlow = false;
                postProc.SetActive(false);
                posOptions.SetActive(false);
            }
            
        }

        if (posThoughtsController.GetComponent<PositiveThought>().rightChoice == true)
        {
            //Debug.Log("untime slow 2");

            Time.timeScale = 1.0f;
            postProc.SetActive(false);
            posOptions.SetActive(false);

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
            fightActivated = true;
            HP -= damageAmount;
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
        Destroy(fray);
    }

    

    //public void ShrinkFray()
    //{
    //    fray.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
    //}
}
