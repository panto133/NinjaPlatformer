using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KunaiLogic : MonoBehaviour
{
    public float speed = 10f;
    private void Start()
    {
        Invoke("SelfDestruction", 3f);
    }
    private void Update()
    {
        float zRotation = transform.eulerAngles.z;
        Vector3 direction = Quaternion.Euler(0, 0, 90 + zRotation) * Vector3.left;
        transform.position += direction * speed * Time.deltaTime;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null)
        {
            if (collision.CompareTag("Enemy"))
            {
                collision.GetComponent<EnemyAI>().TakeDamage(30);
                Destroy(gameObject);
            }
        }
    }
    private void SelfDestruction()
    {
        Destroy(gameObject);
    }
}
