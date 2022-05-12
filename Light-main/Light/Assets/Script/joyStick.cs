using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class joyStick : MonoBehaviour,IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    public RectTransform stick;
    RectTransform pad;
    public GameObject player;
    public float moveSpeed;
    Rigidbody2D playerRigid;
    Vector3 input = Vector3.zero;
    Animator playerAni;
    
    SpriteRenderer spriteRenderer;

    public float Horizontal {get {return stick.localPosition.x;}}
    public float Vertical {get {return stick.localPosition.y;}}


    private void Start() {
        pad =gameObject.GetComponent<RectTransform>();
        playerRigid = player.GetComponent<Rigidbody2D>();
        playerAni = player.GetComponent<Animator>(); 
        spriteRenderer = player.GetComponent<SpriteRenderer>();
       
        
    }
   
    public void OnDrag(PointerEventData eventData)
    {
        stick.position = eventData.position;
        stick.localPosition = Vector2.ClampMagnitude(eventData.position - (Vector2)pad.position,pad.rect.width*0.5f);
        // Debug.Log("horizon :" + Horizontal + "vertic :" + Vertical);
        // transform.position = eventData.position;
        // if(transform.localPosition.x < -180)
        //     transform.localPosition = new Vector2(-180, 0);
        // if(transform.localPosition.x > 180)
        //     transform.localPosition = new Vector2(180, 0);
        playerAni.SetBool("ismove", true);

        
        if(Horizontal >= 0)
        {
            spriteRenderer.flipX = false;
            playerAni.SetFloat("inputx", 1);
            playerAni.SetFloat("inputy", 0);
        }

        if(Horizontal <= 0)
        {
            spriteRenderer.flipX = true;
            playerAni.SetFloat("inputx", -1);
            playerAni.SetFloat("inputy", 0);
        }
        
        // playerAni.SetFloat("inputx", stick.localPosition.x /Mathf.Abs(stick.localPosition.x));
        // playerAni.SetFloat("inputy", stick.localPosition.y/ Mathf.Abs(stick.localPosition.y));
    }

    public void OnPointerDown(PointerEventData eventData)
    {
       
        
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        stick.localPosition = Vector2.zero;
        playerAni.SetBool("ismove", false);
        
    }

    // void FixedUpdate() {
    //     if(Horizontal !=0 || Vertical != 0)
    //     {
            
    //         MoveControl();

    //     }
       
        

        
    // }

    
    // void MoveControl()
    // {
         
    //     Vector3 upMovement = Vector3.up *moveSpeed *Time.deltaTime *Vertical;
    //     Vector3 rightMovement = Vector3.right *moveSpeed *Time.deltaTime *Horizontal;

    //     player.transform.position += upMovement;
    //     player.transform.position += rightMovement;

     
        
    // }

   
  

    
}

