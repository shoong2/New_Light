using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightManager : MonoBehaviour
{
    //��� ������ hp�˱�
    public MonsterHP[] monsterHPs;
    public bool isFeverTime;
    public Animator FeverTimeEffect;
    // Start is called before the first frame update
    void Start()
    {
        isFeverTime = false;
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < monsterHPs.Length; i++)
        {
            if (!FeverTimeEffect.GetBool("isFever")&&monsterHPs[i].ishalfHP)
            {
                FeverTimeEffect.SetBool("isFever",true);
                Debug.Log("�ǹ�Ÿ��");
                isFeverTime = true;
            }
        }
    }
}
