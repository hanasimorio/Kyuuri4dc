using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEnemyMove : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private float HP = 100;

    [SerializeField] private float speed = 10;

    [SerializeField] private float jumpforce = 350f;

    private Rigidbody2D rb;

    private float horizontalkey = 0;

    [SerializeField] private GameObject ScoreItem;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        StartCoroutine(Move());
    }

    // Update is called once per frame
    void Update()
    {
        if(horizontalkey > 0)
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
        }
        else if(horizontalkey < 0)
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
        }
        else
        {
            rb.velocity = Vector2.zero;
        }

        if(HP <= 0)
        {
            Instantiate(ScoreItem, transform.position, transform.rotation);
            Destroy(this.gameObject);
        }

    }

    IEnumerator Move()
    {
        horizontalkey = 1;
        yield return new WaitForSeconds(1f);
        rb.AddForce(transform.up * jumpforce);
        yield return new WaitForSeconds(2f);
        horizontalkey = -1;
        yield return new WaitForSeconds(1f);
        rb.AddForce(transform.up * jumpforce);
        yield return new WaitForSeconds(2f);
        horizontalkey = 0;
        yield return new WaitForSeconds(2f);
        StartCoroutine(Move());
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            HP -= 100;
        }
    }

}
