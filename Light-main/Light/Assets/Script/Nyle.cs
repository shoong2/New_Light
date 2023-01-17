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
        if(GameManager.instance.saveData.allTreeQuest == true)
        {
            StartCoroutine(NyleQuestChat_1());
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
}
