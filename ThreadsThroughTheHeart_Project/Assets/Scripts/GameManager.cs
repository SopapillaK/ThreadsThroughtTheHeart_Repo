using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int enemyDeadCount;
    public int enemyTotalCount;
    public GameObject winMenuScreen;

    [Header("UI")]
    public Text frayCounter;
    // Start is called before the first frame update
    void Start()
    {
        enemyDeadCount = 0;
        UpdateFrayCounter();
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyDeadCount >= enemyTotalCount)
        {
            Invoke("NextScene", 1);
        }
    }

    public void UpdateFrayCounter()
    {
        frayCounter.text = "Fray: " + enemyDeadCount;
    }

    public void NextScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
