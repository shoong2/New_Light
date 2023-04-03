using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager_Battle : MonoBehaviour
{
    int monsterCount = 0;
    public float monsterHP = 100f;
    public GameObject monster;
    public GameObject monsterHp;

    public GameObject gameStart;
    public GameObject win;
    GameObject liaInPlayGround;

    public GameObject skill;

    //skill Effect
    public GameObject skillEffect;
    public List<Transform> obj;
    public List<GameObject> bar;
    public List<GameObject> monster_list;

    Transform battleMonster;



    void Start()
    {
        StartCoroutine(GameStartAnim());

        if (GameManager.instance.monsterName == "Green_PlayGround")
        {
            battleMonster = obj[0];
        }
        else if (GameManager.instance.monsterName == "Pooling")
        {
            battleMonster = obj[1];
        }
        else if (GameManager.instance.monsterName == "Ming")
        {
            battleMonster = obj[2];
        }
        else
            battleMonster = obj[3];

        monsterCount = Random.Range(1, 6);

        for (int i = 0; i < monsterCount; i++)
        {
            battleMonster.GetChild(i).gameObject.SetActive(true);
            //monster.transform.GetChild(i).gameObject.SetActive(true);
            bar.Add(Instantiate(monsterHp, new Vector2(battleMonster.GetChild(i).position.x, battleMonster.GetChild(i).position.y + 0.9f), Quaternion.identity,
                GameObject.Find("Canvas_Battle").transform));
        }

        if (GameManager.instance.saveData.registerSkill == true)
        {
            skill.SetActive(true);
        }
        else
            skill.SetActive(false);
    }

    IEnumerator GameStartAnim()
    {
        gameStart.SetActive(true);
        yield return new WaitForSeconds(1f);
        gameStart.SetActive(false);

    }

    IEnumerator WinAnim()
    {
        win.SetActive(true);
        yield return new WaitForSecondsRealtime(1.5f);
        //StartCoroutine(GameManager.instance.AfterBattle());
        GameManager.instance.AfterBattleCouroutine();
        
    }

    IEnumerator SkillEffect()
    {
        yield return new WaitForSeconds(0.3f);
        GameObject effect = Instantiate(skillEffect, new Vector2(battleMonster.GetChild(monsterCount - 1).position.x,
            battleMonster.GetChild(monsterCount - 1).position.y), Quaternion.identity);
        yield return new WaitForSeconds(1f);
        Destroy(effect);

    }

    public void DamageMonster(float power)
    {
        if (monsterCount - 1 >= 0)
        {
            Image monsterBar = bar[monsterCount - 1].transform.GetChild(0).GetChild(0).GetComponent<Image>();
            StartCoroutine(SkillEffect());
            monsterBar.fillAmount -= power / monsterHP;
            if (monsterBar.fillAmount <= 0)
            {
                Destroy(bar[monsterCount - 1].gameObject);
                //Destroy(obj[monsterCount - 1].gameObject);
                Destroy(battleMonster.GetChild(monsterCount - 1).gameObject);
                monsterCount--;
            }

            if(monsterCount == 0)
            {
                StartCoroutine(WinAnim());
            }
        }
    }
}
