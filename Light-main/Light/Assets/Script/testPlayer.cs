using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class testPlayer : MonoBehaviour
{
    // public static testPlayer instance;
    public float moveSpeed;
    Animator anim;
    joyStick joystick;
    public GameObject talk;
    public GameObject attack;
    public GameObject mainUI;
    public int talkCheck=0;
    public int attack1 = 0;
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
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    // void Update()
    // {
    //     float inputX = Input.GetAxisRaw("Horizontal");
    //     float inputY = Input.GetAxisRaw("Vertical");
    //     if(inputX !=0 || inputY != 0)
    //         anim.SetBool("ismove", true);
    //     else
    //         anim.SetBool("ismove", false);

    //     anim.SetFloat("inputx", inputX);
    //     anim.SetFloat("inputy", inputY);

    //     transform.Translate(new Vector2(inputX, inputY)* Time.deltaTime * moveSpeed);
    // }

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
    private void OnTriggerEnter2D(Collider2D other) 
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

            else if((SceneManager.GetActiveScene().name == "S_room"))
            {
                SceneManager.LoadScene("main");
                transform.localScale = new Vector3(0.55f,0.55f,0.55f);
                transform.position = new Vector3(-3.4f,0.25f,0);
            }

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

        if(other.tag =="attack")
        {
            attack.SetActive(true);
        }

        if(other.tag =="home")
        {
            SceneManager.LoadScene("S_room");
            transform.position = new Vector3(-0.4f, -3.9f,0);
            transform.localScale = new Vector3(1f,1f,1f);
        }
        
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.tag == "chat")
        {
            talk.SetActive(false);
            talkCheck =0;
        }

        if(other.tag == "attack")
        {
            attack.SetActive(false);
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
}
