using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterHP : MonoBehaviour
{
    public int hp = 100;
    public int mp = 100;
    SkillManager playerAttack;
    Animator damagedAnim;
    // Start is called before the first frame update
    void Start()
    {
        playerAttack = FindObjectOfType<SkillManager>();
        damagedAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SmoothSetHP()
    {

    }
    public void GetDamage(int damage)
    {
        damagedAnim.Play("Damaged");
        hp -= damage;
        playerAttack.SetHP(hp);
        if (hp <= 0)
        {
            Die();
        }
    }
    
    void Die()
    {

    }
}
