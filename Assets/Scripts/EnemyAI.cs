using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyAI : MonoBehaviour
{
    private Transform player;
    private float health = 50f;
    [SerializeField]
    private float speed=10f;
    [SerializeField]
    private Slider healthSlider;
    private void Start()
    {
        player = GameObject.Find("Player").transform;
    }
    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        healthSlider.transform.position = Camera.main.WorldToScreenPoint(transform.position + new Vector3(0, .75f, 0));
    }
    private void OnDestroy()
    {
        Destroy(healthSlider.gameObject);
    }
    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
            Destroy(gameObject);
        healthSlider.value -= damage;
    }
}
