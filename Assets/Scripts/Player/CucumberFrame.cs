using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CucumberFrame : MonoBehaviour
{
    Image image;

    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        Invoke("PassiveCucumber", 2.5f);
        StartCoroutine("Invisible");
    }

    void PassiveCucumber()
    {
        gameObject.SetActive(false);
    }

    IEnumerator Invisible()
    {
        for (int alpha = 255; alpha > 0; alpha--) {
            Color color = image.color;
            color.a = alpha;
            image.color = color;
            yield return new WaitForSeconds(0.0025f);
        }
    }
}
