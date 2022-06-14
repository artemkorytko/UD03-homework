using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomCalculator : MonoBehaviour
{
    void Start()
    {
        int num = 3;
        for (int i = 0; i < num; i++)
        {
            int value1 = Random.Range(0, 20);
            int value2 = Random.Range(0, 20);
            int value3 = Random.Range(0, 4);
            Debug.Log(value1);
            Debug.Log(value2);
            Debug.Log(value3);



            switch (value3)
            {
                case 4:
                    Debug.Log(Mathf.Pow(value1, value2));
                    break;
                case 3:
                    Debug.Log(value1 + value2);
                    break;
                case 2:
                    Debug.Log(value1 - value2);
                    break;
                case 1:
                    Debug.Log(value1 * value2);
                    break;
                case 0:
                    if (value2 == 0)
                    {
                        Debug.Log("Операция не может быть проведена: делитель равен нулю");
                    }
                    else
                    {
                        Debug.Log(value1 / value2);
                    }
                    break;
            }

        }
    }
}
