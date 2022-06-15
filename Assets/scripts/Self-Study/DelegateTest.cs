using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelegateTest : MonoBehaviour
{
    private delegate void Operation(int value1,int value2);
    private Operation _operation;

    private static void Sum(int value1, int value2)
    {
        int result = value1 + value2;
        Debug.Log($"Delegate method is sum: {value1} + {value2} = {result}");
    }

    private static void Multiply(int value1, int value2)
    {
        int result = value1 * value2;
        Debug.Log($"Delegate method is multiply: {value1} * {value2} = {result}");
    }

    private void Start()
    {
        _operation = Sum;
        _operation(3, 3);

        _operation = Multiply;
        _operation(2,2);
    }
}
