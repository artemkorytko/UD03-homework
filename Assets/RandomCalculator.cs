using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomCalculator : MonoBehaviour
{
    Intelligence myIntelligence;

    void Start()
    {
        myIntelligence = new Intelligence();
    }


}

public class Intelligence
{
    private int _value1 = Random.Range(0, 10);
    private int _value2 = Random.Range(0, 8);
    private int _value3 = Random.Range(0, 6);
    public Intelligence()
    {
        if (_value3 == 3 || _value3 == 2)
        {
            Sum();
        }
        else if (_value3 == 2 || _value3 == 4)
        {
            Diff();
        }
        else if (_value3 == 5 || _value3 == 2)
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
