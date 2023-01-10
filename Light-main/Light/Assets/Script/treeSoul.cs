using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
public class treeSoul : MonoBehaviour
{
    public GameObject ChatBar;
    public GameObject select;
    public GameObject tree;
    public GameObject noGetQst;
    public GameObject doneQst;
    public Text treeName;
    public Text ChatText;
    public Image compensation;
    public string writerText = "";

    public float waitTime =0.01f;
    int escape = 1;
    
    bool click = false;
    bool end = false;

    // GameManager;
    [SerializeField]
    Lia_face face;

    void Start()
    {
        //GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        //face = gameObject.GetComponent<Lia_face>();
        if(GameManager.instance.saveData.TreeQuest ==true)
        {
            noGetQst.SetActive(false);
        }

        if(GameManager.instance.saveData.isTreeQuest2 == true)
        {
            doneQst.SetActive(true);
        }
    }
    
    public void startChat() {
        if(GameManager.instance.saveData.TreeQuest == false)
        {
            StartCoroutine(chating());
        }

        if(GameManager.instance.saveData.TreeQuest == true && GameManager.instance.saveData.isTreeQuest1 == false)
        {
            StartCoroutine(AfterAcceptChat());
        }
        
        if(GameManager.instance.saveData.isTreeQuest1 == true && GameManager.instance.saveData.StartNextQuest == false)
        {
            StartCoroutine(QuestComplete());
        }

        if(GameManager.instance.saveData.StartNextQuest == true)
        {
            StartCoroutine(NoCompleteQst2());
        }

        if(GameManager.instance.saveData.isTreeQuest2 == true)
        {
            StartCoroutine(Quest2Complete());
        }
    }

   public IEnumerator NormalChat(string narrator, string narration)
    {
        ChatBar.SetActive(true);
        int a = 0;
        treeName.text = narrator;
        writerText = "";

        if(narrator =="나무정령")
            tree.SetActive(true);

        else
            tree.SetActive(false);

        for (a = 0; a < narration.Length; a++)
        {
            writerText += narration[a];
            ChatText.text = writerText;
            yield return new WaitForSeconds(waitTime);
            
        }
        if(end == false)
        {
            click = false;
            yield return new WaitUntil(()=>click==true);
        }
        
    }

    public void next()
    {
        click = true;
    }
    public IEnumerator wait()
    {
        yield return new WaitForSeconds(2f);
        ChatBar.SetActive(false);
        tree.SetActive(false);
        GameObject.Find("TOP1").GetComponent<testPlayer>().mainUI.SetActive(true);
        escape = 1;
    }


    public IEnumerator chating()
    {
        yield return StartCoroutine(NormalChat("나무정령", "안녕? 나는 나무 정령이야. 혹시 내 부탁 좀 들어주지 않을래?"));
        face.none();
        yield return StartCoroutine(NormalChat("리아", "안녕? 숲 속에 이런 곳이 있었구나?"));
        face.af();
        yield return StartCoroutine(NormalChat("나무정령", "너는... 가만보니 빨간 지붕에 사는 아이구나!?"));
        face.shock();
        yield return StartCoroutine(NormalChat("리아", "나를 알고 있어?"));
        face.af();
        yield return StartCoroutine(NormalChat("나무정령", "당연하지! 저 빨간 지붕에서 살았던 남자가\n매일 이곳에 와서 수련하고 갔었어~"));
        face.shock();
        yield return StartCoroutine(NormalChat("리아", "우리 집에 사는 남자...? ...혹시 아빠?"));
        face.af();
        yield return StartCoroutine(NormalChat("나무정령", "그래~ 원래 난 청의 가문의 사람이었지만 여행하는 걸 좋아해서 다니다가\n이 숲을 발견하고 눌러 앉아버렸어~"));
        yield return StartCoroutine(NormalChat("나무정령", "처음 이곳에 왔을 때는 몬스터가 이렇게 많지 않았는데\n그 남자는 여기서 맨날 칼을 갖고 열심히 수련했었지..."));
        yield return StartCoroutine(NormalChat("나무정령", "최근에는 그러고보니 모습을 통 못봤네."));
        face.disappoint();
        yield return StartCoroutine(NormalChat("리아", "응... 아빠는 이곳을 떠난지 꽤 오래 됐어."));
        yield return StartCoroutine(NormalChat("리아", "꽤 어릴 때 부터 나랑 엄마를 두고 가셨거든."));
        face.af();
        yield return StartCoroutine(NormalChat("나무정령", "그래? 아내랑 딸을 정말 아끼고 사랑하는 것 같았는데..."));
        yield return StartCoroutine(NormalChat("나무정령", "그러고 보니, 그 사람, 마지막으로 봤을 때\n가족을 지키기 위해서 먼 여행을 떠날 거라는 말을 한적이 있는 것 같아."));
        face.shock();
        yield return StartCoroutine(NormalChat("리아", "가족을 지키기 위해...?"));
        face.af();
        yield return StartCoroutine(NormalChat("나무정령", "뭐, 자세한 건 잘 모르겠지만..."));
        end = true;
        yield return StartCoroutine(NormalChat("나무정령", "어쨌든, 내 부탁을 좀 들어줄 수 있어?\n들어주면 보상은 확실하게 해줄게!"));
        select.SetActive(true);
        end = false;
        

    }

