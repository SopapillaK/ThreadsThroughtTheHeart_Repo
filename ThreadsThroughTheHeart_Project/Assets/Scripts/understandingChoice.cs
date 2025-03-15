using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class understandingChoice : MonoBehaviour
{
    public GameObject TextBox;
    //public GameObject QuestionText;
    //public GameObject Choice1;
    //public GameObject Choice2;
    //public GameObject Choice3;
    public GameObject Understandings;
    public int ChoiceMade;
    public static int UnderstandingPoints = 0;
    public Text Pointstext;
    private int bestChoice = 5;
    private int goodChoice = 3;
    private int okayChoice = 1;

    public void SavePoints()
    {
        PlayerPrefs.SetInt("UnderstandingPts", UnderstandingPoints);
        PlayerPrefs.Save();
        
        //if (Memory1.isComplete)
        //{
            //Choice1.SetActive(true);
            //Choice2.SetActive(true);
            //Choice3.SetActive(true);
        //}
        //else if(Memory2.isComplete)
        //{
            //Choice1.SetActive(false);
            //Choice2.SetActive(false);
            //Choice3.SetActive(false);
            //Choice 4-6 is true
        //}
    }

    public void ChoiceOption1()
    {
        //TextBox.GetComponent<Text>().text = "She had no one she felt she could rely on";
        ChoiceMade = 1;
        UnderstandingPoints = UnderstandingPoints + okayChoice;
    }

    public void ChoiceOption2()
    {
        TextBox.GetComponent<Text>().text = "How to Heal: Avoid Binary Thinking (make a positive spin)";
        ChoiceMade = 2;
        UnderstandingPoints = UnderstandingPoints + bestChoice;
    }

    public void ChoiceOption3()
    {
        //TextBox.GetComponent<Text>().text = "She never properly established boundaries for herself";
        ChoiceMade = 3;
        UnderstandingPoints = UnderstandingPoints + goodChoice;
    }

    public void Choices()
    {
        if (ChoiceMade == 2)
        {
            Understandings.SetActive(false);
            //Time.timeScale = 1;

            Invoke("GoodEndingVid", 5f);

        }
        else if (ChoiceMade == 3)
        {
            Understandings.SetActive(false);
            //Time.timeScale = 1;

            Invoke("BadEndingVid", 2f);

        }
        else if (ChoiceMade == 1)
        {
            Understandings.SetActive(false);
            //Time.timeScale = 1;

            Invoke("BadEndingVid", 2f);
        }
    }

    void GoodEndingVid()
    {
        SceneManager.LoadScene("GoodEnding");
    }

    void BadEndingVid()
    {
        SceneManager.LoadScene("BadEnding");
    }

    public void LoadPoints()
    {
        UnderstandingPoints = PlayerPrefs.GetInt("UnderstandingPts", 0);
    }

    void Start()
    {
        //LoadPoints();
        UnderstandingPoints = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Choices();
        Pointstext.text = UnderstandingPoints + "/15";
        SavePoints();

    }
}
