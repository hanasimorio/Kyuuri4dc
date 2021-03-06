using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    [SerializeField] private GameObject ScoreItem;

    [SerializeField] private AudioClip Dead;

    [SerializeField] private AudioClip ShotAudio;

    [SerializeField] private AudioClip Jump;

    private AudioSource AS;

    private bool inside = false;

    private SpriteRenderer SR;

    private bool ultCoolTime = false;

    // Start is called before the first frame update
    void Start()
    {
        EnemyPos = transform;
        rb = gameObject.GetComponent<Rigidbody2D>();
        AS = GetComponent<AudioSource>();
        SR = GetComponent<SpriteRenderer>();
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
            Instantiate(ScoreItem, transform.position, transform.rotation);
            AudioSource.PlayClipAtPoint(Dead, transform.position);
            Destroy(this.gameObject);
        }
        else if(inside && MainManager.instance.ult && !ultCoolTime)
        {
            HP -= 400;
            StartCoroutine(DamageColor());
            ultCoolTime = true;
        }
        else if (!inside && ultCoolTime)
        {
            ultCoolTime = false;
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
            StartCoroutine(DamageColor());

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
        AS.PlayOneShot(Jump);
        yield return new WaitForSeconds(2f);
        rb.AddForce(transform.up * jumpforce);
        AS.PlayOneShot(Jump);
        yield return new WaitForSeconds(2f);
        rb.AddForce(transform.up * jumpforce);
        AS.PlayOneShot(Jump);
        yield return new WaitForSeconds(1.8f);
        horizontalkey = 0f;
        rb.velocity = Vector2.zero;
        RandomAT();
    }

    IEnumerator RightMove()
    {
        horizontalkey = 1;
        yield return new WaitForSeconds(0.5f);
        rb.AddForce(transform.up * jumpforce);
        AS.PlayOneShot(Jump);
        yield return new WaitForSeconds(2f);
        rb.AddForce(transform.up * jumpforce);
        AS.PlayOneShot(Jump);
        yield return new WaitForSeconds(2f);
        rb.AddForce(transform.up * jumpforce);
        AS.PlayOneShot(Jump);
        yield return new WaitForSeconds(1.8f);
        horizontalkey = 0f;
        rb.velocity = Vector2.zero;
        RandomAT();
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
        AS.PlayOneShot(ShotAudio);
    }

    IEnumerator Arrowshot()
    {
        yield return new WaitForSeconds(2f);

        EnemyPos = transform;
        DashPos = EnemyPos.position - Player.transform.position;


        var e = this.gameObject.transform.position;
        var s = e.y + 6;
        if (DashPos.x > 0)
            for (int i = 0; i < 30; i++)
            {
                GameObject ar = Instantiate(arrow) as GameObject;
                int px = Random.Range(-17,-1);?@?@
                var left = e.x + px;
                ar.transform.position = new Vector3(left, s, 0);
                yield return new WaitForSeconds(.2f);
            }
        else if (DashPos.x < 0)
        {
            for (int i = 0; i < 30; i++)
            {
                GameObject ar = Instantiate(arrow) as GameObject;
                int px = Random.Range(1, 17);  
                var right = e.x + px;
                ar.transform.position = new Vector3(right, s, 0);
                yield return new WaitForSeconds(.2f);
            }
        }
        RandomAT();
    }


    IEnumerator Homing()
    {
        yield return new WaitForSeconds(2f);
        Instantiate(HomingBullet, shotpos.position, shotpos.rotation);
        AS.PlayOneShot(ShotAudio);
        yield return new WaitForSeconds(2f);
        Instantiate(HomingBullet, shotpos.position, shotpos.rotation);
        AS.PlayOneShot(ShotAudio);
        yield return new WaitForSeconds(2f);
        Instantiate(HomingBullet, shotpos.position, shotpos.rotation);
        AS.PlayOneShot(ShotAudio);
        yield return new WaitForSeconds(2f);
        RandomAT();


    }


    private void OnBecameVisible()
    {
        inside = true;
    }

    private void OnBecameInvisible()
    {
        inside = false;
    }


    IEnumerator DamageColor()
    {
        SR.color = new Color(1, 0, 0, 1);
        yield return new WaitForSeconds(0.1f);
        SR.color = new Color(1, 1, 1, 1);
    }


}
