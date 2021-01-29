using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBox : MonoBehaviour
{
    public int currentHealth = 3;

    public void Damage(int damangeAmount)
    {
        currentHealth -= damangeAmount;
        if(currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
