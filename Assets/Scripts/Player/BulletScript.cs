using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    float speed = 12f;
    float dir;
    float timer = 0f;
    Vector2 vect;
    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 0.5f) {
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        vect.x = dir * speed;
        rb.velocity = vect;
    }

    public void SetDirection(float direction)
    {
        dir = direction;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Enemy") {
            Destroy(gameObject);
        }
    }
}
