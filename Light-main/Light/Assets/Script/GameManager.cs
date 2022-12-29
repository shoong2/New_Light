using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    public Text text;
   
    //public SaveData quest;
    //public SaveData qdata;
    public GameObject QuestBox;
    public GameObject QuestBox2;

    public GameObject map;
    public Text AppleText;
    public Text BranchText;
    public Image tutorial;

    public SaveData saveData; //= new SaveData();

    private Inventory theInven;

    int on = 0;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }

    }
    //private void Awake() {
    //     print(Application.dataPath);
    //     //quest = new qData();
    //     string JsonLoad= File.ReadAllText(Application.dataPath + "/Data.json");
    //     //string path = Path.Combine(Application.dataPath, "data.json");


    //     if(loadData == null)
    //     {
    //         Debug.Log("?");
    //         quest = new qData();
    //         string jsonData = JsonUtility.ToJson(quest);
    //         File.WriteAllText(Application.dataPath + "/Data.json", jsonData);
    //     }
    //     JsonLoad= File.ReadAllText(Application.dataPath + "/Data.json");

    //     loadData = JsonUtility.FromJson<qData>(JsonLoad);
    //}

    

    private string SAVE_DATA_DIRECTORY;
    private string SAVE_FILENAME = "/SaveFile.txt";

    void Start()
    {
        Debug.Log(Application.persistentDataPath);
        SAVE_DATA_DIRECTORY = Application.persistentDataPath + "/Saves/";

        if (!Directory.Exists(SAVE_DATA_DIRECTORY))
        {
            Debug.Log("make file");
            saveData = new SaveData();
            Directory.CreateDirectory(SAVE_DATA_DIRECTORY);
            tutorial.gameObject.SetActive(true);
        }
            

        //SaveData();
        LoadData();
        if (saveData.TreeQuest == true)
        {
            QuestBox.SetActive(true);
        }

        if(saveData != null && (saveData.getApple<10 || saveData.getBranch<3))
        {
            AppleText.text = "사과 10개를 가져오자 ("+saveData.getApple+"/10)"; 
            BranchText.text = "나뭇가지 3개를 가져오자 ("+saveData.getBranch+"/3)";
        }

        if(saveData != null && saveData.getApple>=10 &&saveData.getBranch>=3 &&saveData.isTreeeQuest1 == false)
        {
            AppleText.text = "사과 10개를 가져오자 (완료)";
            BranchText.text = "나뭇가지 3개를 가져오자 (완료)";
        }

        if(saveData != null && saveData.isTreeeQuest1 == true)
        {
            QuestBox.SetActive(false);
            QuestBox2.SetActive(true);
        }

        
        StartCoroutine(Fade());
    }

    public void SaveData()
    {
        theInven = FindObjectOfType<Inventory>();

        Slot[] slots = theInven.GetSlots();
        for(int i = 0; i < slots.Length; i++)
        {
            if(slots[i].item != null)
            {
                saveData.invenArrayNumber.Add(i);
                saveData.invenItemName.Add(slots[i].item.itemName);
                saveData.invenItemNumber.Add(slots[i].itemCount);
            }
        }
        string json = JsonUtility.ToJson(saveData);

        File.WriteAllText(SAVE_DATA_DIRECTORY + SAVE_FILENAME, json);

        Debug.Log("Save");
    }

    public void LoadData()
    {
        if (File.Exists(SAVE_DATA_DIRECTORY + SAVE_FILENAME))
        {
            string loadJson = File.ReadAllText(SAVE_DATA_DIRECTORY + SAVE_FILENAME);
            saveData = JsonUtility.FromJson<SaveData>(loadJson);

            theInven = FindObjectOfType<Inventory>();

            for(int i =0; i< saveData.invenItemName.Count; i++)
            {
                theInven.LoadToInven(saveData.invenArrayNumber[i], saveData.invenItemName[i], saveData.invenItemNumber[i]);

            }
        }

        else
            Debug.Log("세이브 파일이 없습니다");

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

    public void UpdateUI()
    {
        AppleText.text = "사과 10개를 가져오자 (" + saveData.getApple + "/10)";
        BranchText.text = "나뭇가지 3개를 가져오자 (" + saveData.getBranch + "/3)";

        if (saveData != null && saveData.getApple >= 10 && saveData.getBranch >= 3 && saveData.isTreeeQuest1 == false)
        {
            AppleText.text = "사과 10개를 가져오자 (완료)";
            BranchText.text = "나뭇가지 3개를 가져오자 (완료)";
            saveData.isTreeeQuest1 = true;
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



}

[System.Serializable] 
public class SaveData
 {
    public bool tutorial= false; //튜토리얼 화면
    public bool TreeQuest = false;
    public bool isTreeeQuest1 = false; // 사과, 나뭇가지 줍기 퀘스트 완료
    public bool StartNextQuest = false; //다음 퀘스트 수락 후
    public bool isTreeeQuest2 = false;
    public int getApple = 0; 
    public int getBranch = 0;

    public List<int> invenArrayNumber = new List<int>();
    public List<string> invenItemName = new List<string>();
    public List<int> invenItemNumber = new List<int>();
    
 }

