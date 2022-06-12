using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomCalculator : MonoBehaviour
{
    Calculations myCalculations;

    void Start()
    {
        myCalculations = new Calculations();
    }


}

public class Calculations
{
    private int _value1 = Random.Range(0, 10);
    private int _value2 = Random.Range(0, 10);
    private int _value3 = Random.Range(0, 10);
    public Calculations()
    {
        if (_value3 == 0 || _value3 == 2)
        {
            Sum();
        }
        else if (_value3 == 1 || _value3 == 3)
        {
            Diff();
        }
        else if (_value3 == 4 || _value3 == 6)
        {
            Multiply();
        }
        else
        {
            Division();
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
}





