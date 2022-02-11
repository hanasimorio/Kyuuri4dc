using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot02EnemyController : MonoBehaviour
{

    [SerializeField] private float HP = 100;
    private GameObject player = null;
    
    public GameObject tama;

    [SerializeField] GameObject Col;

    private bool findplayer = false;
  
    [SerializeField] private float targetTime = 1.0f;
    private float currentTime = 0;

    [SerializeField] private GameObject ScoreItem;

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            currentTime += Time.deltaTime;
            if (targetTime < currentTime)
            {
                currentTime = 0;

                var pos = this.gameObject.transform.position;

                var t = Instantiate(tama) as GameObject;

                t.transform.position = pos;

                Vector2 vec = player.transform.position - pos;

                t.GetComponent<Rigidbody2D>().velocity = vec;
            }
        }

        if(HP <= 0)
        {
            Instantiate(ScoreItem, transform.position, transform.rotation);
            Destroy(this.gameObject);
        }


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !findplayer)
        {
            player = collision.gameObject;
            findplayer = true;
            Destroy(Col);

        }
        else if (collision.gameObject.tag == "Bullet" && findplayer)
        {
            HP -= 50;
        }

    }

}
