using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager_Battle : MonoBehaviour
{
    int monsterCount = 0;
    public GameObject monster;
    public GameObject monsterHp;

    public GameObject gameStart;

    public List<Transform> obj;
    public List<GameObject> bar;

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
    }
}
