using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Operatetext : MonoBehaviour
{

    private bool OperateClick = false;

    private bool StartClick = false;

    private Text text;

    private float C = 0;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (OperateClick)
        {

            C += Time.fixedDeltaTime;

            text.color = new Color(1, 1, 1, C);
        }
        else if(StartClick)
        {
            C -= Time.fixedDeltaTime;
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
        OperateClick = true;
    }

    public void OnStart()
    {
        C = 1.0f;
        OperateClick = false;
        StartClick = true;
        StartCoroutine(Des());
    }

}

