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
            else if( GameManager.instance.saveData.chatHelper == 3)
            {
                StartCoroutine(NoCompleteQ2());
            }
        }
    }

    public IEnumerator NyleQuestChat_1()
    {
        yield return StartCoroutine(NormalChat("����", "�������̾� ����?"));
        yield return StartCoroutine(NormalChat("����", "�� ��� �ִ°ž�?"));
        yield return StartCoroutine(NormalChat("����", "���� ���� ���ؼ� ������ ���� ���̾��µ�\n" +
            "��û���� ū ���Ͱ� �� ������ ��ư���...!"));
        yield return StartCoroutine(NormalChat("����", "���� �����ٱ�?"));
        yield return StartCoroutine(NormalChat("����", "���� �װ� ��� ���͸� ������?\n" +
            "�� �װ� �ο�� ����� �� ���� ���µ�?"));
        yield return StartCoroutine(NormalChat("����", "�� �Ʊ� ���͵� ����ġ�� �Դ°�?","embarrassed"));   
        yield return StartCoroutine(NormalChat("����", "�׷� �����غ�! ���� ���� ���� ��, ��2 ���� ���͸� ����ġ��\n" +
            "£�� �����, ��� �����, ��ο� ������� 1���� �������� �������ٰ�!"));

        GameManager.instance.saveData.mainQuestText = "������ ��Ź1";
        GameManager.instance.saveData.QuestDetailText = "����, Ǫ��, ���� ����ġ�� ������ ������� ������ " +
            "\n���Ͽ��� �������� �Ƿ��� �����غ���.";

        GameManager.instance.saveData.nyleQuest1 = true;
        GameManager.instance.UpdateQuestUI();
        GameManager.instance.UpdateUI();
        GameManager.instance.SaveData();
        EndChat();
    }

    public IEnumerator NoCompleteQ1()
    {
        end = false;
        yield return StartCoroutine(NormalChat("����", "�� ����, Ǫ��, ���� ������� 1���� �����ͺ�!"));
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
        StartCoroutine(Fade(AddNylePopUp));
        GameManager.instance.saveData.chatHelper++;
        GameManager.instance.saveData.mainQuestText = "������ ��Ź2";
        GameManager.instance.saveData.QuestDetailText = "��� ���� ����ġ�� ������ ���Ϸ� ����.";
        GameManager.instance.saveData.nyleQuest2 = true;
        GameManager.instance.UpdateQuestUI();
        GameManager.instance.UpdateUI();
        GameManager.instance.SaveData();
        EndChat();
    }

    public IEnumerator NoCompleteQ2()
    {
        end = false;
        yield return StartCoroutine(NormalChat("����", "�� ������ ��� �ֿ��� ��������!"));
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
