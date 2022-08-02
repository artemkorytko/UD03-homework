using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CalculatorScript : MonoBehaviour
{
    #region Fields
    public TextMeshProUGUI inputText;
    private float _result;
    private float _input;
    private float _input2;
    private string _operation;

    #endregion Fields

    #region Methods
    public void ClickNumber(int val)
    {
        Debug.Log(message: $"check val: {val}");
        inputText.text = $"{val}";
        if (_input == 0)
        {
            _input = val;
        }
        else
        {
            _input2 = val;
        }
    }
    public void ClickOperation(string val)
    {
        Debug.Log(message: $"check val: {val}");
        _operation = val;
    }
    public void ClickEqual(string val)
    {
        Debug.Log(message: $"check val: {val}");
        if (_input != 0 && _input2 != 0 && !string.IsNullOrEmpty(_operation))
        {
            switch (_operation)
            {
                case "+":
                    _result = _input + _input2;
                    break;
                case "-":
                    _result = _input - _input2;
                    break;
                case "*":
                    _result = _input * _input2;
                    break;
                case "/":
                    _result = _input / _input2;
                    break;
                case "%":
                    _result = _input % _input2;
                    break;

            }

            inputText.SetText(_result.ToString());
            ClearInput();
        }
    }
    private void ClearInput()
    {
        _input = 0;
        _input2 = 0;
    }
    public void ClickPeriod(string val)
    {
        Debug.Log(message: $"check val: {val}");
    }
    public void ClickErase(string val)
    {
        Debug.Log(message: $"check val: {val}");
    }
    #endregion Methods

    #region Events

    #endregion Events
}
