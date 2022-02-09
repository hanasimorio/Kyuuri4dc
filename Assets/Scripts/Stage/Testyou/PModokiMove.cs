using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PModokiMove : MonoBehaviour
{
    Rigidbody2D rbody;
    public float speed = 3;
    float vx;
    public float jumppower = 8;
    bool jumpFlag = false;
    public bool leftFlag;
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        rbody.gravityScale = 1;
        rbody.constraints = RigidbodyConstraints2D.FreezeRotation;
        jumpFlag = false;
        leftFlag = false;
    }

    void Update()
    {
        vx = 0;
        if (Input.GetKey("right"))
        {
            vx = speed;
            leftFlag = false;
        }
        else if (Input.GetKey("left"))
        {
            vx = -speed;
            leftFlag = true;
        }
        if (Input.GetKeyDown("space") && jumpFlag == false)
        {
            jumpFlag = true;
        }
    }
    void FixedUpdate()
    {
        if (jumpFlag == true)
        {
            rbody.AddForce(new Vector2(0, jumppower), ForceMode2D.Impulse);
            jumpFlag = false;
        }
        rbody.velocity = new Vector2(vx, rbody.velocity.y);
    }
}
