using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Define;

public class CreatureController : MonoBehaviour
{
    protected Animator animator;
    public Vector3Int CellPos { get; set; } = Vector3Int.zero;
    protected SpriteRenderer _sprite;
    protected CreatureState _state = CreatureState.Idle;

    //public virtual CreatureState State
    //{
    //    get { return _state; }
    //    set { 
    //        if (_state == value)
    //        {
    //            return;
    //        }
    //        _state = value;
    //        UpdateAnimation();
    //    }
    //}
    //protected MoveDir _dir = MoveDir.Right;
    //public MoveDir Dir
    //{
    //    get { return _dir; }
    //    set
    //    {
    //        if (_dir == value)
    //            return;
    //        _dir = value;

    //        _lastDir = value;
     
    //        UpdateAnimation();
    //    }
    //}
    //protected virtual void UpdateAnimation()
    //{
    //    if (_state == CreatureState.Idle)
    //    {
    //        switch (_lastDir)
    //        {
    //            case MoveDir.Up:
    //                animator.Play("IDLE_UP");
    //                transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
    //                break;
    //            case MoveDir.Down:
    //                animator.Play("IDLE_DOWN");
    //                transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
    //                break;
    //            case MoveDir.Right:
    //                animator.Play("IDLE_LEFT");
    //                transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
    //                break;
    //            case MoveDir.Left:
    //                animator.Play("IDLE_LEFT");
    //                transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
    //                break;
    //        }
    //    }
    //    else if (_state == CreatureState.Moving)
    //    {
    //        switch (_dir)
    //        {
    //            case MoveDir.Up:
    //                animator.Play("WALK_UP");
    //                transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
    //                break;
    //            case MoveDir.Down:

    //                animator.Play("WALK_DOWN");
    //                transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
    //                break;
    //            case MoveDir.Right:

    //                animator.Play("WALK_LEFT");
    //                transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
    //                break;
    //            case MoveDir.Left:
    //                animator.Play("WALK_LEFT");
    //                transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
    //                break;
    //        }
    //    }
    //}
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {

    }
   
}
