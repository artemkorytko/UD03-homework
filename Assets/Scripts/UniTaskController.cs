using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class UniTaskController : MonoBehaviour
{
    [SerializeField] private Vector3 moveToZ;
    [SerializeField] private Vector3 moveToY;
    [SerializeField] private float speed;
    [SerializeField] private float rotateSpeed;
    
    private string _finishText;
    private bool _isFinish;
    private bool _isMoving;
    public static event Action<string, Color> UniTaskFinished;
    
    private void Start()
    {
        _finishText = "Woohoo! UniTasks is working!";
        _isFinish = true;
    }
    
    private void Update()
    {
        if (_isFinish && transform.position == Vector3.zero && transform.rotation == Quaternion.Euler(0,0,0))
        {
            _isFinish = false;
            StartMovingUniTasks(moveToZ, moveToY);
        }
    }

    async UniTask StartMovingUniTasks(Vector3 moveToZ, Vector3 moveToY)
    {
        _isMoving = true;
        
        while (transform.position.z != moveToZ.z)
        {
            transform.position = Vector3.MoveTowards(transform.position, moveToZ, speed*Time.deltaTime);
            await UniTask.Yield(); 
        }
        
        while (transform.position.y != moveToY.y)
        {
            Rotate();
            transform.position = Vector3.MoveTowards(transform.position, moveToY, speed*Time.deltaTime);
            await UniTask.Yield();
        }
        
        while (transform.position.y != moveToZ.y)
        {
            Rotate();
            transform.position = Vector3.MoveTowards(transform.position, moveToZ, speed*Time.deltaTime);
            await UniTask.Yield();
        }

        while (transform.position != Vector3.zero)
        {
            transform.position = Vector3.MoveTowards(transform.position, Vector3.zero, speed*Time.deltaTime);
            await UniTask.Yield();
        }
        
        _isMoving = false;
        _isFinish = true;
        Finish();
            

        
    }
    
    private void Rotate()
    {
        if (transform.rotation != Quaternion.Euler(0,180,0))
        {
            transform.Rotate(0, rotateSpeed*Time.deltaTime, 0);
        }
    }

    private void Finish()
    {
        UniTaskFinished?.Invoke(_finishText, Color.red);
    }
}
