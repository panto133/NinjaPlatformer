using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    private Slider healthSlider;
    private float health = 100;

    public void TakeDamage(int damage)
    {
        health -= damage;
        healthSlider.value -= health;
        if (health <= 0)
            Destroy(transform.gameObject);
    }
}
