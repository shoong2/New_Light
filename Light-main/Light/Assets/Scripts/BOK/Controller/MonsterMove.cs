using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Define;
using UnityEditor.Tilemaps;
public class MonsterMove : MonoBehaviour
{
    Animator animator;
    CreatureState _state=CreatureState.Idle;
    bool isDelay = false;
    int currentDir = 0;
    Vector3Int destCellPos;
    MoveDir Dir;
    Grid tile;
    float moveTime = 2.0f;
    private void Start()
    {
        tile = FindObjectOfType<Grid>();
        animator = GetComponent<Animator>();
    }

    void UpdateAnimation()
    {
        if (_state == CreatureState.Idle)
        {
            switch (Dir)
            {
                case MoveDir.Up:
                    animator.Play("IDLE_UP");
                    transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
                    break;
                case MoveDir.Down:
                    animator.Play("IDLE_UP");
                    transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
                    break;
                case MoveDir.Right:
                    animator.Play("IDLE_LEFT");
                    transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
                    break;
                case MoveDir.Left:
                    animator.Play("IDLE_LEFT");
                    transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
                    break;
            }
        }
        else if (_state == CreatureState.Moving)
        {
            switch (Dir)
            {
                case MoveDir.Up:
                    animator.Play("WALK_UP");
                    transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
                    break;
                case MoveDir.Down:

                    animator.Play("WALK_LEFT");
                    transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
                    break;
                case MoveDir.Right:

                    animator.Play("WALK_LEFT");
                    transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
                    break;
                case MoveDir.Left:
                    animator.Play("WALK_LEFT");
                    transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
                    break;
            }
        }
    }
    Vector3 Pattern()
    {
        Vector3 reVector=Vector3Int.zero;
        if (Dir == MoveDir.Right) {
            reVector = new Vector3(3,0,0);
        }
        else if (Dir == MoveDir.Left)
        {
            reVector = new Vector3(-3, 0, 0);
        }
        else if (Dir == MoveDir.Up)
        {
            reVector = new Vector3(0, 2, 0);
        }
        else if (Dir == MoveDir.Down)
        {
            reVector = new Vector3(0,-2,0);
        }
        return reVector;
    }
    void Update()
    {
        UpdateAnimation();
        if (!isDelay)
        {
            
            isDelay = true;
            currentDir = (int)Dir;
            currentDir++;
            if (currentDir == 4)
            {
                currentDir = 0;
            }
            Dir = (MoveDir)(currentDir);
            
            _state = CreatureState.Moving;
            Debug.Log(Dir);
            Vector3 dest = Pattern();
            StartCoroutine(MovePattern(dest));
        }
        
    }
    //IEnumerator moveBlockTime(Vector3Int dir)
    //{
    //    isDelay = false;
    //    float elapsedTime = 0.0f;
    //    Vector3 currentPosition = transform.position;
    //    Vector3 targetPosition = Pattern() + dir;

    //    while (elapsedTime < moveTime)
    //    {
    //        transform.position = Vector3.Lerp(currentPosition, targetPosition, elapsedTime / blockMoveTime);
    //        elapsedTime += Time.deltaTime;
    //        yield return null;
    //    }
    //    transform.position = targetPosition;
    //    isDelay = true;
    //}
    IEnumerator MovePattern(Vector3 dir)
    {
        float elapsedTime = 0.0f;
        Vector3 current = transform.position;
        Vector3 targetPosition = current+dir;
        while (elapsedTime < moveTime)
        {
            transform.position = Vector3.Lerp(current, targetPosition, elapsedTime / moveTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        transform.position=targetPosition;
        yield return new WaitForSeconds(1);
        isDelay = false;
    }
}