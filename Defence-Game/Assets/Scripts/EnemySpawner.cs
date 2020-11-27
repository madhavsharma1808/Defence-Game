using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] float spawnTime;
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] Text ScoreText;
    [SerializeField] AudioClip audioSource;


    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        int score = 0;
        while(true)
        {
            GetComponent<AudioSource>().PlayOneShot(audioSource);
            score++;
            ScoreText.text = "Score :"+score.ToString();
            Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(spawnTime);
        }
    }


}
