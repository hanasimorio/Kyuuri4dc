using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePriority : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera target1 = default;
    [SerializeField] CinemachineVirtualCamera target2 = default;

    [SerializeField] bool move = true;

    private void OnTriggerEnter2D(Collider2D col)
    {

        if (col.tag == "Player"Å@) {
            if (move == true) {
                target1.Priority = 0;
                target2.Priority = 100;
            } else if (move == false) {
                target1.Priority = 100;
                target2.Priority = 0;
            }
        }
    }
}
