using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatusScript : MonoBehaviour
{
    [SerializeField] int maxHP = 10;
    [SerializeField] int maxSP = 10;
    [SerializeField] Slider sliderHP = default;
    [SerializeField] Slider sliderSP = default;

    int HP = 1;
    int SP = 0;
    bool fullSP = false;
    bool isDamaged = false;

    SpriteRenderer sprite;

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();

        if (sliderHP == null || sliderSP == null) {
            Destroy(GetComponent<PlayerStatusScript>());
            return;
        }

        sliderHP.value = 1;
        sliderSP.value = 0;
        HP = maxHP;
    }

    public void SpecialAttack()
    {
        if (SP >= maxSP && fullSP == true) {
            var SPbar = sliderSP.transform.GetChild(2).gameObject.transform.GetChild(0).gameObject;
            SPbar.GetComponent<Image>().color = new Color32(255, 255, 0, 255);
            SP = 0;
            sliderSP.value = (float)SP / maxSP;
            fullSP = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Enemy" && !isDamaged) {
            int damage = Random.Range(1, 3);
            HP -= damage;
            sliderHP.value = (float)HP / maxHP;
            StartCoroutine("DamagedFlash");
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "EnemyBullet" && !isDamaged) {
            int damage = Random.Range(1, 3);
            HP -= damage;
            sliderHP.value = (float)HP / maxHP;
            StartCoroutine("DamagedFlash");
        }

        if (col.name == "ScoreItem(Clone)") {
            int mana = Random.Range(1, 3);
            SP += mana;
            sliderSP.value = (float)SP / maxSP;

            if (SP >= maxSP && fullSP == false) {
                var SPbar = sliderSP.transform.GetChild(2).gameObject.transform.GetChild(0).gameObject;
                SPbar.GetComponent<Image>().color = new Color32(255, 116, 0, 255);
                fullSP = true;
            }
        }
    }

    IEnumerator DamagedFlash()
    {
        isDamaged = true;
        for (int i = 0; i < 10; i++) {
            sprite.color = new Color(255, 255, 255, 0);
            yield return new WaitForSeconds(0.075f);
            sprite.color = new Color(255, 255, 255, 255);
            yield return new WaitForSeconds(0.075f);
        }
        isDamaged = false;
    }
}
