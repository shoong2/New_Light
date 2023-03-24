using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

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
    public bool isShakeTree = false; // ³ª¹« Èçµé¾ú´ÂÁö Ã¼Å©

    public TMP_Text randomItemText;

    //bool hitItem = false;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }



    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "AppleTree" && isItem == false)
        {
            attackImage.SetActive(true);

        }

        if (collision.tag == "apple" || collision.tag =="branch" || collision.tag=="pocket")
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
        if (collision.tag == "apple" || collision.tag =="branch" || collision.tag == "pocket")
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
                    //GameManager.instance.SaveData();

                }
                
                else if(item.tag =="branch")
                {
                    GameManager.instance.saveData.getBranch += 1;
                    theInventory.AcquireItem(getItem);
                    Destroy(item);
                    InfoDisappear();
                    Debug.Log("get branch");
                    ActiveButton = false;
                    //GameManager.instance.SaveData();
                }
                else if(item.tag =="pocket")
                {
                    int randomItemCount = Random.Range(1, 4);
                    GameManager.instance.saveData.waterDrop += randomItemCount;
                    theInventory.AcquireItem(getItem, randomItemCount);
                    Destroy(item);
                    InfoDisappear();
                    ActiveButton = false;
                    StartCoroutine(Fade(randomItemCount));
                }
                GameManager.instance.UpdateUI();
                //GameManager.instance.SaveData();
                //yield return null;
            }
            yield return null;
        }
        
    }

    public void IsGetButton() // ¾ÆÀÌÅÛ¸Ô±â
    {
        ActiveButton = true;
    }

    public void GetApple() //³ª¹« Èçµé±â
    {
        isShakeTree = true;
        anim.SetTrigger("tree");
        //sprite.sortingOrder = 10;

    }

    IEnumerator Fade(int number)
    {
        randomItemText.gameObject.SetActive(true);
        randomItemText.text = "ÇªÇªÀÇ ÀÀÃà¾× " + number + "°³ È¹µæ!";
        float fadeCount = 0;
        while (fadeCount < 1f)
        {
            fadeCount += 0.01f;
            yield return new WaitForSeconds(0.005f);
            randomItemText.color = new Color(randomItemText.color.r, randomItemText.color.g,randomItemText.color.b, fadeCount);
        }
        yield return new WaitForSeconds(1.3f);
        while (fadeCount > 0)
        {
            fadeCount -= 0.02f;
            yield return new WaitForSeconds(0.005f);
            randomItemText.color = new Color(randomItemText.color.r, randomItemText.color.g, randomItemText.color.b, fadeCount);
        }

        randomItemText.gameObject.SetActive(false);
    }
}
