using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public GameObject Lia;
    Animator Lia_anim;

    private void Start() 
    {
        Debug.Log("hello");
        Lia_anim = Lia.GetComponent<Animator>();
    }

    public void brown()
    {
        StartCoroutine("LiaAnim");
        
    }
    

    IEnumerator LiaAnim()
    {
        Lia_anim.SetBool("attack", true);
        yield return new WaitForSeconds(1f);
        Debug.Log("??");
        Lia_anim.SetBool("attack", false);
        yield return null;
    }
}
