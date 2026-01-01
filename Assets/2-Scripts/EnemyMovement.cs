using System;
using UnityEngine;
using UnityEngine.Serialization;

public class EnemyMovement : MonoBehaviour
{
    private Rigidbody2D _rb;
    [SerializeField] private float moveSpeed = 1f;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        _rb.linearVelocity = new Vector2 (moveSpeed, _rb.linearVelocity.y);
        print(_rb.linearVelocity);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Platforms"))
        {
            print(other.name);
            moveSpeed = -moveSpeed;
            EnemyFlip();
        }
    }

    private void EnemyFlip()
    {
        transform.localScale = new Vector3(-Mathf.Sign(_rb.linearVelocity.x), 1f, 1f);
    }
}
