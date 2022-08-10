using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using UnityEngine.UI;

public class testPlayer : MonoBehaviour
{
    // public static testPlayer instance;
    public float moveSpeed;
    Animator anim;
    JoyStick1 joystick;
    public GameObject talk;
    public GameObject attack;
    public GameObject get;
    public GameObject mainUI;
    public GameObject battleButton;
    public int talkCheck=0;
    public int attack1 = 0;
    public Text apple;
    public Text branch;
    public Image QuestComplete;
    bool getClick = false;
    bool isApple = false;
    bool isBranch = false;
    GameManager manager;

    SpriteRenderer sprite;
    // public GameObject treeSoul;

    // private void Awake() {
    //     if(instance != null)
    //     {
    //         Destroy(gameObject);
    //         return;
    //     }

    //     instance = this;
    //     DontDestroyOnLoad(gameObject);
    // }
    void Start()
    {
        joystick = GameObject.FindObjectOfType<JoyStick1>();
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    

    private void FixedUpdate() {
        if(joystick.Horizontal !=0 || joystick.Vertical !=0)
        {
            moveControl();
            
        }
        // //else if(joystick.Horizontal ==0 || joystick.Vertical ==0)
        // {
        //     moveSpeed = 0f;
        // }

    }
    
    private void _LoadScene(string name)
    {
        joystick.InitTrigger();
        SceneManager.LoadScene(name);
    }
    
    public void moveControl()
    {
        Vector3 upMovement = Vector3.up *moveSpeed *Time.deltaTime * joystick.Vertical;
        Vector3 rightMovement = Vector3.right *moveSpeed *Time.deltaTime * joystick.Horizontal;

        Vector3 move = (Vector3.up *joystick.Vertical + Vector3.right * joystick.Horizontal).normalized 
        * moveSpeed *Time.deltaTime;

        transform.Translate(move);
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "AppleTree")
        {
            StartCoroutine(SetLayer());
            Debug.Log("ggg");
        }
        if(other.tag == "GoRight")
        {
            joystick.handle.anchoredPosition =Vector2.zero;
           
            if((SceneManager.GetActiveScene().name == "S_PlayGround"))
            {
                _LoadScene("main");
                transform.position = new Vector3(-7.7f,-0.1f,0); 
            }
            else if((SceneManager.GetActiveScene().name == "main"))
            {
                _LoadScene("S_forest1");
                transform.position = new Vector3(-7.2f,0,0);
            }

            else if((SceneManager.GetActiveScene().name == "S_forest1"))
            {
                _LoadScene("S_forest2");
                transform.position =new Vector3(-7.7f,-0.1f,0);
            }

            else if((SceneManager.GetActiveScene().name == "S_NorthForest"))
            {
                _LoadScene("S_Road");
                transform.position =new Vector3(-5.5f,1.9f,0);
            }

        }
      

        if(other.tag == "GoLeft")
        {
            joystick.handle.anchoredPosition =Vector2.zero;
            if((SceneManager.GetActiveScene().name == "main"))
            {
                _LoadScene("S_PlayGround");
                transform.position = new Vector3(8.3f,1.3f,0);
            }

            else if((SceneManager.GetActiveScene().name == "S_forest1"))
            {
                _LoadScene("main");
                transform.position =new Vector3(8f,1f,0);
            }

            else if(SceneManager.GetActiveScene().name == "S_forest2")
            {
                _LoadScene("S_forest1");
                transform.position =new Vector3(8f,1f,0);
            }

            else if((SceneManager.GetActiveScene().name == "S_Road"))
            {
                _LoadScene("S_NorthForest");
                transform.position =new Vector3(6.2f,3.4f,0);
            }
        }


        if(other.tag == "GoUp")
        {
            joystick.handle.anchoredPosition =Vector2.zero;
            if((SceneManager.GetActiveScene().name == "S_forest1"))
            {
                _LoadScene("S_NorthForest");
                transform.position = new Vector3(-1f,-3.7f,0);
            }

            else if((SceneManager.GetActiveScene().name == "S_forest2"))
            {
                _LoadScene("S_Road");
                transform.position = new Vector3(1.7f,-3.9f,0);
            }

            else if((SceneManager.GetActiveScene().name == "S_SouthForest"))
            {
                _LoadScene("S_forest1");
                transform.position = new Vector3(8.3f,1.3f,0);
            }

            else if((SceneManager.GetActiveScene().name == "S_2PlayGround"))
            {
                _LoadScene("S_PlayGround");
                transform.position = new Vector3(0f,-3.4f,0);
            }
        }

        if(other.tag == "GoDown")
        {
            joystick.handle.anchoredPosition =Vector2.zero;
            if((SceneManager.GetActiveScene().name == "S_forest1"))
            {
                _LoadScene("S_SouthForest");
                transform.position = new Vector3(8.3f,1.3f,0);
            }

            else if((SceneManager.GetActiveScene().name == "S_NorthForest"))


            {
                _LoadScene("S_forest1");
                transform.position = new Vector3(-3.6f,3.9f,0);
            }

            else if((SceneManager.GetActiveScene().name == "S_Road"))
            {
                _LoadScene("S_forest2");
                transform.position = new Vector3(4.4f,3.8f,0);
            }

            // else if((SceneManager.GetActiveScene().name == "S_room"))
            // {
            //     _LoadScene("main");
            //     transform.localScale = new Vector3(0.55f,0.55f,0.55f);
            //     transform.position = new Vector3(-3.4f,0.25f,0);
            // }

            else if((SceneManager.GetActiveScene().name == "S_PlayGround"))
            {
                _LoadScene("S_2PlayGround");
                transform.position = new Vector3(-0.5f,3.6f,0);
            }


        }

        if(other.tag == "chat")  
        {
            talk.SetActive(true);
            talkCheck =1;

        }

        // if(other.tag =="attack")
        // {
        //     attack.SetActive(true);
        // }

        if(other.tag =="home")
        {
            _LoadScene("S_room");
            transform.position = new Vector3(-2.65f, -1.04f,0);
            transform.localScale = new Vector3(1f,1f,1f);
        }

        

        if(other.tag =="Laing")
        {
            battleButton.SetActive(true);
        }
       

    }

