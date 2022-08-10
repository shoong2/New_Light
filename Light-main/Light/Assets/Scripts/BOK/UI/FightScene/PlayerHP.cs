using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerHP : MonoBehaviour
{
    public int hp = 100;
    public int mp = 100;
    public MonsterSkill monsterAttack;
    public SkillManager playerSkill;
    public Image hpbar;
    public Image Smoothhpbar;
    
    
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
        
        SetHP(hp);
        
        StartCoroutine(SmoothHP(hp));
        hp -= damage;
        if (hp <= 0)
        {
            //Die();
        }
    }
    public void GetMP(int mp)
    {
        this.mp -= mp;
        playerSkill.SetMP(this.mp);
        if (mp <= 0)
        {
            Debug.Log("Dont Skill");
        }
    }
    public void SetHP(int hp)
    {
        hpbar.fillAmount = (float)hp / 100f;
    }
    IEnumerator SmoothHP(int hp)
    {
        for (int i = 0; i <= 100; i++)
        {
            hpbar.fillAmount = Mathf.Lerp(hp/100f,this.hp/100f, i * 0.01f);
            yield return new WaitForSeconds(0.01f);
        }
    }
}