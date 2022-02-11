using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreItemController : MonoBehaviour
{

    [SerializeField] private int myscore;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (MainManager.instance != null)
        {
            if (collision.gameObject.tag == "Player")
            {
                MainManager.instance.UpScore(myscore);
                MainManager.instance.TimeStart();
                Destroy(this.gameObject);
                
            }
        }
    }


}
