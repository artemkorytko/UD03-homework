using System;
using System.Linq;
using TMPro;
using UnityEngine;


namespace CalculatorRPN
{
    public class CalculatorManager : MonoBehaviour
    {
        private TMP_InputField _inputField;
        private CalculatorRPN _calculator;

        private void Start()
        {
            _inputField = GetComponentInChildren<TMP_InputField>();
            _calculator = new CalculatorRPN();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                Calculate();
            }
        }

        public void Calculate()
        {
            if (_inputField.text.Length > 0)
            {
                _inputField.text = _calculator.Calculate(_inputField.text);
            }
        }

        public void AC()
        {
            _inputField.text = "0";
        }

        public void AddComma()
        {
            _inputField.text += ",";
        }

        public void Click(TextMeshProUGUI textMeshPro)
        {
            if (_inputField.text == "0")
            {
                _inputField.text = textMeshPro.text;
            }
            else
            {
                _inputField.text += textMeshPro.text;
            }
        }

        public void Filter()
        {
            if (_inputField.text.Length > 0)
            {
                if (char.IsLetter(_inputField.text.Last()))
                {
                    _inputField.text = _inputField.text.Remove(_inputField.text.Length - 1);
                }
            }
        }
        
    }
}
