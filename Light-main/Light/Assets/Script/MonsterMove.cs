using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MonsterMove : MonoBehaviour
{
    float moveTime = 2f;
    Vector3 movePosition;
    enum State {Right, Down, Left, Up};
    int test = 0;
    State state = State.Right;
    void Start()
    {
        
        test = UnityEngine.Random.Range(0, 4);
        StartCoroutine(MoveMonster());
    }

    IEnumerator MoveMonster()
    {
        Debug.Log(test);
     
        //state = (State)UnityEngine.Random.Range(0, Enum.GetNames(typeof(State)).Length);
        state = (State)test;
        switch(state)
        {
            case State.Right:
                movePosition = new Vector3(3, 0, 0);
                break;
            case State.Down:
                movePosition = new Vector3(0, -2, 0);
                break;
            case State.Left:
                movePosition = new Vector3(-3, 0, 0);
                break;
            case State.Up:
                movePosition = new Vector3(0, 2, 0);
                break;
            
        }
        StartCoroutine(MovePattern());
        test++;
        if (test >= 4)
        {
            test = 0;
        }
        yield return null;

    }

    IEnumerator MovePattern()
    {
        float elapsedTime = 0.0f;
        Vector3 current = transform.position;
        Vector3 targetPosition = current + movePosition;
        while (elapsedTime < moveTime)
        {
            transform.position = Vector3.Lerp(current, targetPosition, elapsedTime / moveTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        transform.position = targetPosition;
        yield return new WaitForSeconds(1);
        StartCoroutine(MoveMonster());
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
