using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    public static MainManager instance = null;

    public int score = 0;

    public float time = 0;

    private int lasttime = 0;

    private bool Ontime = false;

    public int resultscore = 0;

    [SerializeField] private int MaxTimeBonus = 6000;

    public int timebonus = 0;

    [SerializeField] private int DownTime = 100;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void Update()
    {
        if(Ontime)
        {
            time += Time.deltaTime;
        }

    }


    public void UpScore(int a)
    {
        score += a;
    }

    public void TimeStart()
    {
        Ontime = true;
    }

    public void TimeStop()
    {
        Ontime = false;
    }


    public void finishscore()
    {
        lasttime = (int)Mathf.Ceil(time);
        timebonus = MaxTimeBonus - lasttime * DownTime;
        if (timebonus >= 0)
        {
            resultscore = score + timebonus;
            Debug.Log(resultscore);
        }
        else if(timebonus < 0)
        {
            resultscore = score;
            Debug.Log(resultscore);
        }
    }

    public void DeadScore()
    {
        timebonus = 0;
        resultscore = score;
    }

    public void ScoreReset()
    {
        score = 0;
        time = 0;
        lasttime = 0;
        resultscore = 0;
        timebonus = 0;
    }



}
