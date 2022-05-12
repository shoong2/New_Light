using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class uiManager : MonoBehaviour
{
    public GameObject map;
    public Text apple;
    GameManager mg;
    int on = 0;

    void Start() {
        mg = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void Update() 
    {
        apple.text = "사과 10개를 가져오자 ("+mg.quest.getApple+"/10)"; //제이슨 저장 코드 핋요
    }
    public void mapButton()
    {
        if(on == 0)
        {
            map.SetActive(true);
            on =1;
        }
        
        else
        {
            map.SetActive(false);
            on =0;
        }
    }
}
