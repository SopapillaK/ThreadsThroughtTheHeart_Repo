using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int health;
    public int maxHealth = 3;
    public GameObject loseMenuScreen;
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    public void OnTriggerEnter (Collider other)
    {
        if (other.tag == "Enemy")
        {
            PlayerTakeDamage(1);
        }
    }

    public void PlayerTakeDamage(int amount)
    {
        health -= amount;
        
        if (health <= 0)
        {
            loseMenuScreen.SetActive(true);
        }
    }
}
