using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletYobidashi : MonoBehaviour
{
    public float countmax = 3;
    public float count = 0;
    public float bulletspace = 1;
    bool YobidashiOK = false;
    public GameObject newBulletPre;
    GameObject PModokiyou;
    PModokiMove Modokiscript;
    bool leftFlagP;

    void Start()
    {
        YobidashiOK = true;
        PModokiyou = GameObject.Find("PlayerModoki");
        Modokiscript = PModokiyou.GetComponent<PModokiMove>();

    }
    void Update()
    {
        leftFlagP = Modokiscript.leftFlag;
        if (Input.GetKeyDown("z"))
        {
            GameObject NewBullet = Instantiate(newBulletPre) as GameObject;
            Vector2 pos = this.transform.position;
            if (leftFlagP == true)
            {
                pos.x -= bulletspace;
            }
            else if (leftFlagP == false)
            {
                pos.x += bulletspace;
            }
            NewBullet.transform.position = pos;
            YobidashiOK = false;
        }
        if (YobidashiOK == false)
        {
            count = count + 1;
            if (count >= countmax)
            {
                YobidashiOK = true;
                count = 0;
            }
        }
    }
}
