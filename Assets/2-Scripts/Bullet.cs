using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody2D rbBullet;
    Rigidbody2D rbPlayer;
    [SerializeField] float speed = 10f;
    PlayerMovement player;
    float xSpeed;
    void Start()
    {
        rbBullet = GetComponent<Rigidbody2D>();
        player = FindAnyObjectByType<PlayerMovement>();
        rbPlayer = player.GetComponent<Rigidbody2D>();
        xSpeed = player.transform.localScale.x * speed;
    }

    void Update()
    {
        rbBullet.linearVelocity = new Vector2(xSpeed, rbBullet.linearVelocity.y);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
        }
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Destroy(gameObject);
    }
}
