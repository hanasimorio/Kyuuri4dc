using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot02EnemyController : MonoBehaviour
{
    public GameObject player;
    
    public GameObject tama;

  
    [SerializeField] private float targetTime = 1.0f;
    private float currentTime = 0;

    // Update is called once per frame
    void Update()
    {
        
        currentTime += Time.deltaTime;
        if (targetTime < currentTime)
        {
            currentTime = 0;
            
            var pos = this.gameObject.transform.position;
           
            var t = Instantiate(tama) as GameObject;
            
            t.transform.position = pos;
           
            Vector2 vec = player.transform.position - pos;
            
            t.GetComponent<Rigidbody2D>().velocity = vec;
        }
    }
}
