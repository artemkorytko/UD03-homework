using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class AdvancedCalculator : MonoBehaviour
{
    public Text _text;
    double _value1;
    double _value2;
    string operation;

    public void ClickNumber(int val)
    {
        Debug.Log(message: $"check val: {val}");
        if (_text.text == "0")
        {
            _text.text = $"{val}";
        }
        else
        {
            _text.text = _text.text + $"{val}";
        }
    }
    public void ClickDecimal(string val)
    {
        Debug.Log(message: $"check val: {val}");
        if (_text.text == "0")
        {
            _text.text = $"{val}";
        }
        else
        {
            _text.text = _text.text + $"{val}";
        }
    }
    public void ClickOperation(string val)
    {
        _value1 = double.Parse(_text.text);
        operation = $"{val}";
        _text.text = "";
    }
    public void ClickPlusMinus()
    {
        double conv = Convert.ToDouble(_text.text);
        _text.text = Convert.ToString(-1 * conv);
    }
    public void ClickAllClear()
    {
        _text.text = "0";
        string v1, v2;
        v1 = Convert.ToString(_value1);
        v2 = Convert.ToString(_value2);

        v1 = "";
        v2 = "";
    }
    public void ClickErase()
    {
        if (_text.text.Length > 0)
        {
            _text.text = _text.text.Remove(_text.text.Length - 1, 1);
        }
        if (_text.text == "")
        {
            _text.text = _text.text = "0";
        }
    }
    public void ClickResult()
    {
        _value2 = double.Parse(_text.text);
        switch (operation)
        {
            case "+":
                _text.text = (_value1 + _value2).ToString();
                break;
            case "-":
                _text.text = (_value1 - _value2).ToString();
                break;
            case "*":
                _text.text = (_value1 * _value2).ToString();
                break;
            case "/":
                if(_value2 != 0)
                {
                    _text.text = (_value1 / _value2).ToString();
                }
                else
                {
                    _text.text = "Error. Ñan not be divided by zero";
                }
             break;

        }
    }    
}