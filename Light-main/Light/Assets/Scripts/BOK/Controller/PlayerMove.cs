using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Define;
public class PlayerMove : CreatureController
{
    MoveDir Dir;
    void LateUpdate()
    {
        Camera.main.transform.position = new Vector3(transform.position.x, transform.position.y, -10);
    }
    void Update()
    {
        
    }
    void UpdateIdle()
    {
        _state = CreatureState.Idle;
    }
    void GetDirInput()
    {
        if (Input.GetKey(KeyCode.W))
        {
            //transform.position += Vector3.up * Time.deltaTime * 5f;
            Dir = MoveDir.Up;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            //transform.position += Vector3.down * Time.deltaTime * 5f;
            Dir = MoveDir.Down;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            //transform.position += Vector3.left * Time.deltaTime * 5f;
            Dir = MoveDir.Left;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            //transform.position += Vector3.right * Time.deltaTime * 5f;
            Dir = MoveDir.Right;
        }
    }
}