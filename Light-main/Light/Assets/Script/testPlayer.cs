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
    joyStick joystick;
    public GameObject talk;
    public GameObject attack;
    public GameObject get;
    public GameObject mainUI;
    public int talkCheck=0;
    public int attack1 = 0;
    public Text apple;

    bool getClick = false;
    bool isApple = false;
    GameManager manager;
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
        joystick = GameObject.FindObjectOfType<joyStick>();
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
        anim = GetComponent<Animator>();
    }

    

    private void FixedUpdate() {
        if(joystick.Horizontal !=0 || joystick.Vertical !=0)
        {
            moveControl();
            
        }

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
        if(other.tag == "GoRight")
        {
            if((SceneManager.GetActiveScene().name == "S_PlayGround"))
            {
                SceneManager.LoadScene("main");
                transform.position = new Vector3(-7.7f,-0.1f,0); 
            }
            else if((SceneManager.GetActiveScene().name == "main"))
            {
                SceneManager.LoadScene("S_forest1");
                transform.position = new Vector3(-7.2f,0,0);
            }

            else if((SceneManager.GetActiveScene().name == "S_forest1"))
            {
                SceneManager.LoadScene("S_forest2");
                transform.position =new Vector3(-7.7f,-0.1f,0);
            }

            else if((SceneManager.GetActiveScene().name == "S_NorthForest"))
            {
                SceneManager.LoadScene("S_Road");
                transform.position =new Vector3(-5.5f,1.9f,0);
            }

        }
      

        if(other.tag == "GoLeft")
        {
            if((SceneManager.GetActiveScene().name == "main"))
            {
                SceneManager.LoadScene("S_PlayGround");
                transform.position = new Vector3(8.3f,1.3f,0);
            }

            else if((SceneManager.GetActiveScene().name == "S_forest1"))
            {
                SceneManager.LoadScene("main");
                transform.position =new Vector3(8f,1f,0);
            }

            else if(SceneManager.GetActiveScene().name == "S_forest2")
            {
                SceneManager.LoadScene("S_forest1");
                transform.position =new Vector3(8f,1f,0);
            }

            else if((SceneManager.GetActiveScene().name == "S_Road"))
            {
                SceneManager.LoadScene("S_NorthForest");
                transform.position =new Vector3(6.2f,3.4f,0);
            }
        }


        if(other.tag == "GoUp")
        {
            if((SceneManager.GetActiveScene().name == "S_forest1"))
            {
                SceneManager.LoadScene("S_NorthForest");
                transform.position = new Vector3(-1f,-3.7f,0);
            }

            else if((SceneManager.GetActiveScene().name == "S_forest2"))
            {
                SceneManager.LoadScene("S_Road");
                transform.position = new Vector3(1.7f,-3.9f,0);
            }

            else if((SceneManager.GetActiveScene().name == "S_SouthForest"))
            {
                SceneManager.LoadScene("S_forest1");
                transform.position = new Vector3(8.3f,1.3f,0);
            }

            else if((SceneManager.GetActiveScene().name == "S_2PlayGround"))
            {
                SceneManager.LoadScene("S_PlayGround");
                transform.position = new Vector3(0f,-3.4f,0);
            }
        }

        if(other.tag == "GoDown")
        {
            if((SceneManager.GetActiveScene().name == "S_forest1"))
            {
                SceneManager.LoadScene("S_SouthForest");
                transform.position = new Vector3(8.3f,1.3f,0);
            }

            else if((SceneManager.GetActiveScene().name == "S_NorthForest"))


            {
                SceneManager.LoadScene("S_forest1");
                transform.position = new Vector3(-3.6f,3.9f,0);
            }

            else if((SceneManager.GetActiveScene().name == "S_Road"))
            {
                SceneManager.LoadScene("S_forest2");
                transform.position = new Vector3(4.4f,3.8f,0);
            }

            // else if((SceneManager.GetActiveScene().name == "S_room"))
            // {
            //     SceneManager.LoadScene("main");
            //     transform.localScale = new Vector3(0.55f,0.55f,0.55f);
            //     transform.position = new Vector3(-3.4f,0.25f,0);
            // }

            else if((SceneManager.GetActiveScene().name == "S_PlayGround"))
            {
                SceneManager.LoadScene("S_2PlayGround");
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
            SceneManager.LoadScene("S_room");
            transform.position = new Vector3(-2.65f, -1.04f,0);
            transform.localScale = new Vector3(1f,1f,1f);
        }

        

        // if(other.tag == "apple")
        // {
        //     attack.SetActive(false);
        //     get.SetActive(true);
        //     // if(get1 == 1)
        //     // {
        //     //     Debug.Log("hi");
        //     //     Destroy(other.gameObject);
        //     // //     // manager.quest.getApple+=1;
        //     //     get1 = 0;
        //     // // }
        //     // }
        // }

       

    }

    void OnTriggerStay2D(Collider2D other) {
        
        if(other.tag == "attack" && isApple == false)
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
    }

    void OnTriggerExit2D(Collider2D other) {
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
    
    public void GetApple()
    {
        attack1 = 1;
        Debug.Log(attack1);
    }

    public void click()
    {
        getClick = true;
    }

    // IEnumerator destroyAp()
    // {
    //     void OnTriggerStay2D(Collider2D other) {
    //         if(other.tag =="apple")
    //         {

    //         }
    //     }
    // }

    public IEnumerator clickCheck(GameObject plz)
    {
        while(true)
        {
            if(getClick == true)
            {
                Destroy(plz);
                manager.loadData.getApple +=1;
                string jsonData = JsonUtility.ToJson(manager.loadData);
                File.WriteAllText(Application.persistentDataPath + "/Data.json", jsonData);
                apple.text = "사과 10개를 가져오자 ("+manager.loadData.getApple+"/10)";
                getClick = false;
            }
            yield return null;
        }
        
    }



  
}
