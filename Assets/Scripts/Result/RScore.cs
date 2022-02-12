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
<<<<<<< HEAD
        var ss = s.GetComponent<ResultS>();
=======
        //var ss = s.GetComponent<ResultScene>();
>>>>>>> 7570f847807c4ca166aa058748ee24c4379afb0d

        scoreText = GetComponent<Text>();
        //scoreText.text = "Score: " + ss.s;
    }
}