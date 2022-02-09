using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UgokuAshibaNoreru : MonoBehaviour
{
    bool groundFlag = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        groundFlag = true;
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        groundFlag = false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (groundFlag == true && transform.parent == null && collision.gameObject.tag == ("MoveObject"))
        {
            transform.parent = collision.gameObject.transform;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (transform.parent != null && collision.gameObject.tag == ("MoveObject"))
        {
            transform.parent = null;
        }
    }
}
