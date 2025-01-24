using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponCollisionDetection : MonoBehaviour
{
    public WeaponController wc;
    public int damageAmount = 1;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy" && wc.isAttacking)
        {
            other.GetComponent<Enemy>().TakeDamage(damageAmount);
        }
    }
}
