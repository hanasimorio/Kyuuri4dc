using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreItemController : MonoBehaviour
{

    [SerializeField] private int myscore;

    [SerializeField] private AudioClip AC;

    private AudioSource AS;

    private void Start()
    {
        AS = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (MainManager.instance != null)
        {
            if (collision.gameObject.tag == "Player")
            {
                MainManager.instance.UpScore(myscore);
                AS.PlayOneShot(AC);
                Destroy(this.gameObject);
                
            }
        }
    }


}
