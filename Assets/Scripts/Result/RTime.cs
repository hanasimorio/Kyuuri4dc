using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RTime : MonoBehaviour
{
    private Text scoreText = null;

    private GameObject s;

    private ResultS rs;


    [SerializeField] private float max = 60000;

    [SerializeField] private float down = 100;

    void Start()
    {
        s = GameObject.Find("Score");
        rs = s.GetComponent<ResultS>();

        scoreText = GetComponent<Text>();

        var time = rs.t;

        var result = max - down * time;

        if (result < 0)
        {
            result = 0;
        }


        scoreText.text = "ResultScore: " + (int)result;
        StartCoroutine(OK());
    }

    IEnumerator OK()
    {
        yield return new WaitForSeconds(1f);
        rs.ddd();
    }
}
