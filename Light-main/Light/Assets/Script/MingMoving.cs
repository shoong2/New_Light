using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MingMoving : MonoBehaviour
{
    Animator animator;
    SpriteRenderer rend;

    float rightMax = 2.0f;
    float leftMax = -2.0f;
    float currentPosition;
    float direction = 3.0f;

    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        currentPosition = transform.position.x;
    }

    
    void Update()
    {
        currentPosition += Time.deltaTime*direction;
        if(currentPosition>=rightMax)
        {
            currentPosition = transform.position.y;
        }
    }
}
