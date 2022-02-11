using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScoreItem : MonoBehaviour
{
    [SerializeField] private int myscore;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (MainManager.instance != null)
        {
            if (collision.gameObject.tag == "Player")
            {
                MainManager.instance.UpScore(myscore);
                MainManager.instance.TimeStop();
                MainManager.instance.finishscore() ;
                Destroy(this.gameObject);

            }
        }
    }
}
