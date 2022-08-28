using System;
using UnityEngine;

public class UpdateController : MonoBehaviour
{

    [SerializeField] private Vector3 finish;
    [SerializeField] private Vector3 finishJump;
    [SerializeField] private float speed;
    [SerializeField] private float rotateSpeed;
    
    private bool _isMovingForward;
    private bool _isMovingBack;
    private bool _isJumpingUp;
    private bool _isJumpingDown;
    private bool _isFinish;

    private string _finishText;

    public static event Action<string, Color> UpdatesFinished;
    
    private void Start()
    {
        _finishText = "Woohoo! Updates is working!";
    }

    private void Update()
    {
        if (_isMovingForward)
            MoveTo(finish);
        else if (_isJumpingUp)
        {
            MoveTo(finishJump);
            Rotate();
        }
        else if (_isJumpingDown)
        {
            MoveTo(finish);
            Rotate();
        }
        else if (_isMovingBack)
            MoveTo(Vector3.zero);
        else if (_isFinish)
            Finish();
    }   
        
    private void LateUpdate()
    {
        if (IsReadToMoveForward())
        {
            _isMovingForward = true;
            _isFinish = false;
        }
        
        if (IsReadToJumpUp())
        {
            _isMovingForward = false;
            _isJumpingUp = true;
        }
        
        if (IsReadToJumpDown())
        {
            _isJumpingUp = false;
            _isJumpingDown = true;
        }
        
        if (IsReadToMoveBack())
        {
            _isJumpingDown = false;
            _isMovingBack = true;
        }
        
        if (IsFinish())
        {
            _isMovingBack = false;
            _isMovingForward = false;
            _isFinish = true;
        }
    }
        
    private void MoveTo(Vector3 moveTo)
    {
        transform.position = Vector3.MoveTowards(transform.position, moveTo, speed * Time.deltaTime);
    }
    
    private void Rotate()
    {
        if (transform.rotation != Quaternion.Euler(0,180,0))
            transform.Rotate(0, rotateSpeed*Time.deltaTime, 0);
    }
    
    private void Finish()
    {
        _isMovingBack = false;
        _isMovingForward = false;
        UpdatesFinished?.Invoke(_finishText, Color.green);
    }

    private bool IsReadToMoveForward()
    {
        if (transform.position == Vector3.zero && transform.rotation == Quaternion.Euler(0, 0, 0))
            return true;
        else
            return false;
    }
    
    private bool IsReadToJumpUp()
    {
        if (transform.position.z == finish.z && transform.position.y != finishJump.y && !_isJumpingDown && !_isMovingBack)
            return true;
        else
            return false;
    }
    
    private bool IsReadToJumpDown()
    {
        if (transform.position.y == finishJump.y && _isJumpingUp)
            return true;
        else
            return false;
    }
    
    private bool IsReadToMoveBack()
    {
        if (transform.position.y == finish.y && transform.position.z != 0 && transform.rotation == Quaternion.Euler(0, 180, 0))
            return true;
        else
            return false;
    }
    
    private bool IsFinish()
    {
        if (transform.position == Vector3.zero && transform.rotation == Quaternion.Euler(0, 180, 0))
            return true;
        else
            return false;
    }
}
