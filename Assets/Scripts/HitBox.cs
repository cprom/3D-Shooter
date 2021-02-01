using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBox : MonoBehaviour
{
    public int currentHealth = 3;
    public ParticleSystem explosionParticle;
   

    public void Damage(int damangeAmount)
    {
        currentHealth -= damangeAmount;
        if(currentHealth <= 0)
        {
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
            Destroy(gameObject);
            
            
        }
    }
}
