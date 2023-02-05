using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager_Battle : MonoBehaviour
{
    int monsterCount = 0;
    public float monsterHP = 100f;
    public GameObject monster;
    public GameObject monsterHp;

    public GameObject gameStart;

    public List<Transform> obj;
    public List<GameObject> bar;
    public List<GameObject> monster_list;

    void Start()
    {
        StartCoroutine(GameStartAnim());
        monsterCount = Random.Range(1, 6);

        for(int i=0;i<monsterCount;i++)
        {
            obj[i].gameObject.SetActive(true);
            //monster.transform.GetChild(i).gameObject.SetActive(true);
            bar.Add(Instantiate(monsterHp, new Vector2(obj[i].position.x, obj[i].position.y+0.9f), Quaternion.identity,
                GameObject.Find("Canvas").transform));
        }

        
        

        //for(int i=0; i<monsterCount+1; i++)
        //{
        //    bar[i].transform.position = obj[i].position + new Vector3(0,1f,0);
        //}
    }

    IEnumerator GameStartAnim()
    {
        gameStart.SetActive(true);
        yield return new WaitForSeconds(1f);
        gameStart.SetActive(false);
        //bar[0].transform.Find("HPBar").GetComponent<Image>().fillAmount -= 0.5f;
        
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
        }
    }
}
