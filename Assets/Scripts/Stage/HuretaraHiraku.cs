using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HuretaraHiraku : MonoBehaviour
{
    bool OpenFlag = false;
    bool OpenMaxFlag = false;
    public float openspeed = 0.1f;
    // Start is called before the first frame update
    private void Start()
    {
        OpenFlag = false;
        OpenMaxFlag = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.y >= 15)
        {
            OpenMaxFlag = true;
        }
        if (GameObject.Find("HureteHiraku/item_Hureru") == null)
        {
            OpenFlag = true;
        }
    }
    void FixedUpdate()
    {
        if (OpenFlag == true && OpenMaxFlag == false)
        {
            this.transform.Translate(0, openspeed, 0);
        }
    }
}
