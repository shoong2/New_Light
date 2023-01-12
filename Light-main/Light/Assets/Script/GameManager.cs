using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;
using TMPro;

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
    // public Image tutorial;


    //Quest
    public TMP_Text QuestText;

    public TMP_Text QuestName;
    public TMP_Text QusetDetail;
    public TMP_Text QuestInfo;

    int ClickCount = 0; // 두번 클릭해서 종료


    int on = 0;

    

    private Inventory theInven;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }

    }

    ///////////////////////////////////DATA///////////////////////////////////
    public SaveData saveData; //= new SaveData();
    private string SAVE_DATA_DIRECTORY;
    private string SAVE_FILENAME = "/SaveFile.txt";
    /////////////////////////////////////////////////////////////////////////
    
    void Start()
    {
        Debug.Log(Application.persistentDataPath);
        SAVE_DATA_DIRECTORY = Application.persistentDataPath + "/Saves/";

        if (!Directory.Exists(SAVE_DATA_DIRECTORY))
        {
            Debug.Log("make file");
            saveData = new SaveData();
            Directory.CreateDirectory(SAVE_DATA_DIRECTORY);
            //tutorial.gameObject.SetActive(true);
        }

        LoadData();
        //StartCoroutine(LoadCoroutine());

        if (saveData.TreeQuest == true)
        {
            QuestBox.SetActive(true);
        }

        if(saveData != null && (saveData.getApple<10 || saveData.getBranch<3))
        {
            AppleText.text = "사과 10개를 가져오자 ("+saveData.getApple+"/10)"; 
            BranchText.text = "나뭇가지 3개를 가져오자 ("+saveData.getBranch+"/3)";
        }

        if(saveData != null && saveData.getApple>=10 &&saveData.getBranch>=3 &&saveData.isTreeQuest1 == false)
        {
            AppleText.text = "사과 10개를 가져오자 (완료)";
            BranchText.text = "나뭇가지 3개를 가져오자 (완료)";
        }

        if(saveData != null && saveData.isTreeQuest1 == true)
        {
            QuestBox.SetActive(false);
            QuestBox2.SetActive(true);
        }
        UpdateQuestUI();

        //StartCoroutine(Fade());
    }


    public void SaveData()
    {
        theInven = FindObjectOfType<Inventory>();

        Slot[] slots = theInven.GetSlots();
        //Debug.Log(slots.Length);
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

            StartCoroutine(LoadCoroutine());
            theInven = FindObjectOfType<Inventory>();

            //for(int i =0; i< saveData.invenItemName.Count; i++)
            //{
            //    theInven.LoadToInven(saveData.invenArrayNumber[i], saveData.invenItemName[i], saveData.invenItemNumber[i]);

            //}
        }

        else
            Debug.Log("세이브 파일이 없습니다");

    }

    IEnumerator LoadCoroutine()
    {
        yield return new WaitForSeconds(1f);
        theInven = FindObjectOfType<Inventory>();

        for (int i = 0; i < saveData.invenItemName.Count; i++)
        {
            theInven.LoadToInven(saveData.invenArrayNumber[i], saveData.invenItemName[i], saveData.invenItemNumber[i]);

        }
    }

    public void mapButton()
    {
        if(map.activeSelf == true)
        {
            map.SetActive(false);
        }          
        
        else
        {
            map.SetActive(true);
            
        }
    }

    public void UpdateUI()
    {
        AppleText.text = "사과 10개를 가져오자 (" + saveData.getApple + "/10)";
        BranchText.text = "나뭇가지 3개를 가져오자 (" + saveData.getBranch + "/3)";

        if (saveData != null && saveData.getApple >= 10 && saveData.getBranch >= 3 && saveData.isTreeQuest1 == false)
        {
            AppleText.text = "사과 10개를 가져오자 (완료)";
            BranchText.text = "나뭇가지 3개를 가져오자 (완료)";
            saveData.isTreeQuest1 = true;
        }

        UpdateQuestUI();
    }

    public void UpdateQuestUI()
    {
        QuestText.text = saveData.mainQuestText;

        QuestName.text = saveData.mainQuestText;
        QusetDetail.text = saveData.QuestDetailText;

        if(saveData.TreeQuest ==true)
        {
            if(saveData.getApple<=10 &&saveData.getBranch<=3)
                QuestInfo.text = "사과    (" + saveData.getApple + "/10)\n" + "나뭇가지 (" + saveData.getBranch + "/3)";
            else
                QuestInfo.text = "사과     (완료)\n"+"나뭇가지 (완료)";
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ClickCount++;
            if (!IsInvoking("DoubleClick"))
                Invoke("DoubleClick", 1.0f);

        }
        else if (ClickCount == 2)
        {
            CancelInvoke("DoubleClick");
            Application.Quit();
        }


    }

    void DoubleClick()
    {
        ClickCount = 0;
    }

}

[System.Serializable] 
public class SaveData
 {
    public bool tutorial= false; //튜토리얼 화면

    public bool TreeQuest = false; //나무정령 첫번째 퀘스트 수락 여부
    public bool isTreeQuest1 = false; // 사과, 나뭇가지 줍기 퀘스트 완료
    public int getApple = 0; //나무정령 퀘스트1 사과 개수
    public int getBranch = 0; // 나무개수

    public bool StartNextQuest = false; //다음 퀘스트 수락 후
    public bool isTreeQuest2 = false;
    

    public List<int> invenArrayNumber = new List<int>();
    public List<string> invenItemName = new List<string>();
    public List<int> invenItemNumber = new List<int>();

    public string mainQuestText = "";
    public string QuestDetailText = "";

}

