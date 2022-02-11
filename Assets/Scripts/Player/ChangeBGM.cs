using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeBGM : MonoBehaviour
{
    [SerializeField] AudioClip mainBGM = default;
    AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    public void ChangeMainBGM()
    {
        audio.clip = mainBGM;
        audio.Play();
    }
}
