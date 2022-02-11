using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScoreItem : MonoBehaviour
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
                AudioSource.PlayClipAtPoint(AC, transform.position);
                MainManager.instance.UpScore(myscore);
                MainManager.instance.TimeStop();
                MainManager.instance.finishscore() ;
                Destroy(this.gameObject);

            }
        }
    }
}
