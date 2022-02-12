using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CucumberFrame : MonoBehaviour
{
    Image image;
    float alpha;

    private void OnEnable()
    {
        alpha = 1;
        image = GetComponent<Image>();
        Invoke("PassiveCucumber", 1.0f);
        StartCoroutine("Invisible");
    }

    void PassiveCucumber()
    {
        StartCoroutine("Invisible");
    }

    IEnumerator Invisible()
    {
        for (int i = 0; i < 100; i++) {
            image.color = new Color(255f, 255f, 255f, alpha);
            alpha -= 0.01f;
            yield return new WaitForSeconds(0.03f);
        }
        gameObject.SetActive(false);
    }
}
