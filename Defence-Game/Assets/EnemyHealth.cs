using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    [SerializeField] int hitPoints = 10;
    private void OnParticleCollision(GameObject other)
    {
        print("shit mate");
        HitEnemy();
        //Destroy(other);
        
    }

    void HitEnemy()
    {
        if (hitPoints > 0)
            hitPoints = hitPoints - 1;
        else if (hitPoints <= 0)
            Destroy(gameObject);

    }
}
