using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class SwitchCalculator : MonoBehaviour
{
    private int _value1;
    private int _value2;
    private int _valueNumberOperation;

    private void Start()
    {
        _value1 = Random.Range(0, 10);
        _value2 = Random.Range(0, 10);
        _valueNumberOperation = Random.Range(0, 4);
        Debug.Log("Selected random value1: " + _value1);
        Debug.Log("Selected random value2: " + _value2);
        Debug.Log("Selected random operation: " + _valueNumberOperation);
        Debug.Log("Random operation: 0: + , 1: - , 2: * , 3: / , 4: ^ ");

        switch (_valueNumberOperation)
        {
            case 0:
                Debug.Log("Sum + = " + (_value1 + _value2));
                break;
            case 1:
                Debug.Log("Sub - = " + (_value1 - _value2));
                break;
            case 2:
                Debug.Log("Mult * = " +(_value1 * _value2));
                break;
            case 3:
                if (_value2 != 0)
                {
                    Debug.Log("Div / = " + (_value1 / _value2));
                }
                else
                {
                    Debug.Log("Error! Can't be divided: /0");
                }
                break;
            case 4:
                Debug.Log("Pow ^ = " + (int)Math.Pow(_value1, _value2));
                break;
        }
    }
}