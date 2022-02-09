using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testBullet : MonoBehaviour
{
    public float speed = 10;
    public float limitsecond = 1;
    float bulletspeed;
    GameObject PModokiyou;
    PModokiMove Modokiscript;
    bool leftFlagP;
    void Start()
    {
        PModokiyou = GameObject.Find("PlayerModoki");
        Modokiscript = PModokiyou.GetComponent<PModokiMove>();
        leftFlagP = Modokiscript.leftFlag;
        Destroy(this.gameObject, limitsecond);
    }
    private void Update()
    {
        if (leftFlagP == true)
        {
            bulletspeed = -speed;
        }
        else
        {
            bulletspeed = speed;
        }
    }
    void FixedUpdate()
    {
        this.transform.Translate(bulletspeed / 50, 0, 0);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(this.gameObject);
    }
}
