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
                Debug.Log("T");

                //Its okay to be alone
                madeChoice = true;
                enemyFray.GetComponent<Enemy>().HP = 8;
            }
            if (Input.GetKey(KeyCode.Y))
            {
                Debug.Log("Y");
                //If they leave you they dont love you
                madeChoice = true;
                ac.PlayOneShot(correctPosTho);
                rightChoice = true;
            }
            if (Input.GetKey(KeyCode.U))
            {
                Debug.Log("U");

                //You don't need others all you need is yourself
                madeChoice = true;
                enemyFray.GetComponent<Enemy>().HP = 8;
            }
            /*
            if (gameObject.tag == "Enemy1")
            {
                if (Input.GetKey(KeyCode.T))
                {
                    Debug.Log("T");

                    //Its okay to be alone
                    madeChoice = true;
                    enemyFray.GetComponent<Enemy>().HP = 8;
                }
                if (Input.GetKey(KeyCode.Y))
                {
                    Debug.Log("Y");
                    //If they leave you they dont love you
                    madeChoice = true;
                    //enemyFray.GetComponent<Enemy>().HP = 0;
                    ac.PlayOneShot(correctPosTho);
                    rightChoice = true;
                }
                if (Input.GetKey(KeyCode.U))
                {
                    Debug.Log("U");

                    //You don't need others all you need is yourself
                    madeChoice = true;
                    enemyFray.GetComponent<Enemy>().HP = 8;
                }
            }
            
             if (gameObject.tag == "Enemy2")
            {
                if (Input.GetKey(KeyCode.T))
                {
                    Debug.Log("T");
                    //Its okay to let people down
                    madeChoice = true;
                    //enemyFray.GetComponent<Enemy>().HP = 0;
                    ac.PlayOneShot(correctPosTho);
                    rightChoice = true;
                }
                if (Input.GetKey(KeyCode.Y))
                {
                    Debug.Log("Y");

                    //That's a part of life you have to keep moving
                    madeChoice = true;
                    enemyFray.GetComponent<Enemy>().HP = 8;
                }
                if (Input.GetKey(KeyCode.U))
                {
                    Debug.Log("U");

                    //You don't have to put others feelings above your own
                    madeChoice = true;
                    enemyFray.GetComponent<Enemy>().HP = 8;
                }
            }

            if (gameObject.tag == "Enemy3")
            {
                if (Input.GetKey(KeyCode.T))
                {
                    Debug.Log("T");

                    //Saying no is a part of life
                    madeChoice = true;
                    enemyFray.GetComponent<Enemy>().HP = 8;
                }
                if (Input.GetKey(KeyCode.Y))
                {
                    Debug.Log("Y");

                    //You shouldn't let others walk all over you
                    madeChoice = true;
                    enemyFray.GetComponent<Enemy>().HP = 8;
                }
                if (Input.GetKey(KeyCode.U))
                {
                    Debug.Log("U");

                    //You're not a bad person for saying no
                    madeChoice = true;
                    //enemyFray.GetComponent<Enemy>().HP = 0;
                    ac.PlayOneShot(correctPosTho);
                    rightChoice = true;
                }
            }

            if (gameObject.tag == "Enemy4")
            {
                if (Input.GetKey(KeyCode.T))
                {
                    Debug.Log("T");
                    //You don't have to be everything to everyone
                    madeChoice = true;
                    //enemyFray.GetComponent<Enemy>().HP = 0;
                    ac.PlayOneShot(correctPosTho);
                    rightChoice = true;
                }
                if (Input.GetKey(KeyCode.Y))
                {
                    Debug.Log("Y");

                    //You can't dwell on things you can't control
                    madeChoice = true;
                    enemyFray.GetComponent<Enemy>().HP = 8;
                }
                if (Input.GetKey(KeyCode.U))
                {
                    Debug.Log("U");

                    //Other peoples happiness doesnt need to affect your own
                    madeChoice = true;
                    enemyFray.GetComponent<Enemy>().HP = 8;
                }
            }

            if (gameObject.tag == "Enemy5")
            {
                if (Input.GetKey(KeyCode.T))
                {
                    Debug.Log("T");

                    //Did anyone ask you to do that?
                    madeChoice = true;
                    enemyFray.GetComponent<Enemy>().HP = 8;
                }
                if (Input.GetKey(KeyCode.Y))
                {
                    Debug.Log("Y");
                    //You should never come second in your own life
                    madeChoice = true;
                    //enemyFray.GetComponent<Enemy>().HP = 0;
                    ac.PlayOneShot(correctPosTho);
                    rightChoice = true;
                }
                if (Input.GetKey(KeyCode.U))
                {
                    Debug.Log("U");

                    //If you put everyone else first, then who is putting you first?
                    madeChoice = true;
                    enemyFray.GetComponent<Enemy>().HP = 8;
                }
            }

            if (gameObject.tag == "Enemy6")
            {
                if (Input.GetKey(KeyCode.T))
                {
                    Debug.Log("T");
                    //What you do doesn't determine your worth
                    madeChoice = true;
                    //enemyFray.GetComponent<Enemy>().HP = 0;
                    ac.PlayOneShot(correctPosTho);
                    rightChoice = true;
                }
                if (Input.GetKey(KeyCode.Y))
                {
                    Debug.Log("Y");

                    //There's so much more you're good for
                    madeChoice = true;
                    enemyFray.GetComponent<Enemy>().HP = 8;
                }
                if (Input.GetKey(KeyCode.U))
                {
                    Debug.Log("U");

                    //No one is going to judge you for what you can and can't handle
                    madeChoice = true;
                    enemyFray.GetComponent<Enemy>().HP = 8;
                }
            }
             */

            if (timer <= 0 && !madeChoice)
            {
                enemyFray.GetComponent<Enemy>().HP = 8;
            }
        }
    }
}
