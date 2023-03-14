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
    public List<Transform> obj;
    public List<GameObject> bar;
    public List<GameObject> monster_list;

    void Start()
    {
        StartCoroutine(GameStartAnim());
        monsterCount = Random.Range(1, 6);

        for (int i = 0; i < monsterCount; i++)
        {
            obj[i].gameObject.SetActive(true);
            //monster.transform.GetChild(i).gameObject.SetActive(true);
            bar.Add(Instantiate(monsterHp, new Vector2(obj[i].position.x, obj[i].position.y + 0.9f), Quaternion.identity,
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

    public void DamageMonster(float power)
    {
        if (monsterCount - 1 >= 0)
        {
            Image monsterBar = bar[monsterCount - 1].transform.GetChild(0).GetChild(0).GetComponent<Image>();
            monsterBar.fillAmount -= power / monsterHP;
            if (monsterBar.fillAmount <= 0)
            {
                Destroy(bar[monsterCount - 1].gameObject);
                Destroy(obj[monsterCount - 1].gameObject);
                monsterCount--;
            }

            if(monsterCount == 0)
            {
                StartCoroutine(WinAnim());
            }
        }
    }
}
