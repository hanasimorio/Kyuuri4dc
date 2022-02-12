using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] GameObject cucumber = default;

    public void Finish()
    {
        gameObject.SetActive(false);
        Invoke("ActiveCucumber", 0.13f);
    }

    private void ActiveCucumber()
    {
        cucumber.SetActive(true);
    }
}
