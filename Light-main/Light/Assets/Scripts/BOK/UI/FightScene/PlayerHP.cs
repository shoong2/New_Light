using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerHP : MonoBehaviour
{
    public int hp = 120;//Lia HP
    public int mp = 100;//Lia MP
    public MonsterSkill monsterAttack;
    public SkillManager playerSkill;
    public Image hpbar;
    public Image mpbar;
    bool isHPDown = true;
    bool isMPDown = true;
    public float MaxHP;
    public float MaxMP;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GetDamage(int damage)
    {
        if (isHPDown)
        {
            StartCoroutine(SmoothHP(hp));
            isHPDown = false;
        }
        hp -= damage;
    }
    public void GetMP(int decrease_mp)
    {
        if (isMPDown)
        {
            StartCoroutine(SmoothMP(mp));
            isMPDown = false;
        }
        mp -= decrease_mp;
    }
    IEnumerator SmoothMP(int mp)
    {
        for (int i = 0; i <= 100; i++)
        {
            mpbar.fillAmount = Mathf.Lerp(mp / MaxMP, this.mp /MaxMP, i * 0.01f);
            if (mpbar.fillAmount <= 0)
            {
                mpbar.fillAmount = 0;
            }
            yield return new WaitForSeconds(0.01f);
        }
        isMPDown = true;
    }
    IEnumerator SmoothHP(int hp)
    {
        for (int i = 0; i <= MaxHP; i++)
        {
            hpbar.fillAmount = Mathf.Lerp(hp / MaxHP, this.hp / MaxHP, i * 0.01f);
            if (hpbar.fillAmount <= 0)
            {
                hpbar.fillAmount = 0;
            }
            yield return new WaitForSeconds(0.01f);
            
        }
        isHPDown = true;
    }
}