    public IEnumerator acceptChat()
    {
        end = false;
        noGetQst.SetActive(false);
        select.SetActive(false);
        tree.SetActive(true);
        yield return StartCoroutine(NormalChat("나무정령", "고마워! 수련장1에 몬스터들이 너무 많아져서 나무들이 아파하고 있어.\r\n " +
            "수련장1로 가서 몬스터들을 물리치고 묽은 물방울 5개를 가져와 줄래?"));
        tree.SetActive(false);
        face.sad();
        yield return StartCoroutine(NormalChat("리아", "하지만 난 무기를 갖고 있지 않은걸?"));
        tree.SetActive(true);
        face.af();
        yield return StartCoroutine(NormalChat("나무정령", "앗 그러면 수련장1에 사과 나무가 있는데\r\n 흔들어서 나뭇가지를 가져 오면 무기를 줄게!"));
        ChatBar.SetActive(false);
        tree.SetActive(false);
        GameObject.Find("TOP1").GetComponent<testPlayer>().mainUI.SetActive(true);
        GameManager.instance.QuestBox.SetActive(true);
        GameManager.instance.saveData.TreeQuest = true;
        GameManager.instance.SaveData();
        //string jsonData = JsonUtility.ToJson(GameManager.instance.saveData);
        //File.WriteAllText(Application.persistentDataPath + "/Data.json", jsonData);
    }

    public void escapeQ()
    {
        if (escape == 1)
        {
            StartCoroutine(NormalChat("나무정령", "정말 거절할거야? 내 부탁을 들어주면 보상을 해줄게!"));
            escape += 1;
        }

        else if (escape == 2)
        {
            StartCoroutine(NormalChat("나무정령", "알겠어..."));
            select.SetActive(false);
            StartCoroutine(wait());

        }
    }

    public void acceptQ()
    {
        StartCoroutine(acceptChat());
    }

    public IEnumerator QuestComplete()
    {
        end = false;
        yield return StartCoroutine(NormalChat("나무정령", "나무로 만든 나무 막대기를 줄게!"));
        yield return StartCoroutine(NormalChat("나무정령", "그리고 획득한 사과를 단축기 등록하면\n체력을 높일 수 있어!"));
        StartCoroutine(Fade());
        ChatBar.SetActive(false);
        tree.SetActive(false);
        GameObject.Find("TOP1").GetComponent<testPlayer>().mainUI.SetActive(true);
        GameManager.instance.saveData.StartNextQuest = true;
        string jsonData = JsonUtility.ToJson(GameManager.instance.saveData);
        File.WriteAllText(Application.persistentDataPath + "/Data.json", jsonData);
        GameManager.instance.QuestBox.SetActive(false);
        GameManager.instance.QuestBox2.SetActive(true);
        

    }

    public IEnumerator Quest2Complete()
    {
        end = false;
        yield return StartCoroutine(NormalChat("나무정령", "그러고 보니 휘두르는 자세가\n네 아버지랑 정말 똑같네!"));
        yield return StartCoroutine(NormalChat("나무정령", "너라면 더 강해질 수 있을거야!"));
        yield return StartCoroutine(NormalChat("나무정령", "아, 그러고 보니 숲1에서 비명 소리가 들렸는데\n무슨일이 생긴 건지 잘 모르겠네"));
        face.none();
        yield return StartCoroutine(NormalChat("리아", "요정이면 하늘을 날아서 볼 수 있는 거 아니야?"));
        face.af();
        yield return StartCoroutine(NormalChat("나무정령", "이래뵈도 난 나이가 꽤 많아서\n그렇게 높이까지 날아딘ㄹ 수 없어!"));
        yield return StartCoroutine(NormalChat("나무정령", "리아 네가 숲2로 가서 확인해 보는 게 좋겠어"));
        ChatBar.SetActive(false);
        tree.SetActive(false);
        
    }

    public IEnumerator AfterAcceptChat()
    {
        ChatBar.SetActive(true);
        yield return StartCoroutine(NormalChat("나무정령", "나뭇가지 3개와 사과 10개를 가지고 오면 무기를 만들어줄게"));
        tree.SetActive(false);
        ChatBar.SetActive(false);
        GameObject.Find("TOP1").GetComponent<testPlayer>().mainUI.SetActive(true);
    }

    public IEnumerator NoCompleteQst2()
    {
        yield return StartCoroutine(NormalChat("나무정령", "몬스터를 물리치고 묽은 물방울 5개를 가져와줘"));
        GameObject.Find("TOP1").GetComponent<testPlayer>().mainUI.SetActive(true);
        tree.SetActive(false);
        ChatBar.SetActive(false);
    }

    IEnumerator Fade()
    {
        compensation.gameObject.SetActive(true);
        float fadeCount = 0;
        while (fadeCount <0.5f)
        {
            fadeCount +=0.01f;
            yield return new WaitForSeconds(0.005f);
            compensation.color = new Color(1,1,1, fadeCount);
        }
        yield return new WaitForSeconds(1.3f);
        while(fadeCount>0)
        {
            fadeCount -= 0.02f;
            yield return new WaitForSeconds(0.005f);
            compensation.color = new Color(1,1,1, fadeCount);
        }

        compensation.gameObject.SetActive(false);
    }
    
}
