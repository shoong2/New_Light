using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class uiManager : MonoBehaviour
{
    public GameObject map;
    public Text apple;
    public Image tutorial;
    GameManager mg;
    int on = 0;
    float time;
    float fadeTime =1;

    void Start() {
        mg = GameObject.Find("GameManager").GetComponent<GameManager>();
        StartCoroutine(Fade());
        
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

    IEnumerator Fade()
    {
        float fadeCount = 0;
        while (fadeCount <1.0f)
        {
            fadeCount +=0.005f;
            yield return new WaitForSeconds(0.01f);
            tutorial.color = new Color(1,1,1, fadeCount);
        }
        yield return new WaitForSeconds(1.3f);
        while(fadeCount>0)
        {
            fadeCount -= 0.01f;
            yield return new WaitForSeconds(0.01f);
            tutorial.color = new Color(1,1,1, fadeCount);
        }

        tutorial.gameObject.SetActive(false);
    }

    
}
