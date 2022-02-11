using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RScore : MonoBehaviour
{
    private Text scoreText = null;

    void Start()
    {
        scoreText = GetComponent<Text>();
        if (MainManager.instance != null)
        {
            scoreText.text = "Score: " + MainManager.instance.score;
        }
        else
        {
            Destroy(this);
        }
    }
}
