using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public Text healthtext;
    public Transform bulletSpawn;
    public GameObject bullet;

    private void Start()
    {
        currentHealth = maxHealth;
        healthtext.text = " " + currentHealth + "/" + maxHealth;
    }
    private void Update()
    {
        healthtext.text = " " + currentHealth + "/" + maxHealth;
    }

    public void Shoot()
    {
        GameObject projectile = Instantiate(bullet);
        projectile.transform.rotation = bulletSpawn.transform.rotation;
        projectile.transform.position = bulletSpawn.transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            currentHealth = currentHealth - 10;
            if(currentHealth <= 0)
            {
                currentHealth = 0;

            }
        }
    }
}
