using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResultScene : MonoBehaviour
{

    public float s = 0;

    public float t= 0;

    public float result = 0;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        
    }

    private void Update()
    {
        s = MainManager.instance.score;

        t = MainManager.instance.time;

        result = MainManager.instance.resultscore;

    }

    public void ddd()
    {
        Destroy(this.gameObject);
    }


}