    void OnTriggerStay2D(Collider2D other) {
        
        if(other.tag == "attack" && isApple == false && isBranch == false)
        {
            attack.SetActive(true);
        }

        if(other.tag =="apple")
        {
            isApple = true;
            attack.SetActive(false);
            get.SetActive(true);
            StartCoroutine(clickCheck(other.gameObject));
            
        }

        if(other.tag == "branch")
        {
            isBranch = true;
            attack.SetActive(false);
            get.SetActive(true);
            StartCoroutine(clickCheck(other.gameObject));
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        if(other.tag == "AppleTree")
        {
            StopAllCoroutines();
        }
        if(other.tag == "chat")
        {
            talk.SetActive(false);
            talkCheck =0;
        }

        if(other.tag =="attack")
        {
            attack.SetActive(false);
        }

        if(other.tag == "apple")
        {
            isApple = false;
            get.SetActive(false);
            
        }

        if(other.tag == "branch")
        {
            isBranch = false;
            get.SetActive(false);
        }
    }
    
    // private void OnTriggerStay(Collider other) {
    //     if(other.tag =="chat")
    //     {
    //         talk.SetActive(true);
    //     }
    //}

    public void StartTalk()
    {
        if(talkCheck == 1)
        {
            GameObject.Find("Tree_soul").GetComponent<treeSoul>().startChat();
            mainUI.SetActive(false);
        }
    }
    
    public void GetApple() //나무 접근하고 클릭했을 때 작동
    {
        attack1 = 1;
        Debug.Log(attack1);
        anim.SetTrigger("tree");
        sprite.sortingOrder =10;
        
    }

    public void click()
    {
        getClick = true;
    }

    public void acceptBattle() //밍 전투 수락
    {
        _LoadScene("BattleScene");
        battleButton.SetActive(false);
        gameObject.SetActive(false);
        mainUI.SetActive(false);

    }

    public void denyBattle() //밍 전투 거절
    {
        battleButton.SetActive(false);
    }

    // IEnumerator destroyAp()
    // {
    //     void OnTriggerStay2D(Collider2D other) {
    //         if(other.tag =="apple")
    //         {

    //         }
    //     }
    // }

    public IEnumerator clickCheck(GameObject plz) //이거 게임매니저로 보내고 싶은데 충돌처리때문에 불가능
    {
        while(true)
        {
            if(getClick == true)
            {
                if(plz.tag == "apple")
                {
                    manager.loadData.getApple +=1;
                    apple.text = "사과 10개를 가져오자 ("+manager.loadData.getApple+"/10)";
                    StartCoroutine(QuestCheck());
                }

                if(plz.tag == "branch")
                {
                    manager.loadData.getBranch +=1;
                    branch.text = "나뭇가지 3개를 가져오자 ("+manager.loadData.getBranch+"/3)";
                    StartCoroutine(QuestCheck());
                }
                
                string jsonData = JsonUtility.ToJson(manager.loadData);
                File.WriteAllText(Application.persistentDataPath + "/Data.json", jsonData);
                Destroy(plz);
                getClick = false;
            }
            yield return null;
        }
        
    }

    public IEnumerator QuestCheck() //제이슨 데이터로 코드 수정 필요 
    {
        if(manager.loadData.getApple ==10 && manager.loadData.getBranch == 3)
        {
            apple.text = "사과 10개를 가져오자 (완료)";
            branch.text = "나뭇가지 3개를 가져오자 (완료)";
            manager.loadData.isTreeeQuest1 = true;
            string jsonData = JsonUtility.ToJson(manager.loadData);
            File.WriteAllText(Application.persistentDataPath + "/Data.json", jsonData);
            StartCoroutine(Fade());
        }

        yield return null;
    }

    IEnumerator Fade()
    {
        QuestComplete.gameObject.SetActive(true);
        float fadeCount = 0;
        while (fadeCount <0.5f)
        {
            fadeCount +=0.01f;
            yield return new WaitForSeconds(0.005f);
            QuestComplete.color = new Color(1,1,1, fadeCount);
        }
        yield return new WaitForSeconds(1.3f);
        while(fadeCount>0)
        {
            fadeCount -= 0.02f;
            yield return new WaitForSeconds(0.005f);
            QuestComplete.color = new Color(1,1,1, fadeCount);
        }

        QuestComplete.gameObject.SetActive(false);
    }

    private IEnumerator SetLayer()
    {
        while (true)
        {
            Debug.Log("qqqq");
        	// sortingOrder를 y값으로 계속 변경해준다.
            yield return new WaitForEndOfFrame();
            
            sprite.sortingOrder = -(int)this.transform.position.y+3;

            if(sprite.sortingOrder == 5)
            {
                sprite.sortingOrder=4;
            }
        }
    }
}
