using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Nyle : MonoBehaviour
{
    public GameObject chatBar;
    public GameObject nyle;


    public Text chatName;
    public Text chatText;
    public string writerText = "";

    public float waitTime = 0.01f;

    bool click = false;
    bool end = false;

    public Image AddNylePopUp;


 
    public Lia_face face;
    public IEnumerator NormalChat(string narrator, string narration, string face ="none")
    {
        chatBar.SetActive(true);
        int a = 0;
        chatName.text = narrator;
        writerText = "";

        if (narrator == "나일")
        {
            this.face.af();
            nyle.SetActive(true);
        }

        else
        {
            nyle.SetActive(false);
            if (face == "none")
                this.face.none();
            else if (face == "embarrassed")
                this.face.embarrassed();
        }

        for (a = 0; a < narration.Length; a++)
        {
            writerText += narration[a];
            chatText.text = writerText;
            yield return new WaitForSeconds(waitTime);

        }
        if (end == false)
        {
            click = false;
            yield return new WaitUntil(() => click == true);
        }

    }

    public void next()
    {
        click = true;
    }

    void EndChat()
    {
        end = true;
        chatBar.SetActive(false);
        nyle.SetActive(false);
        GameObject.Find("TOP1").GetComponent<testPlayer>().mainUI.SetActive(true);
    }

    public void StartNyleChat()
    {
        if(GameManager.instance.saveData.startNyle == true)
        {
            if (GameManager.instance.saveData.chatHelper == 0)
            {
                GameManager.instance.saveData.chatHelper++;
                GameManager.instance.SaveData();
                StartCoroutine(NyleQuestChat_1());
                
            }
            else if (GameManager.instance.saveData.chatHelper == 1)
            {
                StartCoroutine(NoCompleteQ1());
            }
            else if (GameManager.instance.saveData.chatHelper == 2)
            {
                StartCoroutine(CompleteQ1());
            }
            else if( GameManager.instance.saveData.chatHelper == 3)
            {
                StartCoroutine(NoCompleteQ2());
            }
        }
    }

    public IEnumerator NyleQuestChat_1()
    {
        yield return StartCoroutine(NormalChat("리아", "무슨일이야 나일?"));
        yield return StartCoroutine(NormalChat("리아", "왜 울고 있는거야?"));
        yield return StartCoroutine(NormalChat("나일", "먹을 것을 구해서 집으로 가는 길이었는데\n" +
            "엄청나게 큰 몬스터가 내 동생을 잡아갔어...!"));
        yield return StartCoroutine(NormalChat("리아", "내가 도와줄까?"));
        yield return StartCoroutine(NormalChat("나일", "리아 네가 어떻게 몬스터를 물리쳐?\n" +
            "난 네가 싸우는 모습을 본 적이 없는데?"));
        yield return StartCoroutine(NormalChat("리아", "난 아까 몬스터도 물리치고 왔는걸?","embarrassed"));   
        yield return StartCoroutine(NormalChat("나일", "그럼 증명해봐! 북쪽 숲과 남쪽 숲, 숲2 에서 몬스터를 물리치고\n" +
            "짙은 물방울, 잿빛 물방울, 어두운 물방울을 1개씩 가져오면 인정해줄게!"));

        GameManager.instance.saveData.mainQuestText = "나일의 부탁1";
        GameManager.instance.saveData.QuestDetailText = "추추, 푸링, 밍을 물리치고 나오는 물방울을 가지고 " +
            "\n나일에게 가져가서 실력을 증명해보자.";

        GameManager.instance.saveData.nyleQuest1 = true;
        GameManager.instance.UpdateQuestUI();
        GameManager.instance.UpdateUI();
        GameManager.instance.SaveData();
        EndChat();
    }

    public IEnumerator NoCompleteQ1()
    {
        end = false;
        yield return StartCoroutine(NormalChat("나일", "얼른 추추, 푸링, 밍의 물방울을 1개씩 가져와봐!"));
        EndChat();
    }


    public IEnumerator CompleteQ1()
    {
        end = false;
        yield return StartCoroutine(NormalChat("나일", "너.. 정말 강한 사람이었구나? 아까 내가 말한 건 잊어줘..."));
        yield return StartCoroutine(NormalChat("나일", "그리고 미안하니까 내가 알고 있는 정보를 알려줄게"));
        yield return StartCoroutine(NormalChat("나일", "모든 종류의 몬스터들에게서 물방울들을 각각 1개씩 얻어서\n" +
            "무기를 우물에 빠트리면 신령이 나타나서 더 좋은 걸로 바꿔준다는 소문이 있어!"));
        yield return StartCoroutine(NormalChat("나일", "한번 시도해봐!"));
        face.embarrassed();
        yield return StartCoroutine(NormalChat("리아", "그렇구나! 고마워!"));
        face.af();
        yield return StartCoroutine(NormalChat("나일", "그리고... 혹시 나 좀 도와줄 수 있을까?"));
        face.none();
        yield return StartCoroutine(NormalChat("리아", "물론이지!"));
        face.af();
        yield return StartCoroutine(NormalChat("나일", "정말 고마워! 내 동생이 대왕 밍에게 잡혀갔어!\n아마 숲 속 어딘가에 있을거야..."));
        yield return StartCoroutine(NormalChat("나일", "나랑 같이 동생을 구하러 가지 않을래?"));
        yield return StartCoroutine(NormalChat("나일", "너라면 충분히 강하니까 같이 싸우면 대왕 밍을 이길 수 있을지도 몰라!"));
        StartCoroutine(Fade(AddNylePopUp));
        GameManager.instance.saveData.chatHelper++;
        GameManager.instance.saveData.mainQuestText = "나일의 부탁2";
        GameManager.instance.saveData.QuestDetailText = "대왕 밍을 물리치고 동생을 구하러 가자.";
        GameManager.instance.saveData.nyleQuest2 = true;
        GameManager.instance.UpdateQuestUI();
        GameManager.instance.UpdateUI();
        GameManager.instance.SaveData();
        EndChat();
    }

    public IEnumerator NoCompleteQ2()
    {
        end = false;
        yield return StartCoroutine(NormalChat("나일", "내 동생이 대왕 밍에게 잡혀갔어!"));
        EndChat();
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

}
