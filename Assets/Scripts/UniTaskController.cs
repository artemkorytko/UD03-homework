using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UniTaskController : MonoBehaviour
{
    private string _finishText;
    
    public static event Action<string, Color> UniTaskFinished;
    
    private void Start()
    {
        _finishText = "Woohoo! UniTasks is working!";
    }
    
    private void Finish()
    {
        UniTaskFinished?.Invoke(_finishText, Color.red);
    }
}
