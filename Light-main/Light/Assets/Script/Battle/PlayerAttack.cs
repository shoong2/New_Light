using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttack : MonoBehaviour
{

    //basicAttack
    public Image basicAttack;
    public float attackCoolTime = 1f;
    public float basicAttackPower = 5f;
    public float addFeverTimeBasicPower = 0.5f;
    public float basicFeverTimeCoolTime = 0.1f;

    //skill
    public Image skill;
    public float skillPower = 5.5f;
    public float skillCoolTime = 1.7f;
    public float addFeverTimeSkillPower = 1f;
    public float skillFeverTimeCoolTime = 0.17f;

    Animator player;
    public float playerHPNumber = 100f;
    public float feverTimeNumber = 50f;

    public Image playerHP;
    public Image playerMP;
    public Image feverTimeImg;

    public GameManager_Battle battleMananger;

    public Animator feverTimeAnim;

    bool isFeverTime = false;

    public GameObject lose;
    public GameObject playerInfo;

    
    
    void Start()
    {
        player = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(feverTimeImg.fillAmount>0 && feverTimeImg.fillAmount !=1)
        {
            feverTimeImg.fillAmount -= Time.smoothDeltaTime / feverTimeNumber;
        }
  
    }

    public void BasicAttack()
    {
        if (basicAttack.fillAmount == 1)
        {
            player.SetTrigger("BasicAttack");
            basicAttack.fillAmount = 0;
            feverTimeImg.fillAmount += basicAttackPower/feverTimeNumber;
            if (feverTimeImg.fillAmount >= 1 && isFeverTime == false)
            {
                StartCoroutine(FeverTime());
            }
            battleMananger.DamageMonster(basicAttackPower);
            StartCoroutine(CoolTime(attackCoolTime));
    
        }

    }

    public void LiaSkill()
    {
        if(skill.fillAmount == 1)
        {
            skill.fillAmount = 0;
            feverTimeImg.fillAmount += skillPower / feverTimeNumber;
            if (feverTimeImg.fillAmount >= 1 && isFeverTime == false)
            {
                StartCoroutine(FeverTime());
            }
            battleMananger.DamageMonster(skillPower);
            StartCoroutine(CoolTime(skillCoolTime));
        }
    }

    IEnumerator CoolTime(float time)
    {
        while (basicAttack.fillAmount < 1f)
        {
            basicAttack.fillAmount += Time.smoothDeltaTime / time;

            yield return null;
        }
    }

    public void HitByMonster(float monsterPower)
    {
        playerHP.fillAmount -= (monsterPower / playerHPNumber);
        if(playerHP.fillAmount <=0)
        {
            StartCoroutine(DieLia());
        }
    }

    IEnumerator DieLia()
    {
        playerInfo.SetActive(false);
        Time.timeScale = 0;
        player.SetTrigger("Die");
        yield return new WaitForSecondsRealtime(1.1f);
        lose.SetActive(true);
        yield return new WaitForSecondsRealtime(1.1f);
        //¾ÀÀüÈ¯

    }
    IEnumerator FeverTime()
    {
        isFeverTime = true;
        feverTimeAnim.gameObject.SetActive(true);
        yield return new WaitForSeconds(1.4f);
        feverTimeAnim.gameObject.SetActive(false);
        basicAttackPower += addFeverTimeBasicPower;
        skillPower += addFeverTimeSkillPower;
        attackCoolTime += basicFeverTimeCoolTime;
        skillCoolTime += skillFeverTimeCoolTime;


        yield return new WaitForSeconds(10f);
        basicAttackPower -= addFeverTimeBasicPower;
        skillPower -= addFeverTimeSkillPower;
        attackCoolTime -= basicFeverTimeCoolTime;
        skillCoolTime -= skillFeverTimeCoolTime;
        feverTimeImg.fillAmount = 0f;
        isFeverTime = false;


    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(10f);
        basicAttackPower = 5f;
        feverTimeImg.fillAmount = 0f;
        isFeverTime = false;
    }
}
