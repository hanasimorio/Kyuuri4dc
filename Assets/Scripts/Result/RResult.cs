using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RResult : MonoBehaviour
{
    private Text resultText = null;

    void Start()
    {
        resultText = GetComponent<Text>();
        if (MainManager.instance != null)
        {
            resultText.text = "ResultScore: " + MainManager.instance.resultscore;
        }
        else
        {
            Destroy(this);
        }
    }
}
