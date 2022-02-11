using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatusScript : MonoBehaviour
{
    [SerializeField] int maxHP = 10;
    [SerializeField] int maxSP = 100;
    [SerializeField] Slider sliderHP = default;
    [SerializeField] Slider sliderSP = default;

    int HP = 1;
    int SP = 0;

    private void Start()
    {
        if (sliderHP == null || sliderSP == null) {
            Destroy(GetComponent<PlayerStatusScript>());
            return;
        }

        sliderHP.value = 1;
        sliderSP.value = 0;
        HP = maxHP;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Enemy") {
            int damage = Random.Range(1, 3);
            HP -= damage;
            sliderHP.value = (float)HP / (float)maxHP;
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "EnemyBullet") {
            int damage = Random.Range(1, 3);
            HP -= damage;
            sliderHP.value = (float)HP / (float)maxHP;
        }

        if (col.name == "ScoreItem") {
            int mana = Random.Range(1, 3);
            SP += mana;
            sliderSP.value = (float)SP / (float)maxSP;
        }
    }
}
