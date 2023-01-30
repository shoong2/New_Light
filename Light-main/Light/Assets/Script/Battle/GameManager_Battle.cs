using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager_Battle : MonoBehaviour
{
    int monsterCount = 0;
    public GameObject monster;
    public GameObject monsterHp;

    public List<Transform> obj;
    public List<GameObject> bar;

    Camera camera;
    void Start()
    {
        camera = Camera.main;
        monsterCount = Random.Range(1, 6);

        for(int i=0;i<monsterCount;i++)
        {
            obj[i].gameObject.SetActive(true);
            //monster.transform.GetChild(i).gameObject.SetActive(true);
            Instantiate(monsterHp, new Vector2(obj[i].position.x, obj[i].position.y+0.8f), Quaternion.identity,
                GameObject.Find("Canvas").transform);
        }

        //for(int i=0; i<monsterCount+1; i++)
        //{
        //    bar[i].transform.position = obj[i].position + new Vector3(0,1f,0);
        //}
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
