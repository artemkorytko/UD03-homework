using System;
using TMPro;
using UnityEngine;

public class Calculator : MonoBehaviour
{
    [SerializeField] private GameObject errorPanel;
    [SerializeField] private TMP_Text errorText;
    [SerializeField] private TMP_InputField _inputField;
    
    private string input;
    private char[] charMas;
    private int signCount;
    private int bracketStartCount;
    private int bracketFinishCount;
    private int numberCount;
    private Logic logic;

    private void Start()
    {
        logic = new Logic();
    }

    public void StartCalculate()
    {
        if (IsValidity() && errorPanel.gameObject.activeSelf!=true)
        {
            _inputField.text = logic.CheckBracketsAndCalculate(_inputField.text);
        }
    }

    public void BackSpace()
    {
        if (_inputField.text.Length!=0)
        {
            int lastCharIndex = _inputField.text.Length-1;
            _inputField.text = _inputField.text.Remove(lastCharIndex);
        }
        else
        {
            Debug.Log("String have not symbols");
        }
    }

    public void Agree()
    {
        errorPanel.gameObject.SetActive(false);
        _inputField.readOnly = false;
        _inputField.text = "";
    }

    private bool IsValidity()
    {
        
        signCount = 0; //каунтер для знаков
        bracketStartCount = 0; //каунтер для скобки '('
        bracketFinishCount = 0; //каунтер для скобки ')'
        numberCount = 0; //каунтер для чисел

        charMas = _inputField.text.ToCharArray();

        if (charMas.Length>=3)
        {
            for (int i = 0; i < charMas.Length; i++)
            {
                if (i==0)
                {
                    if (charMas[i]=='(')
                    {
                        bracketStartCount++;
                    }
                    else if (Char.IsNumber(charMas[i]) && !Char.IsNumber(charMas[i+1]))
                    {
                        numberCount++;
                    }
                }
                else if (i>0)
                {
                    if (charMas[i]=='+' || charMas[i]=='-' || charMas[i]=='*' || charMas[i]=='/')
                    {
                        signCount++;
                    }
                    else if (charMas[i]=='(')
                    {
                        bracketStartCount++;
                    }
                    else if (charMas[i]==')')
                    {
                        bracketFinishCount++;
                    }
                    else if (Char.IsNumber(charMas[i]))
                    {
                        if (i+1>charMas.Length-1 || (i+1<=charMas.Length && !Char.IsNumber(charMas[i+1])))
                        {
                            numberCount++;
                        }
                    }
                }
            }

            if (signCount==0)
            {
                errorPanel.gameObject.SetActive(true);
                _inputField.readOnly = true;
                errorText.text = "Have not signs!";
            }
            else if (bracketStartCount!=bracketFinishCount)
            {
                errorPanel.gameObject.SetActive(true);
                _inputField.readOnly = true;
                errorText.text = "Wrong brackets!";
            }
            else if (numberCount<2)
            {
                errorPanel.gameObject.SetActive(true);
                _inputField.readOnly = true;
                errorText.text = "Minimum 2 values!";
            }
        }
        else
        {
            errorPanel.gameObject.SetActive(true);
            _inputField.readOnly = true;
            errorText.text = "Your text is low!";
        }
                
                
                
        for (int i = 0; i < charMas.Length; i++)
        {
            if (i==0 && !Char.IsNumber(charMas[i])) //первый символ
            {
                if (charMas[i] != '-' && charMas[i] != '(')
                {
                    errorPanel.gameObject.SetActive(true);
                    _inputField.readOnly = true;
                    errorText.text = "Can't start with this symbol!";
                    break;
                }
            }
            else if (i==charMas.Length-1 && !Char.IsNumber(charMas[i])) //последний символ
            {
                if (charMas[i]!=')')
                {
                    errorPanel.gameObject.SetActive(true);
                    _inputField.readOnly = true;
                    errorText.text = "Can't end with this symbol!";
                    break;
                }
            }
            else //все остальные
            {
                if (Char.IsLetter(charMas[i]))
                {
                    errorPanel.gameObject.SetActive(true);
                    _inputField.readOnly = true;
                    errorText.text = "Error, have a letters!";
                    break;
                }
                else if (IsSign(charMas[i]))
                {
                    if (IsSign(charMas[i+1]) || charMas[i+1]==')' || charMas[i+1]=='.')
                    {
                        errorPanel.gameObject.SetActive(true);
                        _inputField.readOnly = true;
                        errorText.text = "Error! Two signes!";
                        break;
                    }
                }
                else if (charMas[i]=='.')
                {
                    if (!Char.IsNumber(charMas[i+1]))
                    {
                        errorPanel.gameObject.SetActive(true);
                        _inputField.readOnly = true;
                        errorText.text = "Wrong place for point!";
                        break;
                    }
                }
                else if(!Char.IsNumber(charMas[i]) && !IsSign(charMas[i]) && charMas[i]!='(' && charMas[i]!=')')
                {
                    errorPanel.gameObject.SetActive(true);
                    _inputField.readOnly = true;
                    errorText.text = "Error! Can't understand it...";
                    break;
                }

            }
        }

        return true;
    }
    
    public bool IsSign(char ch) 
    {
        if (ch=='+' || ch=='-' || ch=='*' || ch=='/' )
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
