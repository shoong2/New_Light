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
    public IEnumerator NormalChat(string narrator, string narration, string face ="none")
    {
        chatBar.SetActive(true);
        int a = 0;
        chatName.text = narrator;
        writerText = "";

        if (narrator == "����")
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
        }
    }

    public IEnumerator NyleQuestChat_1()
    {
        //face.none();
        yield return StartCoroutine(NormalChat("����", "�������̾� ����?"));
        yield return StartCoroutine(NormalChat("����", "�� ��� �ִ°ž�?"));
        //face.af();
        yield return StartCoroutine(NormalChat("����", "���� ���� ���ؼ� ������ ���� ���̾��µ�\n" +
            "��û���� ū ���Ͱ� �� ������ ��ư���...!"));
        //face.none();
        yield return StartCoroutine(NormalChat("����", "���� �����ٱ�?"));
        //face.af();
        yield return StartCoroutine(NormalChat("����", "���� �װ� ��� ���͸� ������?\n" +
            "�� �װ� �ο�� ����� �� ���� ���µ�?"));
        //face.embarrassed();
        yield return StartCoroutine(NormalChat("����", "�� �Ʊ� ���͵� ����ġ�� �Դ°�?","embarrassed"));
        //face.af();
       
        yield return StartCoroutine(NormalChat("����", "�׷� �����غ�! ���� ���� ���� ��, ��2 ���� ���͸� ����ġ��\n" +
            "£�� �����, ��� �����, ��ο� ������� 1���� �������� �������ٰ�!"));

        GameManager.instance.saveData.mainQuestText = "������ ��Ź1";
        GameManager.instance.saveData.QuestDetailText = "����, Ǫ��, ���� ����ġ�� ������ ������� ������ " +
            "\n���Ͽ��� �������� �Ƿ��� �����غ���.";

        GameManager.instance.saveData.nyleQuest1 = true;
        GameManager.instance.UpdateQuestUI();
        GameManager.instance.UpdateUI();
        GameManager.instance.SaveData();
        //end = true;
        //chatBar.SetActive(false);
        //nyle.SetActive(false);
        //GameObject.Find("TOP1").GetComponent<testPlayer>().mainUI.SetActive(true);
        EndChat();
    }

    public IEnumerator NoCompleteQ1()
    {
        end = false;
        yield return StartCoroutine(NormalChat("����", "�� ����, Ǫ��, ���� ������� 1���� �����ͺ�!"));

        //end = true;
        //chatBar.SetActive(false);
        //nyle.SetActive(false);
        //GameObject.Find("TOP1").GetComponent<testPlayer>().mainUI.SetActive(true);
        EndChat();
    }


    public IEnumerator CompleteQ1()
    {
        end = false;
        yield return StartCoroutine(NormalChat("����", "��.. ���� ���� ����̾�����? �Ʊ� ���� ���� �� �ؾ���..."));
        yield return StartCoroutine(NormalChat("����", "�׸��� �̾��ϴϱ� ���� �˰� �ִ� ������ �˷��ٰ�"));
        yield return StartCoroutine(NormalChat("����", "��� ������ ���͵鿡�Լ� �������� ���� 1���� ��\n" +
            "���⸦ �칰�� ��Ʈ���� �ŷ��� ��Ÿ���� �� ���� �ɷ� �ٲ��شٴ� �ҹ��� �־�!"));
        yield return StartCoroutine(NormalChat("����", "�ѹ� �õ��غ�!"));
        face.embarrassed();
        yield return StartCoroutine(NormalChat("����", "�׷�����! ����!"));
        face.af();
        yield return StartCoroutine(NormalChat("����", "�׸���... Ȥ�� �� �� ������ �� ������?"));
        face.none();
        yield return StartCoroutine(NormalChat("����", "��������!"));
        face.af();
        yield return StartCoroutine(NormalChat("����", "���� ����! �� ������ ��� �ֿ��� ��������!\n�Ƹ� �� �� ��򰡿� �����ž�..."));
        yield return StartCoroutine(NormalChat("����", "���� ���� ������ ���Ϸ� ���� ������?"));
        yield return StartCoroutine(NormalChat("����", "�ʶ�� ����� ���ϴϱ� ���� �ο�� ��� ���� �̱� �� �������� ����!"));

        //end = true;
        //chatBar.SetActive(false);
        //nyle.SetActive(false);
        //GameObject.Find("TOP1").GetComponent<testPlayer>().mainUI.SetActive(true);
        EndChat();
    }

}
