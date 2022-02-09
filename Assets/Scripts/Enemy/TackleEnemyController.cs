using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TackleEnemyController: MonoBehaviour
{

    [SerializeField] private float speed = 10;

    private GameObject Player;

    private Transform EnemyPos;

    private Vector2 DashPos;

    private Rigidbody2D rb;

    private float horizontalkey = 0;

    // Start is called before the first frame update
    void Start()
    {
        EnemyPos = transform;
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (horizontalkey > 0)
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
        }
        else if (horizontalkey < 0)
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Player = collision.gameObject;
            DashPos = EnemyPos.position - Player.transform.position;

            if (Player != null)
            {
                if (DashPos.x > 0)
                {
                    StartCoroutine(LeftMove());
                }
                else if (DashPos.x < 0)
                {
                    StartCoroutine(RightMove());
                }
            }

        }
    }

    IEnumerator LeftMove()
    {
        horizontalkey = -1;
        yield return new WaitForSeconds(1f);
        horizontalkey = 0f;
        StartCoroutine(JudgeTackle());
    }

    IEnumerator RightMove()
    {
        horizontalkey = 1;
        yield return new WaitForSeconds(1f);
        horizontalkey = 0f;
        StartCoroutine(JudgeTackle());
    }

    IEnumerator JudgeTackle()
    {
        EnemyPos = transform;
        DashPos = EnemyPos.position - Player.transform.position;
        yield return new WaitForSeconds(4f);
        if (DashPos.x > 0)
        {
            StartCoroutine(LeftMove());
        }
        else if (DashPos.x < 0)
        {
            StartCoroutine(RightMove());
        }
    }

}
