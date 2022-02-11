using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreTextController : MonoBehaviour
{
    private Text scoreText = null;
    private int oldScore = 0;

    // Start is called before the first frame update
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

    // Update is called once per frame
    void Update()
    {
        if (oldScore != MainManager.instance.score)
        {
            scoreText.text = "Score: " + MainManager.instance.score;
            oldScore = MainManager.instance.score;
        }
    }
}