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

        if (narrator == "����")
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
        yield return StartCoroutine(NormalChat("����", "�������̾� ����?"));
        yield return StartCoroutine(NormalChat("����", "�� ��� �ִ°ž�?"));
        face.af();
        yield return StartCoroutine(NormalChat("����", "���� ���� ���ؼ� ������ ���� ���̾��µ�\n" +
            "��û���� ū ���Ͱ� �� ������ ��ư���...!"));
        face.none();
        yield return StartCoroutine(NormalChat("����", "���� �����ٱ�?"));
        face.af();
        yield return StartCoroutine(NormalChat("����", "���� �װ� ��� ���͸� ������?\n" +
            "�� �װ� �ο�� ����� �� ���� ���µ�?"));
        face.embarrassed();
        yield return StartCoroutine(NormalChat("����", "�� �Ʊ� ���͵� ����ġ�� �Դ°�?"));
        face.af();
       
        yield return StartCoroutine(NormalChat("����", "�׷� �����غ�! ���� ���� ���� ��, ��2 ���� ���͸� ����ġ��\n" +
            "£�� �����, ��� �����, ��ο� ������� 1���� �������� �������ٰ�!"));
        end = true;
        chatBar.SetActive(false);
        nyle.SetActive(false);
        GameObject.Find("TOP1").GetComponent<testPlayer>().mainUI.SetActive(true);
    }
}
