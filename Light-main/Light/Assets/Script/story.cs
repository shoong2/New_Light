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
    public GameObject outgrid;
    //public GameObject Lia;
    public GameObject mom;
    Lia_face face;
    // public GameObject Lia_ang;
    // public GameObject Lia_emb;
    // public GameObject Lia_disa;
    // public GameObject Lia_shock;
    
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
        face = GameObject.Find("Lia_face").GetComponent<Lia_face>();
        
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

        // if(narrator =="리아")
        //     Lia.SetActive(true);

        // else
        //     Lia.SetActive(false);
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


    public IEnumerator gridfade()
    {
        float fadeCount = 1;
        while(fadeCount>0)
        {
            fadeCount -= 0.01f;
            yield return new WaitForSeconds(0.01f);
            eye.color = new Color(0,0,0, fadeCount);
        }

        eye.gameObject.SetActive(false);
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
        yield return new WaitForSeconds(1f);
        grid.SetActive(true);
        yield return StartCoroutine(Fade());
        yield return new WaitForSeconds(1f);
        ChatBar.SetActive(true);
        mom.SetActive(true);
        yield return StartCoroutine(NormalChat("엄마" ,  "악몽이라도 꿨니?"));
        click = false;
        yield return new WaitUntil(()=>click==true);
        mom.SetActive(false);
        face.shock();
        yield return StartCoroutine(NormalChat("리아" , "아... 그런건 아닌데..."));
        click = false;
        yield return new WaitUntil(()=>click==true);
        yield return StartCoroutine(NormalChat("리아" , "어떤 한 남자를 꿈에서 본 것 같아서요.."));
        click = false;
        yield return new WaitUntil(()=>click==true);
        face.disappoint();
        yield return StartCoroutine(NormalChat("리아" , "엄청 고통스러워 보였는데, 도와주지 못했어요."));
        click = false;
        yield return new WaitUntil(()=>click==true);
        face.af();
        mom.SetActive(true);
        yield return StartCoroutine(NormalChat("엄마" , "그래? 어쩔 수 없지. 그래도 꿈은 반대라고 하니까\n리아가 나중에 구해 줄 수 있을거야."));
        click = false;
        yield return new WaitUntil(()=>click==true);
        yield return StartCoroutine(NormalChat("엄마" , "그나저나 요즘에 몬스터들이 너무 많아져서 걱정이구나..."));
        click = false;
        yield return new WaitUntil(()=>click==true);
        yield return StartCoroutine(NormalChat("리아" , "빛의 기둥이 생긴 뒤로 여기에 사는 이웃 사람들도 다 떠나가던데"));
        click = false;
        yield return new WaitUntil(()=>click==true);
        mom.SetActive(false);
        face.disappoint();
        yield return StartCoroutine(NormalChat("리아" , "저희도 얼른 다른 곳으로 가면 안돼요?"));
        click = false;
        yield return new WaitUntil(()=>click==true);
        yield return StartCoroutine(NormalChat("리아" , "제 친구 나일이도 내일 당장 떠난다고 했는데....!"));
        click = false;
        yield return new WaitUntil(()=>click==true);
        face.af();
        mom.SetActive(true);
        yield return StartCoroutine(NormalChat("엄마" ,"...리아야, 나도 리아와 함께 얼른 이 곳을 떠나고 싶지만,\n 엄마는 이곳에 남아서 기다려야 할 사람이 있단다..."));
        click = false;
        yield return new WaitUntil(()=>click==true);
        mom.SetActive(false);
        face.disappoint();
        yield return StartCoroutine(NormalChat("리아" , "..아빠를 말하는 거예요?"));
        click = false;
        yield return new WaitUntil(()=>click==true);
        face.af();
        mom.SetActive(true);
        yield return StartCoroutine(NormalChat("엄마" , "..."));
        click = false;
        yield return new WaitUntil(()=>click==true);
        mom.SetActive(false);
        face.angry();
        yield return StartCoroutine(NormalChat("리아" , "아빠가 돌아오지 않은지 얼마나 오랜 시간이 지났는데\n 계속 미련하게 기다리고 있어요!?"));
        click = false;
        yield return new WaitUntil(()=>click==true);
        yield return StartCoroutine(NormalChat("리아" , "엄마가 떠나지 않겠다면, 저 혼자라도 이곳을 떠날거예요!"));
        click = false;
        yield return new WaitUntil(()=>click==true);
        face.af();
        ChatBar.SetActive(false);
        eye.gameObject.SetActive(true);
        grid.SetActive(false);
        outgrid.SetActive(true);
        yield return new WaitForSeconds(1f);
        yield return StartCoroutine(gridfade());
        face.disappoint();
        yield return StartCoroutine(NormalChat("리아", "엄마한테 저렇게 소리쳤지만 엄마는 아프고 나는 강하지 않아."));
        click = false;
        yield return new WaitUntil(()=>click==true);
        yield return StartCoroutine(NormalChat("리아", "엄마와 함께 이곳을 떠나 살아남으려면 더 강해져야돼."));
        click = false;
        yield return new WaitUntil(()=>click==true);
        yield return StartCoroutine(NormalChat("리아", "시간이 얼마나 남았을까?"));
        click = false;
        yield return new WaitUntil(()=>click==true);
        face.angry();
        yield return StartCoroutine(NormalChat("리아", "수련장으로 가서 전투하는 법을 연습해야 겠어...!"));
        click = false;
        yield return new WaitUntil(()=>click==true);
        SceneManager.LoadScene("main");

        
        
    }
}