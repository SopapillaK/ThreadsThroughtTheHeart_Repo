using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositiveThought : MonoBehaviour
{
    public GameObject enemyFray;
    public AudioSource ac;
    public AudioClip correctPosTho;
    public float timer = 3;
    public bool rightChoice = false;

    [SerializeField]
    public int currentHP;
    private bool madeChoice = false;

    void Update()
    {
        currentHP = enemyFray.GetComponent<Enemy>().HP;

        if (currentHP == 1)
        {
            if (!madeChoice)
            {
                timer -= Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.T))
            {
                //Its okay to be alone
                madeChoice = true;
                enemyFray.GetComponent<Enemy>().HP = 8;
            }
            else if (Input.GetKey(KeyCode.Y))
            {
                //If they leave you they dont love you
                madeChoice = true;
                //enemyFray.GetComponent<Enemy>().HP = 0;
                ac.PlayOneShot(correctPosTho);
                rightChoice = true;
            }
            else if (Input.GetKey(KeyCode.U))
            {
                //You don't need others all you need is yourself
                madeChoice = true;
                enemyFray.GetComponent<Enemy>().HP = 8;
            }

            if (timer <= 0 && !madeChoice)
            {
                enemyFray.GetComponent<Enemy>().HP = 8;
            }
        }
    }
}
