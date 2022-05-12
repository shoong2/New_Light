using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Define;

public class MonsterMove : CreatureController
{
    protected override void Init()
    {
        base.Init();
        State = CreatureState.Idle;
        Dir = MoveDir.None;
    }
    protected override void UpdateController()
    {
        base.UpdateController();
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
        else
        {
            Dir = MoveDir.None;
        }
    }
}
