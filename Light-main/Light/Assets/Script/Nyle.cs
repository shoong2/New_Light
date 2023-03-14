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


 
    public Lia_face face;
    public IEnumerator NormalChat(string narrator, string narration)
    {
        chatBar.SetActive(true);
        int a = 0;
        chatName.text = narrator;
        writerText = "";

        if (narrator == "나일")
            nyle.SetActive(true);

        else
            nyle.SetActive(false);

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
        }
    }

    public IEnumerator NyleQuestChat_1()
    {
        face.none();
        yield return StartCoroutine(NormalChat("리아", "무슨일이야 나일?"));
        yield return StartCoroutine(NormalChat("리아", "왜 울고 있는거야?"));
        face.af();
        yield return StartCoroutine(NormalChat("나일", "먹을 것을 구해서 집으로 가는 길이었는데\n" +
            "엄청나게 큰 몬스터가 내 동생을 잡아갔어...!"));
        face.none();
        yield return StartCoroutine(NormalChat("리아", "내가 도와줄까?"));
        face.af();
        yield return StartCoroutine(NormalChat("나일", "리아 네가 어떻게 몬스터를 물리쳐?\n" +
            "난 네가 싸우는 모습을 본 적이 없는데?"));
        face.embarrassed();
        yield return StartCoroutine(NormalChat("리아", "난 아까 몬스터도 물리치고 왔는걸?"));
        face.af();
       
        yield return StartCoroutine(NormalChat("나일", "그럼 증명해봐! 북쪽 숲과 남쪽 숲, 숲2 에서 몬스터를 물리치고\n" +
            "짙은 물방울, 잿빛 물방울, 어두운 물방울을 1개씩 가져오면 인정해줄게!"));
        end = true;
        chatBar.SetActive(false);
        nyle.SetActive(false);
        GameObject.Find("TOP1").GetComponent<testPlayer>().mainUI.SetActive(true);
    }

    public IEnumerator NoCompleteQ1()
    {
        end = false;
        yield return StartCoroutine(NormalChat("나일", "얼른 추추, 푸링, 밍의 물방울을 1개씩 가져와봐!"));

        end = true;
        chatBar.SetActive(false);
        nyle.SetActive(false);
        GameObject.Find("TOP1").GetComponent<testPlayer>().mainUI.SetActive(true);
    }


    public IEnumerator CompleteQ1()
    {
        end = false;
        yield return StartCoroutine(NormalChat("나일", "너.. 정말 강한 사람이었구나? 아까 내가 말한 건 잊어줘..."));
        yield return StartCoroutine(NormalChat("나일", "그리고 미안하니까 내가 알고 있는 정보를 알려줄게"));
        yield return StartCoroutine(NormalChat("나일", "모든 종류의 몬스터들에게서 물방울들을 각각 1개씩 얻어서\n" +
            "한 가지 무기를 우물에 빠트리면 신령이 나타나서 더 좋은 걸로 바꿔준다는 소문이 있어! 한번 시도해봐!"));
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

        end = true;
        chatBar.SetActive(false);
        nyle.SetActive(false);
        GameObject.Find("TOP1").GetComponent<testPlayer>().mainUI.SetActive(true);
    }

}
