using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveScript : MonoBehaviour
{
    enum Status
    {
        GROUND,
        RISE,
        FALL
    }

    [SerializeField] LayerMask groundLayer = default;
    [SerializeField] BulletScript bullet = default;

    float xRate;
    float speed = 5f;
    bool isMove = false;

    float jumpTimer = 0f;
    const float jumpPower = 15.25f;
    const float gravity = 100f;
    bool isJump = false;
    bool jumpKey = false;
    bool jumpKeyLock = false;

    bool isShot = false;

    Rigidbody2D rb;
    Vector2 vect;
    Status status = Status.GROUND;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        xRate = Input.GetAxisRaw("Horizontal");
        if (xRate != 0) {
            isMove = true;
        } else {
            isMove = false;
        }

        if (Input.GetKey("space")) {
            if (!jumpKeyLock) {
                jumpKey = true;
            } else {
                jumpKey = false;
            }
        } else {
            jumpKey = false;
            jumpKeyLock = false;
        }

        if (status == Status.FALL && HitGround()) {
            status = Status.GROUND;
            jumpTimer = 0f;
            jumpKeyLock = true;
        }

        isShot = Input.GetKeyDown(KeyCode.Z);
        if (isShot) {
            var shot = Instantiate(bullet, transform.position, Quaternion.identity);
            shot.SetDirection(transform.localScale.x);
            
        }
    }

    private void FixedUpdate()
    {
        vect = Vector2.zero;

        if (isMove) {
            vect.x = xRate * speed;
            transform.localScale = new Vector2(xRate, 1f);
        } else {
            vect.x = 0f;
        }

        if (status == Status.GROUND && rb.velocity.y < 0f) {
            status = Status.FALL;
            jumpTimer = 0.1f;
        }

        switch (status) {
            case Status.GROUND:
                if (jumpKey) {
                    status = Status.RISE;
                }
                break;

            case Status.RISE:
                jumpTimer += Time.deltaTime;
                if (jumpKey || jumpTimer < 0.03f) {
                    vect.y = jumpPower;
                    vect.y -= gravity * Mathf.Pow(jumpTimer, 2f);
                } else {
                    jumpTimer += Time.deltaTime;
                    vect.y = jumpPower;
                    vect.y -= gravity * Mathf.Pow(jumpTimer, 1.4f);
                }

                if (vect.y < 0f) {
                    status = Status.FALL;
                    vect.y = 0f;
                    jumpTimer = 0.1f;
                }
                break;

            case Status.FALL:
                jumpTimer += Time.deltaTime;
                vect.y = 0f;
                vect.y = -(gravity * Mathf.Pow(jumpTimer, 2f));
                if (vect.y < -15f) {
                    vect.y = -15f;
                }
                break;

            default:
                break;
        }

        rb.velocity = vect;
    }

    private bool HitGround()
    {
        /*
        Debug.DrawLine(transform.position - transform.right * 0.16f - transform.up * 0.35f,
                       transform.position - transform.right * 0.14f - transform.up * 0.45f,
                       Color.blue);
        Debug.DrawLine(transform.position + transform.right * 0.15f - transform.up * 0.35f,
                       transform.position + transform.right * 0.13f - transform.up * 0.45f,
                       Color.blue);
        */

        return Physics2D.Linecast
        (
            transform.position - transform.right * 0.16f - transform.up * 0.35f,
            transform.position - transform.right * 0.15f - transform.up * 0.45f,
            groundLayer
        )
        || Physics2D.Linecast
        (
            transform.position + transform.right * 0.16f - transform.up * 0.35f,
            transform.position + transform.right * 0.15f - transform.up * 0.45f,
            groundLayer
        );
    }
}
