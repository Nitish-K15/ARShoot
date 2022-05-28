using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody rigidBody;
    public GameObject explosion;
    public AudioClip explode;

    private void OnEnable()
    {
        Invoke(nameof(DestroySelf), 2f);
    }
    private void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        rigidBody.velocity = transform.forward * 5f;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            SoundManager.Instance.Play(explode);
            Destroy(other.gameObject);
            var expl = Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(expl, 1);
            DestroySelf();
        }
    }

    void DestroySelf()
    {
        this.gameObject.SetActive(false);
    }
}
