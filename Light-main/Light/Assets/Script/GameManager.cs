using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class GameManager : MonoBehaviour
{
//    public Image panel;
    public Text text;
   
    public qData quest;
    public qData loadData;
    public GameObject QuestBox;

    public GameObject map;
    public Text AppleText;
    public Image tutorial;

    int on = 0;

   private void Awake() {
        print(Application.persistentDataPath);
        string JsonLoad= File.ReadAllText(Application.persistentDataPath + "/Data.json");
        
        loadData = JsonUtility.FromJson<qData>(JsonLoad);
        if(loadData == null)
        {
            Debug.Log("?");
            quest = new qData();
            string jsonData = JsonUtility.ToJson(quest);
            File.WriteAllText(Application.persistentDataPath + "/Data.json", jsonData);
        }
        JsonLoad= File.ReadAllText(Application.persistentDataPath + "/Data.json");
        
        loadData = JsonUtility.FromJson<qData>(JsonLoad);
   }
    void Start()
    {   
        if(loadData.TreeQuest == true)
        {
            QuestBox.SetActive(true);
        }

        if(loadData != null)
        {
            AppleText.text = "사과 10개를 가져오자 ("+loadData.getApple+"/10)"; //제이슨 저장 코드 핋요
        }
        StartCoroutine(Fade());
    }

    // Update is called once per frame
    void Update()
    {
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
            fadeCount +=0.01f;
            yield return new WaitForSeconds(0.005f);
            tutorial.color = new Color(1,1,1, fadeCount);
        }
        yield return new WaitForSeconds(1.3f);
        while(fadeCount>0)
        {
            fadeCount -= 0.02f;
            yield return new WaitForSeconds(0.005f);
            tutorial.color = new Color(1,1,1, fadeCount);
        }

        tutorial.gameObject.SetActive(false);
    }

    // public IEnumerator chat()
    // {
    //     panel.gameObject.SetActive(true);
    //     text.color = new Color(text.color.r, text.color.g, text.color.b, 0);
    //     panel.color = new Color(panel.color.r, panel.color.g, panel.color.b, 0);
        
    //     while (text.color.a < 1.0f)
    //     {
    //         text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a + (Time.deltaTime / 1.5f));
    //         panel.color = new Color(panel.color.r, panel.color.g, panel.color.b, panel.color.a + (Time.deltaTime / 3f));

    //         yield return null;
    //     }
    //     // StartCoroutine(FadeTextToZero());

    //     while (text.color.a > 0.0f)
    //     {
    //         text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a - (Time.deltaTime / 1.5f));
    //         panel.color = new Color(panel.color.r, panel.color.g, panel.color.b, panel.color.a - (Time.deltaTime / 3f));
    //         yield return null;
    //     }
    //     panel.gameObject.SetActive(false);
    //     yield return null;
    // }
    
    // public void SavaData(bool tutorial, bool TreeQuest, int getApple)
    // {
    //     qData data = new qData();
    //     data.tutorial = tutorial;
    //     data.TreeQuest = TreeQuest;
    //     data.getApple = getApple;

    //     string qwer = JsonUtility.ToJson(data);
    //     File.WriteAllText(Application.persistentDataPath + "/Data.json", qwer);
    // }
}

[System.Serializable] 
public class qData
 {
    public bool tutorial= false;
    public bool TreeQuest = false;
    public int getApple = 0; 
    
 }

