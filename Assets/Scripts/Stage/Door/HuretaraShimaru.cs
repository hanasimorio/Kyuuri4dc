using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HuretaraShimaru : MonoBehaviour
{
    bool OpenFlag = false;
    bool OpenMaxFlag = false;
    public float minVer = 15;
    public float closespeed = 0.1f;
    // Start is called before the first frame update
    private void Start()
    {
        OpenFlag = false;
        OpenMaxFlag = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.y <= minVer)
        {
            OpenMaxFlag = true;
        }
        if (GameObject.Find("HureteShimaru/item_Hureru") == null)
        {
            OpenFlag = true;
        }
    }
    void FixedUpdate()
    {
        if (OpenFlag == true && OpenMaxFlag == false)
        {
            this.transform.Translate(0, -closespeed, 0);
        }
    }
}
