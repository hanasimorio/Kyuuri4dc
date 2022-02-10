using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    float speed = 10f;
    float dir;
    Vector2 vect;
    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
