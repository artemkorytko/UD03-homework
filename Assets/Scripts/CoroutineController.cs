using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class CoroutineController : MonoBehaviour
{
    [SerializeField] private Vector3 finish;
    [SerializeField] private Vector3 finishJump;
    [SerializeField] private float speed;
    [SerializeField] private float rotateSpeed;
    
    private string _finishText = "Woohoo! Coroutines is working!";

    public static event Action<string, Color> CoroutineFinished;
    
    public void StartMoving()
    {
        StartCoroutine(MoveForward(finish));
    }
    

    private IEnumerator MoveForward(Vector3 moveToZ)
    {
        while (transform.position.z != moveToZ.z)
        {
            transform.position = Vector3.MoveTowards(transform.position, moveToZ, speed * Time.deltaTime);
            yield return null;
        }
        yield return StartCoroutine(MoveUp(finishJump));
    }

    private IEnumerator MoveUp(Vector3 moveToY)
    {
        while (transform.position.y != moveToY.y)
        {
            Rotate();
            transform.position = Vector3.MoveTowards(transform.position, moveToY, speed*Time.deltaTime);
            yield return null;
        }
        yield return StartCoroutine(MoveDown(finish));
    }

    private IEnumerator MoveDown(Vector3 moveToZ)
    {
        while (transform.position.y != moveToZ.y)
        {
            Rotate();
            transform.position = Vector3.MoveTowards(transform.position, moveToZ, speed*Time.deltaTime);
            yield return null;
        }
        yield return StartCoroutine(MoveBack(Vector3.zero));
    }

    private IEnumerator MoveBack(Vector3 startPoint)
    {
        while (transform.position != startPoint)
        {
            transform.position = Vector3.MoveTowards(transform.position, startPoint, speed*Time.deltaTime);
            yield return null;
        }
        Finish();
    }

    private void Rotate()
    {
        if (transform.rotation != Quaternion.Euler(0,180,0))
            transform.Rotate(0, rotateSpeed*Time.deltaTime, 0);
    }

    private void Finish()
    {
        CoroutineFinished?.Invoke(_finishText, Color.blue);
    }
    
}
