using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class BossMap : MonoBehaviour
{
    public float waitTime = 0.01f;

    bool click = false;
    bool end = false;

    public GameObject chatBar;

    public TMP_Text chatName;
    public TMP_Text chatText;

    public string writerText;

    public Lia_face face;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag =="Player")
        {
            if(GameManager.instance.saveData.nyleQuest2 == false)
            {
                StartCoroutine(NoBossMap());
            }
            else
            {
                StartCoroutine(GoBossMap());
            }
        }
    }

    public void Next()
    {
        click = true;
    }

    void EndChat()
    {
        end = true;
        chatBar.SetActive(false);
        //nyle.SetActive(false);
        GameObject.Find("TOP1").GetComponent<testPlayer>().mainUI.SetActive(true);
    }

    public IEnumerator NormalChat(string narrator, string narration, string face = "none")
    {
        chatBar.SetActive(true);
        int a = 0;
        chatName.text = narrator;
        writerText = "";

        if (narrator == "나일")
        {
            this.face.af();
            //nyle.SetActive(true);
        }

        else
        {
            //nyle.SetActive(false);
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

    IEnumerator NoBossMap()
    {
        end = false;
        yield return StartCoroutine(NormalChat("리아", "여기는 아직 들어갈 수 없어..."));
        EndChat();
    }

    IEnumerator GoBossMap()
    {
        yield return StartCoroutine(NormalChat("리아", "어두운 기운이 감돌고 있어... \n정말 이쪽으로 들어갈까?"));
        EndChat();
    }


}
