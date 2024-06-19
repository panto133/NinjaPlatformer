using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttacks : MonoBehaviour
{
    [SerializeField]
    private GameObject kunai;
    [SerializeField]
    private Image maskImage;

    private GameObject clone;

    private float cooldown = 3f;
    private float timer = 0;
    private bool onCooldown = false;

    private void Update()
    {
        if(Input.GetMouseButtonDown(1) && !onCooldown)
        {
            Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            clone = Instantiate(kunai, transform.position, Quaternion.identity) as GameObject;
            clone.transform.rotation = Quaternion.Euler(0, 0, 90 + angle);
            onCooldown = true;
            maskImage.fillAmount = 1f;
        }
        else if(Input.GetMouseButtonDown(1) && onCooldown)
        {
            if (clone == null)
                return;
            transform.position = clone.transform.position;
            Destroy(clone);
            timer = 0;
            onCooldown = false;
            maskImage.fillAmount = 0;
        }
        if(onCooldown)
        {
            timer+=Time.deltaTime;
            maskImage.fillAmount -= Time.deltaTime / cooldown;
            if(timer>=cooldown)
            {
                timer = 0;
                onCooldown = false;
            }
        }

    }
}
