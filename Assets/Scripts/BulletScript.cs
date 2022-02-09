using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [SerializeField] private float speed = default;

    private void FixedUpdate()
    {
        transform.Translate(speed * Time.deltaTime, 0f, 0f);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
