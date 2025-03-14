using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAttackArea : MonoBehaviour
{
    public Animator playerAnimator;
    public GameObject weaponAttackArea;

    void Update()
    {
        if (playerAnimator.GetBool("WeaponAttackArea"))
        {
            Invoke("ActivateWeaponAttackArea", 0.3f);
        }
        else
        {
            weaponAttackArea.SetActive(false);
        }
    }

    public void ActivateWeaponAttackArea()
    {
        weaponAttackArea.SetActive(true);
    }
}
