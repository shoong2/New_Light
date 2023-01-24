using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager_Battle : MonoBehaviour
{
    int monsterCount = 0;
    public GameObject monster;
    void Start()
    {
        monsterCount = Random.Range(1, 6);

        for(int i=0;i<monsterCount;i++)
        {
            monster.transform.GetChild(i).gameObject.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
