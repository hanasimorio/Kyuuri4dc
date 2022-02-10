using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingController : MonoBehaviour
{
    private GameObject player; 
    [SerializeField] private float Speed;  Å@ 
    [SerializeField] private float limitSpeed;      
    private Rigidbody2D rb;                        
    private Transform bulletTrans;               

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
        bulletTrans = GetComponent<Transform>();
    }

    private void FixedUpdate()
    {
        if (player != null)
        {
            Vector3 vector3 = player.transform.position - bulletTrans.position;
            rb.AddForce(vector3.normalized * Speed);

            float speedXTemp = Mathf.Clamp(rb.velocity.x, -limitSpeed, limitSpeed);
            float speedYTemp = Mathf.Clamp(rb.velocity.y, -limitSpeed, limitSpeed);
            rb.velocity = new Vector3(speedXTemp, speedYTemp);
        }
        else
            Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player" || collision.gameObject.tag == "Bullet")
        {
            Destroy(this.gameObject);
        }
    }


}