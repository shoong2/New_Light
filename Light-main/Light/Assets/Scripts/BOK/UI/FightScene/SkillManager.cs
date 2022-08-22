using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SkillManager : MonoBehaviour
{
    int damage = 5;//리아 일반공격력
    public Image[] AttackClick;
    public Image[] SkillClick;
    float currentCoolTime;
    float coolTime=3;
    bool canUseSkill =true;
    bool canUseNormalAttack = true;
    int mp = 3;//mp감소 크기
    //public Animator playerAttackAnim;
    public Animator AttackEffect;
    public GameObject[] player;
    public bool attackMoveAnim=false;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < AttackClick.Length; i++)
        {
            AttackClick[i].fillAmount = 0;
        }
        for (int i = 0; i < AttackClick.Length; i++)
        {
            SkillClick[i].fillAmount = 0;
        }
    }
    public void CallNormalAttack(int characterNum)
    {
        switch (characterNum)
        {
            case 0:
                UseNormalSkill(characterNum);
                Debug.Log("평타실행?");
                break;
        }
    }
    public void CallSkillAttack(int characterNum)
    {
        switch (characterNum)
        {
            case 0:
                UseSkill0(characterNum);
                Debug.Log("스킬실행?");
                break;
        }
    }
    public void UseSkill0(int characterNum)//휘두르기스킬
    {
        Debug.Log("실행은함?");
        attackMoveAnim = true;
        coolTime = 10;
        damage = 5;
        mp = 3;
        if (canUseSkill)
        {
            Debug.Log("불리언실행후?");
            switch (characterNum)
            {
                case 0:
                    player[characterNum].GetComponent<Animator>().Play("Lia_Skill0Attack");
                    break;
            }
            
            AttackEffect.Play("SkillEffect");
            PlayerHP playerHP = FindObjectOfType<PlayerHP>();
            MonsterHP monsterHP = FindObjectOfType<MonsterHP>();
            if (monsterHP != null)
            {
                monsterHP.GetDamage(damage);
                playerHP.GetMP(mp);
            }
            SkillClick[characterNum].fillAmount = 1;
            Debug.Log("코루틴실행전?");
            StartCoroutine(SkillCoolTime(characterNum));
            
            currentCoolTime = coolTime;
            
            StartCoroutine(CoolTimeCounter());
            canUseSkill = false;
            attackMoveAnim = false;
            Debug.Log("실행은함");
        }
        else
        {
            return;
        }
    }
    public void UseNormalSkill(int characterNum){
        Debug.Log("실행은함?");
        attackMoveAnim = true;
        coolTime = 3;
        damage = 5;
        if (canUseNormalAttack)
        {
            Debug.Log("불리언실행후?");
            switch (characterNum)
            {
                case 0:
                    player[characterNum].GetComponent<Animator>().Play("Lia_NormalAttack");
                    break;
            }
            
            AttackEffect.Play("AttackEffect");
            MonsterHP monsterHP = FindObjectOfType<MonsterHP>();
            if (monsterHP != null)
            {
                monsterHP.GetDamage(damage);
                //player.GetMP(mp);
            }
            AttackClick[characterNum].fillAmount = 1;
            Debug.Log("코루틴실행전?");
            StartCoroutine(CoolTime(characterNum));
            currentCoolTime = coolTime;
            StartCoroutine(CoolTimeCounter());
            canUseNormalAttack = false;
            StartCoroutine(AttackMove());
            Debug.Log("평타실행은함");
        }
        else
        {
            return;
        }
    }
    IEnumerator CoolTime(int characterNum)
    {
        while (AttackClick[characterNum].fillAmount > 0)
        {
            AttackClick[characterNum].fillAmount -= Time.deltaTime / coolTime;
            yield return null;
        }
        canUseNormalAttack = true;
        yield break;
    }
    IEnumerator SkillCoolTime(int characterNum)
    {
        while (SkillClick[characterNum].fillAmount > 0)
        {
            SkillClick[characterNum].fillAmount -= Time.deltaTime / coolTime;
            yield return null;
        }
        canUseSkill = true;
        yield break;
    }
    IEnumerator CoolTimeCounter() { 
        while (currentCoolTime > 0) {
            yield return new WaitForSeconds(1.0f); 
            currentCoolTime -= 1.0f; 
        }
        yield break; 
    }
    IEnumerator AttackMove()
    {
        yield return new WaitForSeconds(1f);
        attackMoveAnim = false;
    }
}