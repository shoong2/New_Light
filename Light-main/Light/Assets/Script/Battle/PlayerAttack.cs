using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttack : MonoBehaviour
{
    public Image basicAttack;
    Animator player;

    public float attackCoolTime = 3f;
    public float basicAttackPower = 5f;
    public float playerHPNumber = 100f;
    public float feverTimeNumber = 50f;

    public Image playerHP;
    public Image feverTimeImg;

    public GameManager_Battle battleMananger;

    public Animator feverTimeAnim;

    bool isFeverTime = false;

    
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
                StartCoroutine(Timer());
            }
            battleMananger.DamageMonster(basicAttackPower);
            StartCoroutine(CoolTime());
    
        }

    }

    IEnumerator CoolTime()
    {
        while (basicAttack.fillAmount < 1f)
        {
            basicAttack.fillAmount += Time.smoothDeltaTime / attackCoolTime;

            yield return null;
        }
    }

    public void HitByMonster(float monsterPower)
    {
        playerHP.fillAmount -= (monsterPower / playerHPNumber);
    }

    IEnumerator FeverTime()
    {
        isFeverTime = true;
        feverTimeAnim.gameObject.SetActive(true);
        basicAttackPower = 5.5f;
        yield return new WaitForSeconds(1.4f);
        feverTimeAnim.gameObject.SetActive(false);

    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(10f);
        basicAttackPower = 5f;
        feverTimeImg.fillAmount = 0f;
        isFeverTime = false;
    }
}
