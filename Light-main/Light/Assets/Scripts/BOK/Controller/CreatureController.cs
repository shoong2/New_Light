using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Define;

public class CreatureController : MonoBehaviour
{
    protected Animator animator;
    public Vector3Int CellPos { get; set; } = Vector3Int.zero;
    protected SpriteRenderer _sprite;
    CreatureState _state = CreatureState.Idle;

    public CreatureState State
    {
        get { return _state; }
        set { 
            if (_state == value)
            {
                return;
            }
            _state = value;
            UpdateAnimation();
        }
    }

    MoveDir _lastDir = MoveDir.Down;
    MoveDir _dir = MoveDir.Down;
    public MoveDir Dir
    {
        get { return _dir; }
        set
        {
            if (_dir == value)
                return;
            _dir = value;
            if (value != MoveDir.None)
            {
                _lastDir = value;
            }
            UpdateAnimation();
        }
    }
    protected virtual void UpdateAnimation()
    {
        if (_state == CreatureState.Idle)
        {
            switch (_lastDir)
            {
                case MoveDir.Up:
                    animator.Play("IDLE_UP");
                    transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
                    break;
                case MoveDir.Down:
                    animator.Play("IDLE_DOWN");
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
            switch (_dir)
            {
                case MoveDir.Up:
                    animator.Play("WALK_UP");
                    transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
                    break;
                case MoveDir.Down:

                    animator.Play("WALK_DOWN");
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
        else
        {

        }
    }
    void Start()
    {
        Init();
    }
    // Update is called once per frame
    void Update()
    {
        UpdateController();
    }
    protected virtual void Init()
    {
        animator = GetComponent<Animator>();
        _sprite = GetComponent<SpriteRenderer>();
        Vector3 pos = Managers.Map.CurrentGrid.CellToWorld(CellPos) + new Vector3(0.5f, 0.5f, -2);
        transform.position += pos;
    }
    protected virtual void UpdateController()
    {
        UpdateIsMoving();
        UpdatePosition();
    }

    
    void UpdatePosition()
    {
        if (State != CreatureState.Moving)
        {
            return;
        }
        Vector3 destPos = Managers.Map.CurrentGrid.CellToWorld(CellPos) + new Vector3(0.5f, 0.5f);
        Vector3 moveDir = destPos - transform.position;

        float distance = moveDir.magnitude;
        if (distance < 5f * Time.deltaTime)
        {
            transform.position = destPos;
            _state = CreatureState.Idle;
            if (_dir == MoveDir.None)
            {
                UpdateAnimation();
            }
        }
        else
        {
            transform.position += moveDir.normalized * 5f * Time.deltaTime;
            State = CreatureState.Moving;
        }
    }
    
    void UpdateIsMoving()
    {
        if (State==CreatureState.Idle&&_dir!=MoveDir.None)
        {
            Vector3Int destPos = CellPos;
            switch (_dir)
            {
                case MoveDir.Up:
                    destPos+= Vector3Int.up;
                    break;
                case MoveDir.Down:
                    destPos+= Vector3Int.down;
                    break;
                case MoveDir.Left:
                    destPos+= Vector3Int.left;
                    break;
                case MoveDir.Right:
                    destPos+= Vector3Int.right;
                    break;
            }

            State = CreatureState.Moving;
            if (Managers.Map.CanGo(destPos))
            {
                if (Managers.Object.Find(destPos) == null)
                {
                    CellPos = destPos;
                }
            }
        }
    }
    
    

   
}
