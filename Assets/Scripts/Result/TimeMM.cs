using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeMM : MonoBehaviour
{
    private bool onstart = false;

    private float time = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(onstart)
        {
            time += Time.deltaTime;
            time = MainManager.instance.time;
        }
    }

    public void Push()
    {
        onstart = true;
    }



}
