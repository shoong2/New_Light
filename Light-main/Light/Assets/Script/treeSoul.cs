using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class treeSoul : MonoBehaviour
{
    public GameObject ChatBar;
    public GameObject select;
    public GameObject tree;
    public GameObject Lia_sad;
    public Text treeName;
    public Text ChatText;
    public string writerText = "";
    int escape = 1;
    bool click = false;

    story chat;
    public void startChat() {
        select.SetActive(true);
        StartCoroutine(NormalChat("나무정령", "안녕? 나는 나무 정령이야. 혹시 내 부탁 좀 들어주지 않을래?"));
        //chat.NormalChat("나무정령", "안녕? 나는 나무 정령이야. 혹시 내 부탁 좀 들어주지 않을래?");
    }

   public IEnumerator NormalChat(string narrator, string narration)
    {
        ChatBar.SetActive(true);
        int a = 0;
        treeName.text = narrator;
        writerText = "";

        // if(narrator =="리아")
        //     Ria.SetActive(true);

        // else
        //     Ria.SetActive(false);
        //텍스트 타이핑 효과
        for (a = 0; a < narration.Length; a++)
        {
            writerText += narration[a];
            ChatText.text = writerText;
            yield return null;
            
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
        GameObject.Find("TOP1").GetComponent<testPlayer>().mainUI.SetActive(true);
        escape = 1;
    }

    public IEnumerator acceptChat()
    {
        select.SetActive(false);
        tree.SetActive(true);
        yield return StartCoroutine(NormalChat("나무정령","고마워! 수련장1에 몬스터 들이 너무 많아져서 나무들이 너무 아파하고 있어.\r\n 수련장1로 가서 모든 몬스터 들을 물리치고 묽은 물방울 5개를 가져와 줄래?"));
        yield return new WaitUntil(()=>click==true);
        tree.SetActive(false);
        Lia_sad.SetActive(true);
        yield return StartCoroutine(NormalChat("리아", "하지만 난 무기를 갖고 있지 않은걸?"));
        click = false;
        yield return new WaitUntil(()=>click==true);
        Lia_sad.SetActive(false);
        tree.SetActive(true);
        yield return StartCoroutine(NormalChat("나무정령", "앗 그러면 수련장1에 사과 나무가 있는데\r\n 흔들어서 나뭇가지를 가져 오면 무기를 줄게!"));
        click = false;
        yield return new WaitUntil(()=>click==true);
        ChatBar.SetActive(false);
        tree.SetActive(false);
        click = false;
        GameObject.Find("TOP1").GetComponent<testPlayer>().mainUI.SetActive(true);
    }

    public void acceptQ()
    {
        StartCoroutine(acceptChat());
    }

    public void escapeQ()
    {
        if(escape ==1)
        {
            StartCoroutine(NormalChat("나무정령", "정말 거절할거야? 내 부탁을 들어주면 보상을 해줄게!"));
            escape +=1;
        }
    
        else if(escape == 2)
        {
            StartCoroutine(NormalChat("나무정령", "알겠어..."));
            select.SetActive(false);
            StartCoroutine(wait());
            
        }
    }
    
}
