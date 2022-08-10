using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MonsterSkill : MonoBehaviour
{
    public int damage = 30;
    float coolTime = 5;
    float currentCoolTime;
    public bool canUseSkill = true;
    Animator attackAnim;
    //player
    // Start is called before the first frame update
    void Start()
    {
        canUseSkill = true;
        attackAnim = GetComponent<Animator>();
        Invoke("CanUseSkillOn",3.0f);
        Invoke("CanUseSkillAnimOn", 3.0f);
        attackAnim.SetBool("isAttack", true);
    }
    void Update()
    {
        MonsterAttack();
    }
    void CanUseSkillOn()
    {
        canUseSkill = false;
    }
    void CanUseSkillAnimOn()
    {
        attackAnim.SetBool("isAttack", false);
    }
    public void MonsterAttack()
    {
        if (!canUseSkill&&!attackAnim.GetBool("isAttack"))
        {
            coolTime = 3;
            currentCoolTime = coolTime;
            canUseSkill = true;
            attackAnim.SetBool("isAttack", true);
            PlayerHP player = FindObjectOfType<PlayerHP>();
            if (player != null)
            {
               
                player.GetDamage(damage);

                
            }
            
            StartCoroutine("CoolTimeCounter");
        }

        else
        {
            return;
        }
    }

    IEnumerator CoolTimeCounter() {
        
        while (currentCoolTime > 0) {
            yield return new WaitForSeconds(1.0f); 
            currentCoolTime -= 1.0f; 
        }
        canUseSkill = false;
        attackAnim.SetBool("isAttack", false);
        yield break;
    }
    // Update is called once per frame
    
    
}
