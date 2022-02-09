using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveScript : MonoBehaviour
{
    [SerializeField] private GameObject bullet = default;
    [SerializeField] private float speed = default;

    private float xSpeed, ySpeed;
    private bool isShot;
    private Rigidbody2D rb;
    private Vector2 dir;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        xSpeed = Input.GetAxisRaw("Horizontal");
        ySpeed = Input.GetAxisRaw("Vertical");
        isShot = Input.GetKey("space");
        if (isShot) {
            Instantiate(bullet, transform.position, Quaternion.identity);
        }
    }

    private void FixedUpdate()
    {
        dir = new Vector2(xSpeed, ySpeed).normalized;
        rb.velocity = dir * speed;
    }
}
