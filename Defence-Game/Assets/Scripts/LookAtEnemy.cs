using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtEnemy : MonoBehaviour
{
    [SerializeField] Transform lookingObject;
    [SerializeField] Transform observingObject;
    [SerializeField] float attackRange = 30f;
    [SerializeField] ParticleSystem projectylePath;
    public Block standingBlock;
    private void Update()
    {

        EnemyHealth[] enemies = FindObjectsOfType<EnemyHealth>();
        if (enemies.Length == 0)
            return;
        Transform nearestEnemy = enemies[0].transform;
        foreach (EnemyHealth enemyHealth in enemies)
        {
            nearestEnemy = CheckEnemyDistance(enemyHealth.transform, nearestEnemy.transform);
        }
        observingObject = nearestEnemy;
        if (observingObject)
        {
            lookingObject.LookAt(observingObject);
            Fire();
        }
        else
        {
            Shoot(false);
        }
    }
    Transform CheckEnemyDistance(Transform A, Transform B)
    {
        return Vector3.Distance(transform.position, A.position) > Vector3.Distance(transform.position, B.position) ? B : A;
    }

   void Fire()
    {
        float distanceToEnemy = Vector3.Distance(observingObject.transform.position, gameObject.transform.position);
        if (distanceToEnemy <= attackRange)
            Shoot(true);
        else
            Shoot(false);
    }

    void Shoot(bool isShoot)
    {
        ParticleSystem.EmissionModule emmisionModule = projectylePath.emission;
        emmisionModule.enabled = isShoot;
    }

}
