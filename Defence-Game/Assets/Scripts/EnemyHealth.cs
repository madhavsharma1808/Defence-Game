using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    [SerializeField] int hitPoints = 10;
    [SerializeField] ParticleSystem hitEnemy;
    [SerializeField] ParticleSystem deathEnemy;
    [SerializeField] AudioClip enemyDamageAudioClip;
    [SerializeField] AudioClip enemyHealthAudioClip;
   
    private void OnParticleCollision(GameObject other)
    {
        HitEnemy();
    }

   

    void HitEnemy()
    {
        if (hitPoints > 0)
        {
            hitEnemy.Play();
            hitPoints = hitPoints - 1;
            GetComponent<AudioSource>().PlayOneShot(enemyHealthAudioClip);
        }
        else if (hitPoints <= 0)
        {
            var vfx = Instantiate(deathEnemy,transform.position, Quaternion.identity);
            vfx.Play();
            Destroy(vfx.gameObject, vfx.main.duration);
            AudioSource.PlayClipAtPoint(enemyDamageAudioClip, Camera.main.transform.position);
            Destroy(gameObject);
        }

    }
}
