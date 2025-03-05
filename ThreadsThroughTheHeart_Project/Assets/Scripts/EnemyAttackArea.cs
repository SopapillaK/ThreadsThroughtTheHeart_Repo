using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackArea : MonoBehaviour
{
    public Animator frayAnimator;
    public GameObject attackArea;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (frayAnimator.GetBool("AttackArea"))
        {
            Invoke("ActivateAttackArea", 1.3f);
            
        }
        else
        {
            attackArea.SetActive(false);
        }
    }

    public void ActivateAttackArea()
    {
        attackArea.SetActive(true);
    }
}
