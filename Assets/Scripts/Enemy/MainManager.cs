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

    private int timebonus = 0;

    [SerializeField] private int DownTime = 10;

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

        if(Input.GetKeyDown(KeyCode.Space))
        {
            TimeStop();
            finishscore();
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
        resultscore = score + timebonus;
        Debug.Log(resultscore);
    }

 

}
