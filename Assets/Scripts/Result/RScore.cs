using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RScore : MonoBehaviour
{
    private Text scoreText = null;

    private GameObject s;

    void Start()
    {
        s = GameObject.Find("Score");
        var ss = s.GetComponent<ResultScene>();

        scoreText = GetComponent<Text>();
        scoreText.text = "Score: " + ss.s;
    }
}