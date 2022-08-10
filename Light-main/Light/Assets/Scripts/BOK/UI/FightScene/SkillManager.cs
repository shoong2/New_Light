using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SkillManager : MonoBehaviour
{
    public int damage = 30;
    public Image normalAttackClick;
    public Image Skill0;
    float currentCoolTime;
    float coolTime=5;
    public bool canUseSkill = true;
    public Image hpbar;
    public Image mpbar;
    public int mp = 30;
    Animator playerAttackAnim;
    // Start is called before the first frame update
    void Start()
    {
        normalAttackClick.fillAmount = 0;
        playerAttackAnim = FindObjectOfType<Animator>();
    }
            
    public void UseSkill0()
    {
        coolTime = 5;
        damage = 30;
        mp = 30;
        if (canUseSkill)
        {
            
            PlayerHP player = FindObjectOfType<PlayerHP>();
            MonsterHP monsterHP = FindObjectOfType<MonsterHP>();
            if (monsterHP != null)
            {
                monsterHP.GetDamage(damage);
                player.GetMP(mp);
            }
            normalAttackClick.fillAmount = 1;
            StartCoroutine("CoolTime");
            currentCoolTime = coolTime;
            StartCoroutine("CoolTimeCounter");
            canUseSkill = false;
        }
        else
        {
            return;
        }
    }
    public void UseNormalSkill(){
        coolTime = 5;
        playerAttackAnim.SetBool("isAttack", true);
        if (canUseSkill)
        {
            PlayerHP player = FindObjectOfType<PlayerHP>();
            
            MonsterHP monsterHP = FindObjectOfType<MonsterHP>();
            if (monsterHP != null)
            {
                monsterHP.GetDamage(damage);
                //player.GetMP(mp);
            }
            normalAttackClick.fillAmount = 1;
            StartCoroutine("CoolTime");
            currentCoolTime = coolTime;
            StartCoroutine("CoolTimeCounter");
            canUseSkill = false;
        }
        else
        {
            return;
        }
    }
    IEnumerator CoolTime()
    {
        while (normalAttackClick.fillAmount > 0)
        {
            normalAttackClick.fillAmount -= Time.deltaTime / coolTime;
            yield return null;
        }
        canUseSkill = true;
        playerAttackAnim.SetBool("isAttack", false);
        yield break;
    }
    IEnumerator CoolTimeCounter() { 
        while (currentCoolTime > 0) {
            yield return new WaitForSeconds(1.0f); 
            currentCoolTime -= 1.0f; 
        }
        yield break; 
    }
    public void SetHP(int hp)
    {
        hpbar.fillAmount = (float)hp / 100f;
    }
    public void SetMP(int mp)
    {
        mpbar.fillAmount = (float)mp / 100f;
    }
}