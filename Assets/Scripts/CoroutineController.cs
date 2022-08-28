using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class CoroutineController : MonoBehaviour
{
    [SerializeField] private Vector3 finish;
    [SerializeField] private Vector3 finishJump;
    [SerializeField] private float speed;
    [SerializeField] private float rotateSpeed;

    private bool _isMoving;
    private bool _isFinish;
    private string _finishText;
    
    public static event Action<string, Color> CoroutineFinished;

    private void Start()
    {
        _finishText = "Woohoo! Coroutines is working!";
        _isFinish = true;
    }

    private void Update()
    {
        if (_isFinish && transform.position == Vector3.zero && transform.rotation == Quaternion.Euler(0,0,0))
        {
            _isFinish = false;
            StartCoroutine(MoveFromCoroutine(finish, finishJump));
        }
    }

    private IEnumerator MoveFromCoroutine(Vector3 moveToZ, Vector3 moveToY)
    {
        _isMoving = true;
        
        while (transform.position.z != moveToZ.z)
        {
            transform.position = Vector3.MoveTowards(transform.position, moveToZ, speed*Time.deltaTime);
            yield return null;
        }

        while (transform.position.y != moveToY.y)
        {
            Rotate();
            transform.position = Vector3.MoveTowards(transform.position, moveToY, speed*Time.deltaTime);
            yield return null;
        }
        
        while (transform.position.y != moveToZ.y)
        {
            Rotate();
            transform.position = Vector3.MoveTowards(transform.position, moveToZ, speed*Time.deltaTime);
            yield return null;
        }

        while (transform.position != Vector3.zero)
        {
            transform.position = Vector3.MoveTowards(transform.position, Vector3.zero, speed*Time.deltaTime);
            yield return null;
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
        CoroutineFinished?.Invoke(_finishText, Color.blue);
    }
}
