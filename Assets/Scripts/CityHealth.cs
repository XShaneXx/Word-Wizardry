using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CityHealth : MonoBehaviour
{
    public Slider cityHealthSlider;
    public float health;
    public float maxHealth = 100f;
    [SerializeField] AudioSource soundEffects;
    [SerializeField] AudioClip damageSound;

    private void Start()
    {
        health = maxHealth;
    }

    private void Update() 
    {
        cityHealthSlider.value = health / maxHealth;

        if (health <= 0f)
        {
            SceneManager.LoadScene("GameOverScene");
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(collision.gameObject);
        health -= 10f;
        soundEffects.clip = damageSound;
        soundEffects.Play();
    }
}
