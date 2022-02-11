using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{
    private Image image;

    private bool IsClick = false;

    private GameObject child;

    private Text text;

    private float C = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        child = transform.GetChild(0).gameObject;
        text = child.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (IsClick)
        {

            C -= Time.fixedDeltaTime;

            image.color = new Color(1, 1, 1, C);

            text.color = new Color(1, 1, 1, C);
        }
    }

    IEnumerator Des()
    {
        yield return new WaitForSeconds(5f);
        Destroy(this.gameObject);
    }

    public void Onclick()
    {
        IsClick = true;
        StartCoroutine(Des());
    }


}
