using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class manager2PG : MonoBehaviour
{
    testPlayer player;
    Animation ani;
    public GameObject tree;
    public GameObject apple;
    public GameObject stick;
    GameObject item;
    int appleCount =0;
    int stickCount = 0;
    float randomX;
    float time;
    float fadeTime =1;
    Vector2 randomPos;
    // SpriteRenderer fade;

    GameManager manager;
    void Start()
    {
        ani = tree.GetComponent<Animation>();
        player = GameObject.Find("TOP1").GetComponent<testPlayer>();
        // fade = apple.GetComponent<SpriteRenderer>();
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();

    }

    // Update is called once per frame
    void Update()
    {
        if(player.attack1 == 1)
        {
            ani.Play("apple");
            int randomRange = Random.Range(0,4);
            if(appleCount <10 && randomRange ==1)
            {
                appleCount+=1;
                randomX = Random.Range(-2.5f, -5.0f);
                randomPos= new Vector2(randomX, -4.5f);
                item = Instantiate(apple,randomPos, Quaternion.identity);
                
            }
            else if(stickCount <3 &&randomRange == 2)
            {
                stickCount+=1;
                randomX = Random.Range(-2.5f, -5.0f);
                randomPos= new Vector2(randomX, -4.5f);
                item = Instantiate(stick,randomPos, Quaternion.identity);
            }
            
            // Invoke("fadeOut", 1f);
            player.attack1 = 0;

        }





        

    
    }
    // void OnTriggerEnter2D(Collider2D other) 
    // {
    //     if(other.tag == "apple" && player.get1 ==1)
    //     {
    //         Debug.Log("hi");
    //         Destroy(other);
    //         manager.quest.getApple+=1;
    //         player.get1 = 0;
    //     }
    // }

    // void fadeOut()
    // {
    //     while(time < fadeTime)
    //     {
    //         apple.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1f - time/fadeTime);
    //     }
    //     // else
    //     // {
    //     //     time = 0;
    //     //     apple.SetActive(false);
    //     // }
    //     time += Time.deltaTime;
    // }


    // IEnumerator fadeOut(GameObject item)
    // {
    //     Debug.Log("hi");
    //     while(fadeTime >0)
    //     {
    //         time = Time.deltaTime;
    //         fadeTime=1f;
    //         color = new Color(1,1,1, 1f - time/fadeTime);
    //     }
    // }
}
