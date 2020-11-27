using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int health = 10;
    [SerializeField] int healthDecrement = 1;
    [SerializeField] Text healthText;
    [SerializeField] AudioClip playerDamageAudioClip;

    private void Start()
    {
        healthText.text = "Players Health :" + health.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        GetComponent<AudioSource>().PlayOneShot(playerDamageAudioClip);
        health = health - healthDecrement;
        healthText.text = "Players Health :" + health.ToString();
    }
}
