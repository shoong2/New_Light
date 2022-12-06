using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class manager2PG : MonoBehaviour
{
    testPlayer player;
    Animator ani;
    public GameObject tree;
    public GameObject apple;
    public GameObject stick;
    GameObject AppleItem;
    GameObject StickItem;
    int appleCount =0;
    int stickCount = 0;
    float randomX;
    float time;
    float fadeTime =1;
    Vector2 randomPos;
    
    // SpriteRenderer fade;

    //GameManager manager;
    void Start()
    {
        ani = tree.GetComponent<Animator>();
        player = GameObject.Find("TOP1").GetComponent<testPlayer>();
        // fade = apple.GetComponent<SpriteRenderer>();
        //manager = GameObject.Find("GameManager").GetComponent<GameManager>();

    }

    // Update is called once per frame
    void Update()
    {
        if(player.attack1 == 1)
        {
            ani.Play("newApple", -1, 0f);
            int randomRange = Random.Range(0,4);
            if (appleCount < 10 && randomRange == 1 && GameManager.instance.saveData.TreeQuest == true)
            {
                appleCount+=1;
                randomX = Random.Range(-3.37f, -1.09f);
                randomPos= new Vector2(randomX, -4.5f);
                AppleItem = Instantiate(apple,randomPos, Quaternion.identity);
                
            }
            else if(stickCount <3 &&randomRange == 2 && GameManager.instance.saveData.TreeQuest == true)
            {
                stickCount+=1;
                randomX = Random.Range(-3.37f, -1.09f);
                randomPos= new Vector2(randomX, -4.5f);
                StickItem = Instantiate(stick,randomPos, Quaternion.identity);
            }
            
            // Invoke("fadeOut", 1f);
            player.attack1 = 0;

        }

        
        

    
    }
    
}
