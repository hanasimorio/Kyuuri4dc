using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private Vector3 velo;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        //rb.velocity = GetVelocity(angle) * speed;
        //transform.position += velo * Time.deltaTime;
        //transform.Translate(speed * Time.deltaTime, 0f, 0f);
    }

    /*
    public void Init(float angle, float speed)
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = GetVelocity(angle);
        //velo = transform.TransformDirection(new Vector3(speed, speed, 0f).normalized);
        //Debug.Log(transform.rotation);
        //Debug.Log(velo);
    }

    private static Vector3 GetVelocity(float angle)
    {
        return new Vector3
        (
            Mathf.Cos(angle * Mathf.Deg2Rad),
            Mathf.Sin(angle * Mathf.Deg2Rad),
            0
        );
    }
    */


    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
