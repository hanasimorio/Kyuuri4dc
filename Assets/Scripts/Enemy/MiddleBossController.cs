using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiddleBossController : MonoBehaviour
{

    [SerializeField] private float HP = 200;

    [SerializeField] private float speed = 10;

    private GameObject Player;

    private Transform EnemyPos;

    private Vector2 DashPos;

    private Rigidbody2D rb;

    private float horizontalkey = 0;

    [SerializeField] private float jumpforce = 300f;

    [SerializeField] Transform shotpos;

    [SerializeField] private GameObject Bullet;

    [SerializeField] private GameObject arrow;

    [SerializeField] private GameObject HomingBullet;

    private bool findPlayer = false;

    [SerializeField] private GameObject JudgeCollider;

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
        /* else
         {
             rb.velocity = Vector2.zero;
         }*/

        if(HP <= 0)
        {
            Destroy(this.gameObject);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player" && !findPlayer)
        {
            Player = collision.gameObject;
            RandomAT();
            findPlayer = true;
            Destroy(JudgeCollider);

        }
        else if (collision.gameObject.CompareTag("Bullet") && findPlayer)
        {
            HP -= 50;

            Debug.Log(HP);

        }


    }

    public void RandomAT()
    {
        if (Player != null)
        {
            var RandomAttack = Random.Range(0, 4);
            switch (RandomAttack)
            {
                case 0:
                    StartCoroutine(JudgeTackle());
                    break;
                case 1:
                    StartCoroutine(FiveShot());
                    break;

                case 2:
                    StartCoroutine(Arrowshot());
                    break;

                case 3:
                    StartCoroutine(Homing());
                    break;

            }
        }
    }




    IEnumerator LeftMove()
    {
        horizontalkey = -1;
        yield return new WaitForSeconds(0.5f);
        rb.AddForce(transform.up * jumpforce);
        yield return new WaitForSeconds(2f);
        rb.AddForce(transform.up * jumpforce);
        yield return new WaitForSeconds(2f);
        rb.AddForce(transform.up * jumpforce);
        yield return new WaitForSeconds(1.8f);
        horizontalkey = 0f;
        rb.velocity = Vector2.zero;
        RandomAT();
    }

    IEnumerator RightMove()
    {
        horizontalkey = 1;
        yield return new WaitForSeconds(1f);
        horizontalkey = 0f;
        RandomAT();
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

    IEnumerator FiveShot()
    {
        yield return new WaitForSeconds(1f);
        Shot();
        yield return new WaitForSeconds(1f);
        Shot();
        yield return new WaitForSeconds(1f);
        Shot();
        yield return new WaitForSeconds(1f);
        Shot();
        yield return new WaitForSeconds(1f);
        Shot();
        yield return new WaitForSeconds(2f);
        RandomAT();
    }

    private void Shot()
    {
        var pos = shotpos.transform.position;

        var t = Instantiate(Bullet) as GameObject;

        t.transform.position = pos;

        Vector2 vec = Player.transform.position - pos;

        t.GetComponent<Rigidbody2D>().velocity = vec;
    }

    IEnumerator Arrowshot()
    {
        var e = this.gameObject.transform.position;
        var s = e.y + 6;
        for (int i = 0; i < 30; i++)
        {
            GameObject ar = Instantiate(arrow) as GameObject;
            int px = Random.Range(-9, 10);　　//ボスの設置場所によって変更する必要がある！！！！
            ar.transform.position = new Vector3(px, s, 0);
            yield return new WaitForSeconds(.5f);
        }
        RandomAT();
    }


    IEnumerator Homing()
    {
        yield return new WaitForSeconds(2f);
        Instantiate(HomingBullet, shotpos.position, shotpos.rotation);
        yield return new WaitForSeconds(2f);
        Instantiate(HomingBullet, shotpos.position, shotpos.rotation);
        yield return new WaitForSeconds(2f);
        Instantiate(HomingBullet, shotpos.position, shotpos.rotation);
        yield return new WaitForSeconds(2f);
        RandomAT();


    }
}
