using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class UniTaskController : MonoBehaviour
{
    [SerializeField] private Vector3 finish;
    [SerializeField] private Vector3 finishJump;
    [SerializeField] private float speed;
    [SerializeField] private float rotateSpeed;
    
    private string _finishText = "Woohoo! UniTasks is working!";
    public static event Action<string, Color> UniTaskFinished;
    
    public void StartMoving()
    {
        MoveForward(finish);
    }
    

    async UniTask MoveForward(Vector3 moveToZ)
    {
        while (transform.position.z != moveToZ.z)
        {
            transform.position = Vector3.MoveTowards(transform.position, moveToZ, speed * Time.deltaTime);
            await UniTask.Yield();
        }
        MoveUp(finishJump);
    }

    async UniTask MoveUp(Vector3 moveToY)
    {
        while (transform.position.y != moveToY.y)
        {
            Rotate();
            transform.position = Vector3.MoveTowards(transform.position, moveToY, speed*Time.deltaTime);
            await UniTask.Yield();
        }
        MoveDown(finish);
    }

    async UniTask MoveDown(Vector3 moveToZ)
    {
        while (transform.position.y != moveToZ.y)
        {
            Rotate();
            transform.position = Vector3.MoveTowards(transform.position, moveToZ, speed*Time.deltaTime);
            await UniTask.Yield();
        }
        MoveBack(Vector3.zero);
    }

    async UniTask MoveBack(Vector3 startPoint)
    {
        while (transform.position != startPoint)
        {
            transform.position = Vector3.MoveTowards(transform.position, startPoint, speed*Time.deltaTime);
            await UniTask.Yield();
        }
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
    
    private bool IsReadToStartMove()
    {
        if (transform.position == Vector3.zero && transform.rotation == Quaternion.Euler(0, 0, 0))
            return true;
        else
            return false;
    }
}
