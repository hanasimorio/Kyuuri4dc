using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapeKey : MonoBehaviour
{
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Escape)) {
            Application.Quit();
        }
    }
}
