using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HuretaraShimaruK2 : MonoBehaviour
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
        if (this.transform.position.x <= minVer)
        {
            OpenMaxFlag = true;
        }
        if (GameObject.Find("JidouKyuri_Yoko2/item_Hureru2") == null)
        {
            OpenFlag = true;
        }
    }
    void FixedUpdate()
    {
        if (OpenFlag == true && OpenMaxFlag == false)
        {
            this.transform.Translate(-closespeed, 0, 0);
        }
    }
}