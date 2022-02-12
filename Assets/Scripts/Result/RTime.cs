using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RTime : MonoBehaviour
{
    private Text scoreText = null;

    private GameObject s;

    [SerializeField] private float max = 60000;

    [SerializeField] private float down = 100;

    void Start()
    {
        s = GameObject.Find("Score");
        var ss = s.GetComponent<ResultScene>();

        scoreText = GetComponent<Text>();

        var result = max - down * ss.t;

        if(result < 0)
        {
            result = 0;
        }

        scoreText.text = "Time: " + (int)result;
    }

}
