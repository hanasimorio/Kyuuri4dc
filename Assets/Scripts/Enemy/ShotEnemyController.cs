using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotEnemyController : MonoBehaviour
{

    [SerializeField] private GameObject bullet;

    [SerializeField] private Transform shotpos;

    [SerializeField] private float jumpforce = 300f;

    private Rigidbody2D rb;


    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        StartCoroutine(Attack());
    }

    // Update is called once per frame
    void Update()
    {
        
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

}
