using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalculatorSwitchCase : MonoBehaviour
{
    private int _value1;
    private int _value2;
    private int _value3;
    
    // Start is called before the first frame update
    private void Start()
    {
        _value1 = Random.Range(0, 10);
        _value2 = Random.Range(0, 10);
        _value3 = Random.Range(0, 3);
        CulateWithSwitchCase(_value3);
        
       
    }
    
    private void CulateWithSwitchCase(int _value3)
    {
        

        switch (_value3)
        {
            case 0 :
                Debug.Log(_value1 + _value2);
                print("+");
                break;
            case 1:
                Debug.Log(_value1 - _value2);
                print("-");
                break;
            case 2 :
                Debug.Log(_value1 * _value2);
                print("*");
                break;
            case 3 :
                Debug.Log(_value1/_value2);
                print("/");
                break;
        }
    }

}
