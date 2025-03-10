using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositiveThought : MonoBehaviour
{
    public GameObject enemyFray;
    public GameObject frayHolder;
    public AudioSource ac;
    public AudioClip correctPosTho;
    public AudioClip wrong2PosTho;
    public AudioClip wrong3PosTho;
    public float timer = 3;
    public bool rightChoice = false;
    bool correctChoiceAudioPlayed = false;
    bool wrongChoice2AudioPlayed = false;
    bool wrongChoice3AudioPlayed = false;

    [SerializeField]
    private int currentHP;
    private bool madeChoice = false;

    void Update()
    {
        currentHP = enemyFray.GetComponent<Enemy>().HP;

        if (currentHP == 1)
        {
            if (!madeChoice)
            {
                //Debug.Log("timer slow");
                timer -= Time.deltaTime;

                if (frayHolder.name == "Fray1Holder")
                {
                    //Debug.Log("pos1");
                    YCorrect();
                }
                if (frayHolder.name == "Fray2Holder")
                {
                    //Debug.Log("pos2");
                    TCorrect();
                }
                if (frayHolder.name == "Fray3Holder")
                {
                    //Debug.Log("pos3");
                    UCorrect();
                }
                if (frayHolder.name == "Fray4Holder")
                {
                    //Debug.Log("pos2");
                    TCorrect();
                }
                if (frayHolder.name == "Fray5Holder")
                {
                    //Debug.Log("pos2");
                    YCorrect();
                }
                if (frayHolder.name == "Fray6Holder")
                {
                    //Debug.Log("pos2");
                    TCorrect();
                }
            }

            if (timer <= 0 && !madeChoice)
            {
                enemyFray.GetComponent<Enemy>().HP = 5;
                timer = 3;
            }
        }
    }

    void YCorrect()
    {
        if (Input.GetKey(KeyCode.T))
        {
            Debug.Log("T");

            //Its okay to be alone
            madeChoice = true;
            enemyFray.GetComponent<Enemy>().HP = 5;
            timer = 3;

            if (!wrongChoice2AudioPlayed)
            {
                ac.PlayOneShot(wrong2PosTho);
                wrongChoice2AudioPlayed = true;
            }
        }
        if (Input.GetKey(KeyCode.Y))
        {
            Debug.Log("Y");
            //If they leave you they dont love you
            madeChoice = true;
            rightChoice = true;

            if (!correctChoiceAudioPlayed) //This is to prevent the audio from playing for every frame the key is held down
            {
                ac.PlayOneShot(correctPosTho);
                correctChoiceAudioPlayed = true;
            }
        }
        if (Input.GetKey(KeyCode.U))
        {
            Debug.Log("U");

            //You don't need others all you need is yourself
            madeChoice = true;
            enemyFray.GetComponent<Enemy>().HP = 5;
            timer = 3;

            if (!wrongChoice3AudioPlayed)
            {
                ac.PlayOneShot(wrong3PosTho);
                wrongChoice3AudioPlayed = true;
            }
        }
        madeChoice = false;

    }

    void TCorrect()
    {
        if (Input.GetKey(KeyCode.U))
        {
            Debug.Log("U");

            //Its okay to be alone
            madeChoice = true;
            enemyFray.GetComponent<Enemy>().HP = 5;
            timer = 3;

            if (!wrongChoice2AudioPlayed)
            {
                ac.PlayOneShot(wrong2PosTho);
                wrongChoice2AudioPlayed = true;
            }
        }
        if (Input.GetKey(KeyCode.T))
        {
            Debug.Log("T");
            //If they leave you they dont love you
            madeChoice = true;
            rightChoice = true;

            if (!correctChoiceAudioPlayed) //This is to prevent the audio from playing for every frame the key is held down
            {
                ac.PlayOneShot(correctPosTho);
                correctChoiceAudioPlayed = true;
            }
        }
        if (Input.GetKey(KeyCode.Y))
        {
            Debug.Log("Y");

            //You don't need others all you need is yourself
            madeChoice = true;
            enemyFray.GetComponent<Enemy>().HP = 5;
            timer = 3;

            if (!wrongChoice3AudioPlayed)
            {
                ac.PlayOneShot(wrong3PosTho);
                wrongChoice3AudioPlayed = true;
            }
        }
        madeChoice = false;
    }

    void UCorrect()
    {
        if (Input.GetKey(KeyCode.Y))
        {
            Debug.Log("Y");

            madeChoice = true;
            enemyFray.GetComponent<Enemy>().HP = 5;
            timer = 3;
            if (!wrongChoice2AudioPlayed)
            {
                ac.PlayOneShot(wrong2PosTho);
                wrongChoice2AudioPlayed = true;
            }
        }
        if (Input.GetKey(KeyCode.U))
        {
            Debug.Log("U");
            madeChoice = true;
            rightChoice = true;

            if (!correctChoiceAudioPlayed) //This is to prevent the audio from playing for every frame the key is held down
            {
                ac.PlayOneShot(correctPosTho);
                correctChoiceAudioPlayed = true;
            }
        }
        if (Input.GetKey(KeyCode.T))
        {
            Debug.Log("T");

            madeChoice = true;
            enemyFray.GetComponent<Enemy>().HP = 5;
            timer = 3;

            if (!wrongChoice3AudioPlayed)
            {
                ac.PlayOneShot(wrong3PosTho);
                wrongChoice3AudioPlayed = true;
            }
        }
        madeChoice = false;
    }
}
