using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Chat1 : MonoBehaviour
{
    public Text ChatText; // 실제 채팅이 나오는 텍스트
    public Text CharacterName; // 캐릭터 이름이 나오는 텍스트


    public List<KeyCode> skipButton; // 대화를 빠르게 넘길 수 있는 키

    public string writerText = "";

    bool isButtonClicked = false;

    void Start()
    {
        StartCoroutine(TextPractice());
    }

    void Update()
    {
        foreach (var element in skipButton) // 버튼 검사
        {
            if (Input.GetKeyDown(element))
            {
                isButtonClicked = true;
            }
        }
    }

    
    
    IEnumerator NormalChat(string narrator, string narration)
    {
        
        int a = 0;
        CharacterName.text = narrator;
        writerText = "";

        //텍스트 타이핑 효과
        for (a = 0; a < narration.Length; a++)
        {
            writerText += narration[a];
            ChatText.text = writerText;
            yield return null;
            
        }

        //키를 다시 누를 떄 까지 무한정 대기
        while(true)
        {
            if (isButtonClicked)
            {
            
                isButtonClicked = false;
                break;
                
            }
            
            yield return null;
            
        }
    }

    IEnumerator TextPractice()
    {
        yield return StartCoroutine(NormalChat("엄마", "리아야...!"));
        yield return StartCoroutine(NormalChat("리아", "!?"));
        yield return StartCoroutine(NormalChat("엄마", "악몽이라도 꿨니?"));
        yield return StartCoroutine(NormalChat("리아", "아... 그런건 아닌데..."));
        yield return StartCoroutine(NormalChat("엄마", "서쪽 숲으로 가서 먹을 것 좀 구해 오렴. 몬스터 조심 하는 것 잊지 말고"));
    }
}
