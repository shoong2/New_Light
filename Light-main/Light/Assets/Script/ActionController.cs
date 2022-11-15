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

    private void Update()
    {
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Item")
        {
            ItemInfoAppear();
            getImage.SetActive(true);
            StartCoroutine(CheckButton(collision.gameObject));
            //if (pickupActivated && ActiveButton)
            //{
            //    Destroy(collision.gameObject);
            //    InfoDisappear();
            //    Debug.Log("get apple");
            //}
        }
        else
            InfoDisappear();
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
        Debug.Log("qwer");
        if(pickupActivated && ActiveButton)
        {
            Destroy(item);
            InfoDisappear();
            Debug.Log("get apple");
        }

        yield return null;
    }

    public void IsGetButton()
    {
        ActiveButton = true;
    }
}
