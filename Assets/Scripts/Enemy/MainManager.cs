using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainManager : MonoBehaviour
{
    public static MainManager instance = null;

    public int score = 0;

    public float time = 0;

    private int lasttime = 0;

    private bool Ontime = false;

    public int resultscore = 0;

    public bool ult = false;

    [SerializeField] private int MaxTimeBonus = 80000;

    public int timebonus = 0;

    [SerializeField] private int DownTime = 2000;

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

        if (Input.GetKeyDown(KeyCode.Escape))
            EndGame();

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

        ChangeResult();
    }

    public void DeadScore()
    {
        timebonus = 0;
        resultscore = score;
        ChangeResult();
    }

    public void ScoreReset()
    {
        score = 0;
        time = 0;
        lasttime = 0;
        resultscore = 0;
        timebonus = 0;
    }


    public void EndGame()
    {
        Application.Quit();
    }

    private void ChangeResult()
    {
        SceneManager.LoadScene("ResultScene");
    }

    public void Restart()
    {
        SceneManager.LoadScene("38scene");
    }


}
