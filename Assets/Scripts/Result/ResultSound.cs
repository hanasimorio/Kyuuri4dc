using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultSound : MonoBehaviour
{

    [SerializeField] private AudioClip first;
    //[SerializeField] private AudioClip second;

    [SerializeField] private AudioSource AS1;
    [SerializeField] private AudioSource AS2;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ChangeSound());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator ChangeSound()
    {
        AS1.PlayOneShot(first);
        yield return new WaitForSeconds(3f);
        AS2.mute = false;
    }


}
