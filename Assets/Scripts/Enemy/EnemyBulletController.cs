using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletController : MonoBehaviour
{

    [SerializeField] private float speed = 5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 Shotpos = transform.position;
        Shotpos.x -= speed * Time.deltaTime;
        transform.position = Shotpos;


    }

    private void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }


}
