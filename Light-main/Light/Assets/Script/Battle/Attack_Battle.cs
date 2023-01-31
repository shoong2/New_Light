using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Attack_Battle : MonoBehaviour
{
    public Image basicAttack;
    Animator player;
    public float attackCoolTime = 3f;
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
            StartCoroutine(CoolTime());
    
        }

    }

    IEnumerator CoolTime()
    {
        Debug.Log("1");
        while (basicAttack.fillAmount < 1f)
        {
            Debug.Log("1");
            basicAttack.fillAmount += Time.smoothDeltaTime / attackCoolTime;

            yield return null;
        }
    }
}
