using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersAnimation : MonoBehaviour
{
    public SkillManager skillManager;
    public GameObject monster;
    Vector3 myPosition;
    // Start is called before the first frame update
    void Start()
    {

        myPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
            if (skillManager.attackMoveAnim)
            {
                transform.position = Vector3.MoveTowards(transform.position, monster.transform.position - new Vector3(-3, 0), Time.deltaTime * 15f);
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, myPosition, Time.deltaTime * 15f);
            }
    }
    
}
