using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Attack_Battle : MonoBehaviour
{
    public Image basicAttack;
    Animator player;
    public float attackCoolTime = 3f;
    public float basicAttackPower = 5f;

    public GameManager_Battle battleMananger;
    void Start()
    {
        player = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BasicAttack()
    {
        if (basicAttack.fillAmount == 1)
        {
            player.SetTrigger("BasicAttack");
            basicAttack.fillAmount = 0;
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
}
