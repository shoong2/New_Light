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


    //public SaveData quest;
    //public SaveData qdata;
    public GameObject Player;
    public GameObject mainUI;
    public GameObject itemPocket;

    public GameObject QuestBox;
    public GameObject QuestBox2;
    public GameObject questBox3;

    public GameObject map;
    public Text AppleText;
    public Text BranchText;
    public Text waterDropText;
    // public Image tutorial;


    //Quest
    public GameObject QuestDetails;
    public TMP_Text QuestText;

    public TMP_Text QuestName;
    public TMP_Text QuestExplain;
    public TMP_Text QuestInfo;

    public TMP_Text nyleQuest1Text;

    //Skill
    public GameObject skill;
    public TMP_Text skillPointText;
    public TMP_Text addSkillPointText;
    public GameObject registerSkill;
    public GameObject cancelSkill;

    int ClickCount = 0; // 두번 클릭해서 종료


    //PopUP
    public Image QuestEnd;
    public Image QuestReward;

    //Map
    public AudioSource OpenMap;
    public AudioSource CloseMap;

    //BGM
    public AudioSource BGM;

    private Inventory theInven;

    public Vector3 beforeBattlePosition;
    public string beforeBattleScene;

    //몬스터 구별 문자열
    public string monsterName;
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

        if (saveData.TreeQuest == true && saveData.allTreeQuest ==false)
        {
            QuestBox.SetActive(true);

        }



        UpdateUI();
        Debug.Log(saveData.getApple);
        UpdateQuestUI();
        if (saveData.allTreeQuest == true)
        {
            UpdateSkillUI();
        }
        //StartCoroutine(Fade());
    }


    public void SaveData()
    {
        theInven = FindObjectOfType<Inventory>();

        Slot[] slots = theInven.GetSlots();

        saveData.invenArrayNumber.Clear();
        saveData.invenItemName.Clear();
        saveData.invenItemNumber.Clear();
        //Debug.Log(slots.Length);
        for (int i = 0; i < slots.Length; i++)
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
            //theInven = FindObjectOfType<Inventory>();

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
            CloseMap.Play();
        }          
        
        else
        {
            OpenMap.Play();
            map.SetActive(true);
            
        }
    }

    public void UpdateUI()
    {
        //나무정령 퀘스트1 UI
        if (saveData != null && saveData.StartNextQuest == false && saveData.allTreeQuest == false)
        {
            if (saveData != null && saveData.getApple >= 10 && saveData.getBranch >= 3)
            {
                AppleText.text = "사과 10개를 가져오자 (완료)";
                BranchText.text = "나뭇가지 3개를 가져오자 (완료)";
                StartCoroutine(Fade(QuestEnd));
                saveData.isTreeQuest1 = true;
                //SaveData();
            }
            else
            {
                AppleText.text = "사과 10개를 가져오자 (" + saveData.getApple + "/10)";
                BranchText.text = "나뭇가지 3개를 가져오자 (" + saveData.getBranch + "/3)";
            }
        }

        //나무정령 퀘스트2 UI
        if(saveData.StartNextQuest== true && saveData.allTreeQuest == false)
        {
            QuestBox.SetActive(false);
            QuestBox2.SetActive(true);
            if (saveData.waterDrop < 5)
                waterDropText.text = "물방울 5개를 가져오자 (" + saveData.waterDrop + "/5)";
            else
            {
                waterDropText.text = "물방울 5개를 가져오자 (완료)";
                saveData.isTreeQuest2 = true;
            }

        }

        if(saveData.nyleQuest1 == true)
        {
            questBox3.SetActive(true);
            nyleQuest1Text.text = "추추의 물방울 " + saveData.chuchu+
                "\n푸링의 물방울 " + saveData.pooling+
                "\n밍의 물방울 "+ saveData.ming;
        }

        if(saveData.allTreeQuest == true)
        {
            QuestBox2.SetActive(false);
            //UpdateSkillUI();
        }

        //if(saveData.isTreeQuest2 == true)
        //{
        //    skill.SetActive(true);
        //}


        //if (saveData != null && saveData.getApple >= 10 && saveData.getBranch >= 3)
        //{
        //    AppleText.text = "사과 10개를 가져오자 (완료)";
        //    BranchText.text = "나뭇가지 3개를 가져오자 (완료)";
        //    StartCoroutine(Fade(QuestEnd));
        //    saveData.isTreeQuest1 = true;
        //    //SaveData();
        //}
        //SaveData();

    }

    public void UpdateQuestUI()
    {
        if(saveData.TreeQuest ==true)
        {
            QuestDetails.SetActive(true);
            QuestText.gameObject.SetActive(true);
            QuestText.text = saveData.mainQuestText;

            QuestName.text = saveData.mainQuestText;
            QuestExplain.text = saveData.QuestDetailText;

            if (saveData.StartNextQuest == false)
            {
                if (saveData.getApple < 10 && saveData.getBranch < 3)
                    QuestInfo.text = "사과    (" + saveData.getApple + "/10)\n" + "나뭇가지 (" + saveData.getBranch + "/3)";
                else
                    QuestInfo.text = "사과     (완료)\n" + "나뭇가지 (완료)";
            }

            if(saveData.StartNextQuest ==true)
            {
                if (saveData.waterDrop < 5)
                    QuestInfo.text = "물방울    (" + saveData.waterDrop + "/5)";
                else
                    QuestInfo.text = "물방울     (완료)";
            }
        }

        //SaveData();

    }

    public void UpdateSkillUI()
    {
        if (saveData.registerSkill == true)
        {
            registerSkill.SetActive(false);
            cancelSkill.SetActive(true);
        }
        else
        {
            registerSkill.SetActive(true);
            cancelSkill.SetActive(false);
        }
        skill.SetActive(true);
        skillPointText.text = saveData.SkillPoint.ToString();
        addSkillPointText.text = saveData.AddSkillPoint.ToString();
        //SaveData();
    }

    public void ClickAddSkillPoint()
    {
        if (saveData.allTreeQuest)
        {
            saveData.SkillPoint--;
            saveData.AddSkillPoint++;
            UpdateSkillUI();
            //SaveData();
        }
    }

    public void RegisterSkill()
    {
        if (saveData.registerSkill == true)
            saveData.registerSkill = false;
        else
            saveData.registerSkill = true;

        UpdateSkillUI();
        //SaveData();
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

    IEnumerator Fade(Image PopUp)
    {
        PopUp.gameObject.SetActive(true);
        float fadeCount = 0;
        while (fadeCount < 1f)
        {
            fadeCount += 0.01f;
            yield return new WaitForSeconds(0.005f);
            PopUp.color = new Color(1, 1, 1, fadeCount);
        }
        yield return new WaitForSeconds(1.3f);
        while (fadeCount > 0)
        {
            fadeCount -= 0.02f;
            yield return new WaitForSeconds(0.005f);
            PopUp.color = new Color(1, 1, 1, fadeCount);
        }

        PopUp.gameObject.SetActive(false);
    }

    public void AfterBattleCouroutine()
    {
        StartCoroutine(AfterBattle());
    }

    IEnumerator AfterBattle()
    {
        SceneManager.LoadScene(beforeBattleScene);
        Player.SetActive(true);
        mainUI.SetActive(true);
        Player.transform.position = beforeBattlePosition;
        yield return new WaitForSeconds(0.3f);
        Instantiate(itemPocket,new Vector3(beforeBattlePosition.x, beforeBattlePosition.y-0.5f,0), Quaternion.identity);
      
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
    public int waterDrop = 0; //물방울 개수

    public bool StartNextQuest = false; //다음 퀘스트 수락 후
    public bool isTreeQuest2 = false;
    public bool allTreeQuest = false;

    public List<int> invenArrayNumber = new List<int>();
    public List<string> invenItemName = new List<string>();
    public List<int> invenItemNumber = new List<int>();

    public string mainQuestText = "";
    public string QuestDetailText = "";

    //스킬포인트
    public int AddSkillPoint = 0;
    public int SkillPoint = 0;

    //나일 퀘스트
    public bool startNyle = false;
    public int chatHelper = 0;
    public bool nyleQuest1 = false; //진행여부
    public bool nyleQuest2 = false; //진행여부

    public string chuchu = "(0/1)";
    public string pooling = "(0/1)";
    public string ming = "(0/1)";

    //배틀데이터
    public bool registerSkill = false;

}

