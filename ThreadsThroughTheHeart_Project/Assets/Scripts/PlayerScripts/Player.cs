using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int health;
    public int maxHealth;
    public GameObject loseMenuScreen;
    public HealthBar healthBar;
    public AudioSource audioSource;
    public AudioClip hurtSound;
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    public void OnTriggerEnter (Collider other)
    {
        if (other.tag == "AttackArea")
        {
            PlayerTakeDamage(1);
        }
    }

    public void PlayerTakeDamage(int amount)
    {
        health -= amount;
        healthBar.SetHealth(health);
        audioSource.PlayOneShot(hurtSound);

        if (health <= 0)
        {
            loseMenuScreen.SetActive(true);
        }
    }
}
