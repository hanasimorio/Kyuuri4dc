using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CucumberFrame : MonoBehaviour
{
    Image image;

    private void OnEnable()
    {
        image = GetComponent<Image>();
        //Invoke("PassiveCucumber", 4.0f);
        StartCoroutine("Invisible");
    }

    void PassiveCucumber()
    {
        gameObject.SetActive(false);
    }

    IEnumerator Invisible()
    {
        for (float alpha = 255; alpha > 0; alpha--) {
            image.color = new Color(255f, 255f, 255f, alpha);
            yield return new WaitForSeconds(0.01f);
        }
    }
}
