using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TackleEnemyController: MonoBehaviour
{

    [SerializeField] private float HP = 100;

    [SerializeField] private float speed = 10;

    private GameObject Player;

    private Transform EnemyPos;

    private Vector2 DashPos;

    private Rigidbody2D rb;

    private float horizontalkey = 0;

    [SerializeField] private GameObject Collider;

    private bool FindPlayer = false;

    [SerializeField] private GameObject ScoreItem;

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

        if(HP <= 0)
        {
            Instantiate(ScoreItem, transform.position, transform.rotation);
            Destroy(this.gameObject);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player")&&!FindPlayer)
        {
            Player = collision.gameObject;
            DashPos = EnemyPos.position - Player.transform.position;
            FindPlayer = true;
            Destroy(Collider);

            if (Player != null)
            {
                FindPlayer = true;
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
        else if(collision.gameObject.tag == "Bullet" && FindPlayer)
        {
            HP -= 50;
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
        yield return new WaitForSeconds(4f);
        EnemyPos = transform;
        DashPos = EnemyPos.position - Player.transform.position;
        
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
