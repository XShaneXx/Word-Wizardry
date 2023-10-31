using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CityHealth : MonoBehaviour
{
    [SerializeField] TMP_Text cityHealthText;
    float health;

    private void Start()
    {
        health = 100;
        cityHealthText.text = "Health: " + health;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(collision.gameObject);
        health -=100;
        cityHealthText.text = "Health: " + health;
    }
}
