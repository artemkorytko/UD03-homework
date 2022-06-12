using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task2 : MonoBehaviour
{
    Calculations2 myCalculations;

    void Start()
    {
        myCalculations = new Calculations2();
    }


}

public class Calculations2
{
    private int _value1 = Random.Range(0, 10);
    private int _value2 = Random.Range(0, 10);
    private int _value3 = Random.Range(0, 4);
    public Calculations2()
    {
        switch (_value3)
        {
            case 0:
                Sum();
                break;
            case 1:
                Diff();
                break;
            case 2:
                Multiply();
                break;
            case 3:
                Division();
                break;
        }



    }

    void Sum()
    {
        Debug.Log(_value1 + _value2);
    }

    void Diff()
    {
        Debug.Log(_value1 - _value2);
    }

    void Multiply()
    {
        Debug.Log(_value1 * _value2);
    }

    void Division()
    {
        if (_value2 == 0)
        {
            Debug.Log("Error");
        }
        else
        {
            Debug.Log(_value1 / _value2);
        }
    }
}





