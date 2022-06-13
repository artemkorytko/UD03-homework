using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomCalculator : MonoBehaviour
{
    private int value1;
    private int value2;
    private int value3;

    // Start is called before the first frame update
    private void Start()
    {
        value1 = Random.Range(0, 10);
        value2 = Random.Range(0, 10);
        value3 = Random.Range(0, 4);

        CheckCondition(value3);
    }

    private void CheckCondition(int value3)
    {
        if (value3 == 0)
        {
            Debug.Log(value1 + value2);
            print("sum");
        }
        if (value3 == 1)
        {
            Debug.Log(value1 - value2);
            print("subtract");
        }
        if(value3 == 2)
        {
            Debug.Log(value1 * value2);
            print("multi");
        }   
        if(value3 == 3)
        {
            Debug.Log(value1 / value2);
            print("division");
            if (value2 == 0)
            {
                Debug.Log("can not divide by zero");
            }
        }
        if(value3 == 4)
        {
            Debug.Log(value1 ^ value2);
            print("exponent");
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
