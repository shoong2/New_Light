using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MonsterHP : MonoBehaviour
{
    public int hp = 100;//Laing HP
    Animator damagedAnim;
    public Image hpbar;
    bool isHPDown = true;

    public bool ishalfHP = false;
    // Start is called before the first frame update
    void Start()
    {
        damagedAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GetDamage(int damage)
    {
        
        damagedAnim.Play("Damaged");
        if (isHPDown)
        {
            StartCoroutine(SmoothMonsterHP(hp));
            
            isHPDown = false;
        }
        hp -= damage;

        //hp -= damage;


    }
    IEnumerator SmoothMonsterHP(int hp) {
        
            
        for (int i = 0; i <= 100; i++)
        {
            
            hpbar.fillAmount = Mathf.Lerp(hp / 100f, this.hp / 100f, i * 0.01f);
            if (hpbar.fillAmount <= 0)
            {
                hpbar.fillAmount = 0;
            }
            else if (hpbar.fillAmount <= 0.5)
            {
                ishalfHP = true;
            }
            else
            {
                ishalfHP = false;
            }
            yield return new WaitForSeconds(0.01f);
        }
        isHPDown = true;
    }
    void Die()
    {
        
    }
}
