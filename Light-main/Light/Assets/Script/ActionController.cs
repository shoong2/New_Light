using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionController : MonoBehaviour
{
    [SerializeField]
    //private float range;

    private bool pickupActivated = false;
    bool ActiveButton =false;

    //right button
    public GameObject getImage;
    public GameObject attackImage;


    [SerializeField]
    private LayerMask layerMask;


    [SerializeField]
    Inventory theInventory;

    GameObject appleTree;
    Animator appleTreeAnim;
    Animator anim;

    bool isItem = false;
    public bool isShakeTree = false; // 나무 흔들었는지 체크

    //bool hitItem = false;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            GameManager.instance.saveData.waterDrop += 1;
            GameManager.instance.UpdateUI();
        }
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "AppleTree" && isItem == false)
        {
            attackImage.SetActive(true);

        }

        if (collision.tag == "apple" || collision.tag =="branch")
        {
            isItem = true;
            ItemInfoAppear(); //pickup true
            attackImage.SetActive(false);
            getImage.SetActive(true);
            StartCoroutine(CheckButton(collision.gameObject));

        }
        else
        {
            InfoDisappear();         
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "apple" || collision.tag =="branch")
        {
            getImage.SetActive(false);
            InfoDisappear();
            isItem = false;
            //hitItem = false;
        }

        if(collision.tag == "AppleTree")
        {
            attackImage.SetActive(false);
        }
    }



    void ItemInfoAppear()
    {
        pickupActivated = true;
        
    }

    void InfoDisappear()
    {
        pickupActivated = false;
    }
    
    public IEnumerator CheckButton(GameObject item)
    {
        Debug.Log("branch problem?");
        Debug.Log(item.transform.GetComponent<ItemPickUp>().item.name);
        Item getItem = item.transform.GetComponent<ItemPickUp>().item;
        while (true)
        {
            if (pickupActivated && ActiveButton)
            {
                if(item.tag == "apple")
                {
                    GameManager.instance.saveData.getApple += 1;
                    theInventory.AcquireItem(getItem);
                    Destroy(item);
                    InfoDisappear();
                    Debug.Log("get apple");
                    ActiveButton = false;
                    GameManager.instance.SaveData();

                }
                
                else if(item.tag =="branch")
                {
                    GameManager.instance.saveData.getBranch += 1;
                    theInventory.AcquireItem(getItem);
                    Destroy(item);
                    InfoDisappear();
                    Debug.Log("get branch");
                    ActiveButton = false;
                    GameManager.instance.SaveData();
                }
                GameManager.instance.UpdateUI();
                //yield return null;
            }
            yield return null;
        }
        
    }

    public void IsGetButton() // 아이템먹기
    {
        ActiveButton = true;
    }

    public void GetApple() //나무 흔들기
    {
        isShakeTree = true;
        anim.SetTrigger("tree");
        //sprite.sortingOrder = 10;

    }
}
