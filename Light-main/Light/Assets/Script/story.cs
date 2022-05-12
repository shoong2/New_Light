using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class story : MonoBehaviour
{
    Text text;
    public Text ChatText; // 실제 채팅이 나오는 텍스트
    public Text CharacterName; // 캐릭터 이름이 나오는 텍스트
    public GameObject ChatBar;
    public GameObject grid;
    public GameObject Ria;
    
    public string writerText = "";

    public Image eye;
    public float startChatTime =3;
    public float chatspeed =2;
    float time = 0f;
    float F_time = 1f;
    public float typing =5.0f;

    bool click =false;

   
    void Awake()
    {
        text = GetComponent<Text>();
        StartCoroutine(TextPractice());
        
    }

    public IEnumerator chat(string narration)
    {
        text.text = narration;
        text.color = new Color(text.color.r, text.color.g, text.color.b, 0);
        while (text.color.a < 1.0f)
        {
            text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a + (Time.deltaTime / startChatTime));
            yield return null;
        }
        // StartCoroutine(FadeTextToZero());

        while (text.color.a > 0.0f)
        {
            text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a - (Time.deltaTime / startChatTime));
            yield return null;
        }

        yield return null;
    }

    public IEnumerator NormalChat(string narrator, string narration)
    {
        ChatBar.SetActive(true);
        int a = 0;
        CharacterName.text = narrator;
        writerText = "";

        if(narrator =="리아")
            Ria.SetActive(true);

        else
            Ria.SetActive(false);
        //텍스트 타이핑 효과
        for (a = 0; a < narration.Length; a++)
        {
            writerText += narration[a];
            ChatText.text = writerText;
            yield return new WaitForSeconds(1f/typing);
            
        }
    }

    public IEnumerator Fade()
    {
        eye.gameObject.SetActive(true);
        Color alpha = eye.color;
        
        time = 0f;

        while(alpha.a >0f)
        {
            time += Time.deltaTime / F_time;
            alpha.a = Mathf.Lerp(1,0, time);
            eye.color = alpha;
            yield return null;
        }

        time = 0f;

        while(alpha.a < 1f)
        {
            time += Time.deltaTime / F_time;
            alpha.a = Mathf.Lerp(0, 1, time);
            eye.color = alpha;
            yield return null;
        }

        time = 0f;

        while(alpha.a >0f)
        {
            time += Time.deltaTime / F_time;
            alpha.a = Mathf.Lerp(1,0, time);
            eye.color = alpha;
            yield return null;
        }

        time = 0f;

        while(alpha.a < 1f)
        {
            time += Time.deltaTime / F_time;
            alpha.a = Mathf.Lerp(0, 1, time);
            eye.color = alpha;
            yield return null;
        }

       

        eye.gameObject.SetActive(false);
        yield return null;
    }

    public void wait()
    {
        click = true;
    }

   

    // public IEnumerator FadeTextToZero()  // 알파값 1에서 0으로 전환
    // {
    //     text.color = new Color(text.color.r, text.color.g, text.color.b, 1);
    //     while (text.color.a > 0.0f)
    //     {
    //         text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a - (Time.deltaTime / 2.0f));
    //         yield return null;
    //     }
    //     // StartCoroutine(TextPractice());
    // }

    public IEnumerator TextPractice()
    {
        yield return StartCoroutine(chat("이곳은 평화로운 마을 이었지만 '빛의 기둥' 이 생기고 나서 부터\n 사람들에게 해를 가하는 몬스터들이 생겨나기 시작했다.."));
        yield return StartCoroutine(chat("이 몬스터들을 토벌하고 이 '빛의 기둥'을 없애기 위해 \n왕궁에서 영웅들을 차출하여 파견하였으나 실패하였고,\n왕궁의 힘은 점점 약해져갔다."));
        yield return StartCoroutine(chat("그 와중에 급진 무력파인 '십자가 군단' 이 권력을 잡게 되면서 \n아이들을 무작위로 강제 징용하기 시작하였다...."));
        yield return new WaitForSeconds(1f);
        yield return StartCoroutine(NormalChat("???" , "살려줘...!"));
        yield return new WaitUntil(()=>click==true);
        yield return StartCoroutine(NormalChat("리아" , "...누구?"));
        click = false;
        yield return new WaitUntil(()=>click==true);
        yield return StartCoroutine(NormalChat("???" , "살려줘.....!"));
        click = false;
        yield return new WaitUntil(()=>click==true);
        yield return StartCoroutine(NormalChat("리아" , "누구세요....?"));
        click = false;
        yield return new WaitUntil(()=>click==true);
        yield return StartCoroutine(NormalChat("???" , "이대로 죽고싶지 않아...."));
        click = false;
        yield return new WaitUntil(()=>click==true);
        yield return StartCoroutine(NormalChat("리아" , ".......?"));
        click = false;
        yield return new WaitUntil(()=>click==true);
        ChatBar.SetActive(false);
        Ria.SetActive(false);
        yield return new WaitForSeconds(1f);
        grid.SetActive(true);
        yield return StartCoroutine(Fade());
        yield return new WaitForSeconds(1f);
        ChatBar.SetActive(true);
        yield return StartCoroutine(NormalChat("엄마" , "리아야...!"));
        click = false;
        yield return new WaitUntil(()=>click==true);
        yield return StartCoroutine(NormalChat("리아" , "!?"));
        click = false;
        yield return new WaitUntil(()=>click==true);
        yield return StartCoroutine(NormalChat("엄마" , "악몽이라도 꿨니?"));
        click = false;
        yield return new WaitUntil(()=>click==true);
        yield return StartCoroutine(NormalChat("리아" , "아... 그런건 아닌데..."));
        click = false;
        yield return new WaitUntil(()=>click==true);
        yield return StartCoroutine(NormalChat("엄마" , "먹을 것 좀 구해오렴. 몬스터 조심 하는 것 잊지 말고"));
        click = false;
        yield return new WaitUntil(()=>click==true);
        SceneManager.LoadScene("main");

        
        
    }
}