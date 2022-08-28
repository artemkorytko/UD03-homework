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
        _isMovingForward = true;
    }

    private void Update()
    {
        if (transform.position == Vector3.zero && transform.rotation == Quaternion.Euler(0, 0, 0))
        {
            _isMovingForward = true;
            _isFinish = false;
        }
        
        if (transform.position.z == finish.z && transform.position.y != finishJump.y && !_isJumpingDown && !_isMovingBack)
        {
            _isMovingForward = false;
            _isJumpingUp = true;
        }
        
        if (transform.position.y == finishJump.y )
        {
            _isJumpingUp = false;
            _isJumpingDown = true;
        }
        
        if (transform.position.y == finish.y && transform.position.z != 0 && transform.rotation == Quaternion.Euler(0, 180, 0))
        {
            _isJumpingDown = false;
            _isMovingBack = true;
        }
        
        if (transform.position == Vector3.zero && transform.rotation == Quaternion.Euler(0, 180, 0))
        {
            _isMovingBack = false;
            _isMovingForward = false;
            _isFinish = true;
        }
    }

    private void FixedUpdate()
    {
        
        if (_isMovingForward)
        {
            MoveTo(finish);
        }
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
        {
            MoveTo(Vector3.zero);
        }
        else if (_isFinish)
        {
            Finish();
        }
    }
    

    private void MoveTo(Vector3 moveTo)
    {
        transform.position = Vector3.MoveTowards(transform.position, moveTo, speed * Time.deltaTime);
    }
    
    private void Rotate()
    {
        if (transform.rotation != Quaternion.Euler(0,180,0))
        {
            transform.Rotate(0, rotateSpeed*Time.fixedDeltaTime, 0);
        }
    }
    
    private void Finish()
    {
        _isMovingBack = false;
        _isMovingForward = false;
        UpdatesFinished?.Invoke(_finishText, Color.green);
    }
}
