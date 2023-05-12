using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class BossMap : MonoBehaviour
{
    public float waitTime = 0.01f;

    bool click = false;
    bool end = false;

    public GameObject chatBar;
    public GameObject acceptPopUp;

    public TMP_Text chatName;
    public TMP_Text chatText;

    public string writerText;

    public Lia_face face;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag =="Player")
        {
            GameObject.Find("Joystick").GetComponent<JoyStick1>().InitTrigger();
            GameObject.Find("TOP1").GetComponent<testPlayer>().moveSpeed = 0;
            if (GameManager.instance.saveData.nyleQuest2 == false)
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
        GameObject.Find("Joystick").GetComponent<JoyStick1>().InitTrigger();


    }

    public void Accept()
    {
        EndChat();
        SceneManager.LoadScene("Fight");
    }

    public void Deny()
    {
        acceptPopUp.SetActive(false);
        face.af();
        GameObject.Find("TOP1").GetComponent<testPlayer>().moveSpeed = 3;
        EndChat();
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
        GameObject.Find("TOP1").GetComponent<testPlayer>().mainUI.SetActive(false);
        yield return StartCoroutine(NormalChat("리아", "여기는 아직 들어갈 수 없어..."));
        yield return new WaitForSeconds(1.2f);
        GameObject.Find("TOP1").GetComponent<testPlayer>().moveSpeed = 3;
        EndChat();
    }

    IEnumerator GoBossMap()
    {
        GameObject.Find("TOP1").GetComponent<testPlayer>().mainUI.SetActive(false);
        acceptPopUp.SetActive(true);
        yield return StartCoroutine(NormalChat("리아", "어두운 기운이 감돌고 있어... \n정말 이쪽으로 들어갈까?"));
        EndChat();
    }


}
