using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class manager2PG : MonoBehaviour
{
    ActionController playerAction;

    testPlayer player;
    Animator ani;
    public GameObject tree;
    public GameObject apple;
    public GameObject stick;
    GameObject AppleItem;
    GameObject StickItem;
    int appleCount =0;
    int branchCount = 0;
    float randomX;
    float time;
    float fadeTime =1;
    Vector2 randomPos;

    void Start()
    {
        ani = tree.GetComponent<Animator>();
        player = GameObject.Find("TOP1").GetComponent<testPlayer>();
        playerAction = GameObject.Find("TOP1").GetComponent<ActionController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerAction.isShakeTree) // (player.attack1 == 1)
        {
            Debug.Log("change tree");
            ani.SetTrigger("Shake");
            int randomRange = Random.Range(0,4);
            //if (GameManager.instance.saveData.getApple < 10 && randomRange == 1 
            //    && GameManager.instance.saveData.TreeQuest == true && appleCount<10)
            if(randomRange ==1)
            {
                appleCount+=1;
                randomX = Random.Range(-3.37f, -1.09f);
                randomPos= new Vector2(randomX, -4.5f);
                AppleItem = Instantiate(apple,randomPos, Quaternion.identity);
                
            }
            else if(GameManager.instance.saveData.getBranch <3 &&randomRange == 2 
                && GameManager.instance.saveData.TreeQuest == true &&branchCount<3)
            {
                branchCount+=1;
                randomX = Random.Range(-3.37f, -1.09f);
                randomPos= new Vector2(randomX, -4.5f);
                StickItem = Instantiate(stick,randomPos, Quaternion.identity);
            }

            // Invoke("fadeOut", 1f);
            //player.attack1 = 0;
            playerAction.isShakeTree = false;
        }


        

    
    }
    
}
