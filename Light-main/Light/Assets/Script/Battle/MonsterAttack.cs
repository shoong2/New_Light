using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAttack : MonoBehaviour
{
    Animator AttackAnim;
    public float monsterCoolTime= 1f;
    public float monsterPower = 1f;
    public PlayerAttack playerInfo;
    void Start()
    {
        AttackAnim = GetComponent<Animator>();
        StartCoroutine(AttackPlayer());
    }

    IEnumerator AttackPlayer()
    {
        yield return new WaitForSeconds(monsterCoolTime);
        AttackAnim.SetBool("Attack", true);
        playerInfo.HitByMonster(monsterPower);
        yield return new WaitForSeconds(monsterCoolTime);
        AttackAnim.SetBool("Attack", false);
        StartCoroutine(AttackPlayer());

    }
}
