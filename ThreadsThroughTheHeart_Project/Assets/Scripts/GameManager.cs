using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int enemyDeadCount;
    public int enemyTotalCount;
    public GameObject winMenuScreen;
    // Start is called before the first frame update
    void Start()
    {
        enemyDeadCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyDeadCount == enemyTotalCount)
        {
            winMenuScreen.SetActive(true);
        }
    }
}
