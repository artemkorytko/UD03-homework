using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HW1 : MonoBehaviour
{
    private int _value1;
    private int _value2;
    private int _value3;
    private int repeatsValue;

    [System.Obsolete]
    void Start()
    {
        _value1 = Random.RandomRange(0, 10);
        _value2 = Random.RandomRange(0, 10);
        _value3 = Random.RandomRange(0, 4);
   
        Debug.Log($"Value1 = {_value1}, Value2 = {_value2}, Value3 = {_value3}");

        //cycle for
        repeatsValue = 3;
        Debug.Log("Cycle for:");
        for (int i = 0; i < repeatsValue; i++)
        {
            PerfomanceTasks();
        }

        //cycle do..while
        Debug.Log("Cycle do..while:");
        do
        {
            PerfomanceTasks();
            repeatsValue--;
        }
        while (repeatsValue > 0);

        //cycle while
        Debug.Log("Cycle while:");
        repeatsValue = 3;
        while (repeatsValue > 0)
        {
            PerfomanceTasks();
            repeatsValue--;
        }

        //cycle foreach
        Debug.Log("Cycle foreach:");
        int[] repeats = new int[] { 0, 1, 2 };
        foreach (int i in repeats)
        {
            PerfomanceTasks();
        }
    }

    private void TaskRandomCalculatorWithIfElse(int value1, int value2, int value3)
    {
        int result;
        value1 = _value1;
        value2 = _value2;
        value3 = _value3;

        if (value3 == 0)
        {
            result = value1 + value2;
            Debug.Log($"Operation +. Result: {value1} + {value2} = {result}");
        }
        else if (value3 == 1)
        {
            result = value1 - value2;
            Debug.Log($"Operation -. Result: {value1} - {value2} = {result}");
        }
        else if (value3 == 2)
        {
            result = value1 * value2;
            Debug.Log($"Operation *. Result: {value1} * {value2} = {result}");
        }
        else if (value3 == 3)
        {
            if(value2 != 0)
            {
                result = value1 / value2;
                Debug.Log($"Operation /. Result: {value1} / {value2} = {result}");
            }
            else
            {
                Debug.Log("Value2 = 0. Unable to perform division operation");
            }   
        }
        else if (value3 == 4)
        {
            result = System.Convert.ToInt32(Mathf.Pow(value1,value2));
            Debug.Log($"Operation ^. Result: {value1} ^ {value2} = {result}");
        }
        else
        {
            Debug.Log("Wrong value3");
        }      
    }

    private void TaskRandomCalculatorWithSwitchCase (int value1, int value2, int value3)
    {
        int result;
        value1 = _value1;
        value2 = _value2;
        value3 = _value3;

        switch(value3)
        {
            case 0:
                result = value1 + value2;
                Debug.Log($"Operation +. Result: {value1} + {value2} = {result}");
                break;
            case 1:
                result = value1 - value2;
                Debug.Log($"Operation -. Result: {value1} - {value2} = {result}");
                break;
            case 2:
                result = value1 * value2;
                Debug.Log($"Operation *. Result: {value1} * {value2} = {result}");
                break;
            case 3:
                if (value2 != 0)
                {
                    result = value1 / value2;
                    Debug.Log($"Operation /. Result: {value1} / {value2} = {result}");
                    break;
                }
                else
                {
                    Debug.Log("Value2 = 0. Unable to perform division operation");
                    break;
                }
            case 4:
                result = System.Convert.ToInt32(Mathf.Pow(value1, value2));
                Debug.Log($"Operation ^. Result: {value1} ^ {value2} = {result}");
                break;
        }
    }

    private void PerfomanceTasks()
    {
        Debug.Log("Task random calculator with if-else:");
        TaskRandomCalculatorWithIfElse(_value1, _value2, _value3);

        Debug.Log("Task random calculator with switch-case:");
        TaskRandomCalculatorWithSwitchCase(_value1, _value2, _value3);
    }
}
