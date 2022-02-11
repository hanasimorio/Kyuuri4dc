using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AAA : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera target1 = default;
    [SerializeField] CinemachineVirtualCamera target2 = default;


    private void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("aa");
        if (col.gameObject.tag == "Player") {
            target1.gameObject.SetActive(false);
            target2.gameObject.SetActive(true);
        }
    }
}
