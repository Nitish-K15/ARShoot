using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody rigidBody;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        Invoke(nameof(DestroySelf), 2f);
    }

    private void Update()
    {
        rigidBody.velocity = transform.forward * 5f;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }

    void DestroySelf()
    {
        Destroy(gameObject);
    }
}
