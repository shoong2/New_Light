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

    //GameManager manager;
    SpriteRenderer sprite;
    Inventory theInventory;
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
       // manager = GameObject.Find("GameManager").GetComponent<GameManager>();
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
            //StartCoroutine(SetLayer());
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

        if (other.tag == "apple")
        {
            isApple = true;
            attack.SetActive(false);
            get.SetActive(true);
            //StartCoroutine(clickCheck(other.gameObject));

        }

        if (other.tag == "branch")
        {
            isBranch = true;
            attack.SetActive(false);
            get.SetActive(true);
            //StartCoroutine(clickCheck(other.gameObject));
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

        if (other.tag == "apple")
        {
            isApple = false;
            get.SetActive(false);

        }

        if (other.tag == "branch")
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
    
    public void GetApple() //?òÎ¨¥ ?ëÍ∑º?òÍ≥† ?¥Î¶≠?àÏùÑ ???ëÎèô
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

    public void acceptBattle() //Î∞??ÑÌà¨ ?òÎùΩ
    {
        _LoadScene("BattleScene");
        battleButton.SetActive(false);
        gameObject.SetActive(false);
        mainUI.SetActive(false);

    }

    public void denyBattle() //Î∞??ÑÌà¨ Í±∞Ï†à
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

    public IEnumerator clickCheck(GameObject plz) //?¥Í±∞ Í≤åÏûÑÎß§Îãà?ÄÎ°?Î≥¥ÎÇ¥Í≥??∂Ï???Ï∂©ÎèåÏ≤òÎ¶¨?åÎ¨∏??Î∂àÍ???
    {
        while(true)
        {
            if(getClick == true)
            {
                if(plz.tag == "apple")
                {
                    GameManager.instance.saveData.getApple += 1;
                    //manager.saveData.getApple +=1;
                    apple.text = "ªÁ∞˙ 10∞≥∏¶ ∞°¡Æø¿¿⁄("+GameManager.instance.saveData.getApple+"/10)";
                    //theInventory.AcquireItem();
                    StartCoroutine(QuestCheck());
                }

                if(plz.tag == "branch")
                {
                    GameManager.instance.saveData.getBranch +=1;
                    branch.text = "?òÎ≠áÍ∞ÄÏßÄ 3Í∞úÎ? Í∞Ä?∏Ïò§??("+GameManager.instance.saveData.getBranch+"/3)";
                    StartCoroutine(QuestCheck());
                }

                GameManager.instance.SaveData();
                Debug.Log(" get apple");
                //string jsonData = JsonUtility.ToJson(manager.saveData);
               // File.WriteAllText(Application.persistentDataPath + "/Data.json", jsonData);
                Destroy(plz);
                getClick = false;
            }
            yield return null;
        }
        
    }

    public IEnumerator QuestCheck() //?úÏù¥???∞Ïù¥?∞Î°ú ÏΩîÎìú ?òÏ†ï ?ÑÏöî 
    {
        if(GameManager.instance.saveData.getApple ==10 && GameManager.instance.saveData.getBranch == 3)
        {
            apple.text = "?¨Í≥º 10Í∞úÎ? Í∞Ä?∏Ïò§??(?ÑÎ£å)";
            branch.text = "?òÎ≠áÍ∞ÄÏßÄ 3Í∞úÎ? Í∞Ä?∏Ïò§??(?ÑÎ£å)";
            GameManager.instance.saveData.isTreeeQuest1 = true;
            GameManager.instance.SaveData();
            //string jsonData = JsonUtility.ToJson(manager.saveData);
            //File.WriteAllText(Application.persistentDataPath + "/Data.json", jsonData);
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
        	// sortingOrderÎ•?yÍ∞íÏúºÎ°?Í≥ÑÏÜç Î≥ÄÍ≤ΩÌï¥Ï§Ä??
            yield return new WaitForEndOfFrame();
            
            sprite.sortingOrder = -(int)this.transform.position.y+3;

            if(sprite.sortingOrder == 5)
            {
                sprite.sortingOrder=4;
            }
        }
    }
}
