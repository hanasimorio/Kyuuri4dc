using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OufukuMoveV : MonoBehaviour
{
    public float speed = 3;
    public int maxcount = 100;
    int count = 0;

    public void Start()
    {
        count = maxcount / 2;
    }
    private void FixedUpdate()
    {
        count = count + 1;
        if (count >= maxcount) 
        {
            speed = -speed;
            count = 0;
        }
        this.transform.Translate(0, speed / 50, 0);
    }
}
