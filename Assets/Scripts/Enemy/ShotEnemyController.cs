using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotEnemyController : MonoBehaviour
{

    [SerializeField] private float HP = 100;

    [SerializeField] private GameObject bullet;

    [SerializeField] private Transform shotpos;

    [SerializeField] private float jumpforce = 300f;

    [SerializeField] private GameObject Col;

    private bool findplayer = false;

    private Rigidbody2D rb;

    [SerializeField] private GameObject ScoreItem;


    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(HP <= 0)
        {
            Instantiate(ScoreItem, transform.position, transform.rotation);
            Destroy(this.gameObject);
        }
    }

    IEnumerator Attack()
    {
        yield return new WaitForSeconds(2f);
        Instantiate(bullet, shotpos.position, shotpos.rotation);
        yield return new WaitForSeconds(1f);
        Instantiate(bullet, shotpos.position, shotpos.rotation);
        yield return new WaitForSeconds(1f);
        rb.AddForce(transform.up * jumpforce);
        yield return new WaitForSeconds(0.5f);
        Instantiate(bullet, shotpos.position, shotpos.rotation);
        yield return new WaitForSeconds(3f);
        StartCoroutine(Attack());

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !findplayer)
        {
            StartCoroutine(Attack());
            findplayer = true;
            Destroy(Col);

        }
        else if (collision.gameObject.tag == "Bullet" && findplayer)
        {
            HP -= 50;
        }

    }

}
