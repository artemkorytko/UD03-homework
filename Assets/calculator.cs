using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class calculator : MonoBehaviour
{
    int a;
    int b;
    int c;

    // Start is called before the first frame update
    void Start()
    {
        a = Random.Range(0, 10);
        b = Random.Range(0, 10);
        c = Random.Range(0, 4);

        Debug.Log("c =  " + c);
        if (c == 1)
        {
            Add();
        }
        if (c == 2)
        {
            Sub();
        }
        if (c == 3 && b>0) 
        {
            Div();

        }
        if (c == 4)
        {
            Mult();
        }
      
    }

    private void Add()
    {
        int d = a + b;
        Debug.Log("Add a + b =  " + d); 
    }
    private void Sub()
    {
        int e = a - b;
        Debug.Log("Sub a - b = " + e);
    }
    private void Div()
    {
        int f = a / b;
        Debug.Log("Div a / b = " + f);
    }
    private void Mult()
    {
        int g = a * b;
        Debug.Log("Mult a * b = " + g);
    }

}
