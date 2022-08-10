using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class JoyStick1 : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    RectTransform rect;
    Vector2 touch = Vector2.zero;
    public RectTransform handle;

    public GameObject player;
    Animator playerAni;
    SpriteRenderer spriteRenderer;
    float widthHalf;

    public float Horizontal {get {return handle.localPosition.x;}}
    public float Vertical {get {return handle.localPosition.y;}}

    public bool isDown;

    private void Start()
    {
        rect = GetComponent<RectTransform>();
        widthHalf = rect.sizeDelta.x*0.5f;
        playerAni = player.GetComponent<Animator>();
        spriteRenderer = player.GetComponent<SpriteRenderer>();

        isDown = false;
    }

    public void InitTrigger()
    {
        isDown = false;
        playerAni.SetBool("ismove", false);
    }
    

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("PointerDown");
        isDown = true;
        // OnDrag(eventData);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("PointerUp");
        handle.anchoredPosition = Vector2.zero;
        playerAni.SetBool("ismove", false);

        isDown = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("ondrag");
        // Debug.Log("isDown : " + isDown);
        if(isDown == false) return;

        playerAni.SetBool("ismove", true);
        touch = (eventData.position - rect.anchoredPosition)/widthHalf;
        if(touch.magnitude >1)
        {
            touch = touch.normalized;
        }

        handle.anchoredPosition = touch*widthHalf;

        if(touch.x >=0 && touch.y <0.4f && touch.y >-0.4)
        {
            spriteRenderer.flipX = false;
            playerAni.SetFloat("inputx", 1);
            playerAni.SetFloat("inputy", 0);
        }

        if(touch.x <0 && touch.y <0.4f && touch.y >-0.4)
        {
            spriteRenderer.flipX = true;
            playerAni.SetFloat("inputx", -1);
            playerAni.SetFloat("inputy", 0);
        }

        if(touch.y >=0.4)
        {
            playerAni.SetFloat("inputx", 0);
            playerAni.SetFloat("inputy", 1);
        }

        if(touch.y <=-0.4)
        {
            playerAni.SetFloat("inputx", 0);
            playerAni.SetFloat("inputy", -1);
        }
    }
}
