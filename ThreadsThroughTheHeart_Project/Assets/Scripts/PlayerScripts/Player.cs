using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int health;
    public int maxHealth;
    public GameObject loseMenuScreen;
    public HealthBar healthBar;
    public GameObject redFlash;
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
            CameraShake.Shake(duration: 3f, strength: 1.5f);
        }
    }

    public void PlayerTakeDamage(int amount)
    {
        health -= amount;
        healthBar.SetHealth(health);
        audioSource.PlayOneShot(hurtSound);
        redFlash.SetActive(true);
        Invoke("TurnOffRedFlash", 0.2f);

        if (health <= 0)
        {
            loseMenuScreen.SetActive(true);
        }
    }

    void TurnOffRedFlash()
    {
        redFlash.SetActive(false);
    }

    public void PlayerHeal(int amount)
    {
        health += amount;
        healthBar.SetHealth(health);
    }
}
