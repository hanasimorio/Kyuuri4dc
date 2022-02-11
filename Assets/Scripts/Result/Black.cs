using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Black : MonoBehaviour
{
    private Image image;

    private bool IsClick = false;

    private float C = 0.6f;

    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (IsClick)
        {

            C -= Time.fixedDeltaTime;


            image.color = new Color(0, 0, 0, C);
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
