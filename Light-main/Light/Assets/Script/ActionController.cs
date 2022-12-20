using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionController : MonoBehaviour
{
    [SerializeField]
    //private float range;

    private bool pickupActivated = false;
    bool ActiveButton =false;

    //private RaycastHit hitInfo;
    public GameObject getImage;

    [SerializeField]
    private LayerMask layerMask;

    [SerializeField]
    Inventory theInventory;

    //bool hitItem = false;
    private void Start()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "apple")
        {
            ItemInfoAppear(); //pickup true
            getImage.SetActive(true);
            //hitItem = true;
            StartCoroutine(CheckButton(collision.gameObject));
            //if (pickupActivated && ActiveButton)
            //{
            //    Destroy(collision.gameObject);
            //    InfoDisappear();
            //    Debug.Log("get apple");
            //}

        }
        else
        {
            InfoDisappear();         
        }
    }

    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    if(collision.tag == "apple")
    //    {
    //        getImage.SetActive(false);
    //        //hitItem = false;
    //    }
    //}



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
        Item test = item.transform.GetComponent<ItemPickUp>().item;
        while (true)
        {
            if (pickupActivated && ActiveButton)
            {
                if(item.tag == "apple")
                {
                    GameManager.instance.saveData.getApple += 1;
                    theInventory.AcquireItem(test);
                    Debug.Log("destroy");
                    Destroy(item);
                    InfoDisappear();
                    Debug.Log("get apple");
                    ActiveButton = false;
                    GameManager.instance.SaveData();

                }
                
                if(item.tag =="branch")
                {
                    GameManager.instance.saveData.getBranch += 1;
                    theInventory.AcquireItem(test);
                    //Debug.Log("destroy");
                    Destroy(item);
                    InfoDisappear();
                    Debug.Log("get branch");
                    ActiveButton = false;
                    GameManager.instance.SaveData();
                }
                
                //yield return null;
            }
            yield return null;
        }
        //if(pickupActivated && ActiveButton)
        //{
        //    Destroy(item);
        //    InfoDisappear();
        //    Debug.Log("get apple");
        //}

        //yield return null;
    }

    public void IsGetButton()
    {
        ActiveButton = true;
    }
}
