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
    void Start()
    {   
        quest = new qData();
        string jsonData = JsonUtility.ToJson(quest);
        File.WriteAllText(Application.persistentDataPath + "/Data.json", jsonData);
        print(Application.persistentDataPath);
        
        // if(quest.tutorial == false)
        //     StartCoroutine(chat());
    }

    // Update is called once per frame
    void Update()
    {
        
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
    
    
}

[System.Serializable] 
public class qData
 {
    public bool tutorial= false;
    public int getApple = 0; 
 }

