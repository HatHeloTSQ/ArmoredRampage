using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10;
    public float damage = 5;
    public float maxDistance = 10;

    Vector2 startPosition;
    float conquaredDistance = 0;
    Rigidbody2D rb2d;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    public void Initialize()
    {
        startPosition = transform.position;
        rb2d.velocity = transform.up * speed;
    }

    private void Update()
    {
        conquaredDistance = Vector2.Distance(transform.position, startPosition);
        if (conquaredDistance > maxDistance)
        {
            Destroy(gameObject);
        }
    }

    private void DisableObject()
    {
        rb2d.velocity = Vector2.zero;
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collided" + collision.name );

        var damagable = collision.GetComponent<Damagable>();
        if (damagable != null)
        {
            damagable.Hit(damage);
        }

        Destroy(gameObject);
    }
}
