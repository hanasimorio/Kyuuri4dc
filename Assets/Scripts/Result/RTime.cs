using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RTime : MonoBehaviour
{
    private Text timeText = null;

    void Start()
    {
        timeText = GetComponent<Text>();
        if (MainManager.instance != null)
        {
            timeText.text = "TimeBonus: " + MainManager.instance.timebonus;
        }
        else
        {
            Destroy(this);
        }
    }
}
