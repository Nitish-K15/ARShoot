using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int maxHealth = 100;
    public int ammo = 7;
    public int currentHealth;
    public Text healthtext;
    public Text ammoText;
    public Transform bulletSpawn;
    public GameObject bullet;
    public Animator faceAnimate;
    public AudioClip hit,shoot,death,reload;
    public GameObject panel,gameOver;
    public ParticleSystem muzzleFlash1,muzzleFlash2,flame,smoke;

    private void Start()
    {
        currentHealth = maxHealth;
        healthtext.text = " " + currentHealth;
    }
    private void Update()
    {
        healthtext.text = " " + currentHealth;
        ammoText.text = " " + ammo;
    }

    public void Shoot()
    {
        if (ammo >0)
        {
            SoundManager.Instance.Play(shoot);
            //GameObject projectile = Instantiate(bullet);
            GameObject projectile = ObjectPool.SharedInstance.GetPooledObject();
            if (projectile != null)
            {
                projectile.transform.rotation = bulletSpawn.transform.rotation;
                projectile.transform.position = bulletSpawn.transform.position;
                projectile.SetActive(true);
            }
            muzzleFlash1.Play();
            muzzleFlash2.Play();
            smoke.Play();
            flame.Play();
          //  projectile.transform.rotation = bulletSpawn.transform.rotation;
           // projectile.transform.position = bulletSpawn.transform.position;
            ammo = ammo - 1;
            if (ammo <= 0)
                ammo = 0;
        }
        else
        {
            StartCoroutine(Reload());
        }
    }

    IEnumerator Reload()
    {
        yield return new WaitForSeconds(1f);
        SoundManager.Instance.Play(reload);
        ammo = 7;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            currentHealth = currentHealth - 5;
            StartCoroutine(TakeDamage());
            if(currentHealth <= 75)
            {
                faceAnimate.SetBool("75",true);
            }
            if(currentHealth <= 50)
            {
                faceAnimate.SetBool("50", true);
                faceAnimate.SetBool("75", false);
            }
            if (currentHealth <= 25)
            {
                faceAnimate.SetBool("25", true);
                faceAnimate.SetBool("50", false);
            }
            if (currentHealth <= 0)
            {
                currentHealth = 0;
                faceAnimate.SetBool("0", true);
                SoundManager.Instance.Play(death);
                StartCoroutine(PlayerDeath());
            }
        }
    }

    IEnumerator PlayerDeath()
    {
        Time.timeScale = 0;
        gameOver.SetActive(true);
        yield return null;
    }

    IEnumerator TakeDamage()
    {
        panel.SetActive(true);
        SoundManager.Instance.Play(hit);
        yield return new WaitForSeconds(0.1f);
        panel.SetActive(false);
    }
}
