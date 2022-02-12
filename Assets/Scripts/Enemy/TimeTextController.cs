using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeTextController : MonoBehaviour
{
    private Text timeText = null;
    private float oldScore = 0;

    // Start is called before the first frame update
    void Start()
    {
        timeText = GetComponent<Text>();

        if (MainManager.instance != null)
        {
            timeText.text = "Time: " + MainManager.instance.time;
        }
        else
        {
            Destroy(this);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (oldScore != MainManager.instance.time)
        {
            timeText.text = "Time: " + MainManager.instance.time.ToString("N2");
            oldScore = MainManager.instance.time;
        }
    }
}