using System;
using System.Globalization;
using UnityEngine;

public class Logic 
{
    public string CheckBracketsAndCalculate(string workString)
    {
            
        bool isBracket;
        do
        {
            if (workString.Contains("(") && workString.Contains(")"))
            {
                string stringForCalculate = null;
                isBracket = true;
                int _index1 = 0;
                int _index2 = 0;
                for (int i = 0; i < workString.Length; i++)
                {
                    if (workString[i]=='(')
                    {
                        _index1 = i;
                    }
                    else if(workString[i]==')')
                    {
                        _index2 = i;
                        break;
                    }
                }

                for (int i = _index1+1; i < _index2; i++)
                {
                    stringForCalculate += workString[i];
                }

                string tmpStr = stringForCalculate;
                stringForCalculate = CalculateString(stringForCalculate);
                workString = workString.Replace("("+ tmpStr + ")", stringForCalculate);
            }
            else
            {
                workString = CalculateString(workString);
                isBracket = false;
            }
        } while (isBracket);

        return workString;
        }

        private string CalculateString(string calc)
        {
            bool isEnd = false;
            do
            {
                if (calc.Contains("+") || calc.Contains("-") || calc.Contains("*") || calc.Contains("/"))
                {
                    string value1 = "";
                    string value2 = "";
                    string sign = "";
                    string result = "";
                    bool isValue1 = false;
                    bool isValue2 = false;

                    if (calc.Contains("*") || calc.Contains("/"))
                    {
                        if (calc.IndexOf("*")!=-1)
                        {
                            sign += "*";
                            calc = DeletionOrMultiplication(calc, sign);

                        }
                        else
                        {
                            sign += "/";
                            calc = DeletionOrMultiplication(calc, sign);
                        }
                    }
                    else
                    {
                        for (int i = 0; i < calc.Length; i++)
                        {
                            if ((calc[i] != '+' && calc[i] != '-') && (!isValue1 && !isValue2))
                            {
                                value1 += calc[i];
                            }
                            else if ((calc[i] == '+' || calc[i] == '-') && !isValue1 && !isValue2)
                            {
                                if (i==0) //проверка если первое значение отрицательное
                                {
                                    value1 += calc[i];
                                }
                                else
                                {
                                    sign += calc[i];
                                    isValue1 = true;
                                }
                                
                            }
                            else if ((calc[i] != '+' && calc[i] != '-') && isValue1 && !isValue2)
                            {
                                value2 += calc[i];
                            }
                            else if ((calc[i] == '+' || calc[i] == '-') && isValue1 && !isValue2)
                            {
                                if (value2=="") //проверка если попадется a+-b
                                {
                                    value2 += calc[i];
                                }
                                else
                                {
                                    isValue2 = true;
                                }
                            }
                        }

                        if (value2=="") //проверка если в строке осталось -a
                        {
                            return calc;
                        }

                        if (float.TryParse(value1, NumberStyles.Any, new CultureInfo("en-US"), out var _value1) && float.TryParse(value2, NumberStyles.Any, new CultureInfo("en-US"), out var _value2))
                        {
                            result = sign=="+" ? $"{_value1 + _value2}" : $"{_value1 - _value2}";
                            result = ChangePoint(result);
                            calc = calc.Replace(value1 + sign + value2, result);
                        }
                        else
                        {
                            Debug.Log("Some problem with TryParse in CalculateString method");
                        }
                    }
                }
                else
                {
                    isEnd = true;
                }
            } while (!isEnd);
            return calc;
        }
        
        private string DeletionOrMultiplication(string calc, string sign)
        {
            string result = "";
            string value1 = "";
            string value2 = "";
            bool isValue1 = false;
            bool isValue2 = false;
            
            int signIndex = calc.IndexOf(sign);
            int i = 1;
            do
            {
                if (signIndex-i<0 || (!Char.IsNumber(calc[signIndex-i]) && calc[signIndex-i]!='.'))
                {
                    isValue1 = true;
                }
                else if (Char.IsNumber(calc[signIndex-i]) || calc[signIndex-i]=='.')
                {
                    value1 = value1.Insert(0, Char.ToString(calc[signIndex - i]));
                    i++;
                }
            } while (!isValue1);

            i = 1;

            do
            {
                if (signIndex+i==calc.Length || (!Char.IsNumber(calc[signIndex+i]) && calc[signIndex+i]!='.'))
                {
                    isValue2 = true; 
                }
                else if (Char.IsNumber(calc[signIndex+i]) || calc[signIndex+i]=='.')
                {
                    value2 += calc[signIndex + i];
                    i++;
                }
            } while (!isValue2);

            if (float.TryParse(value1, NumberStyles.Any, new CultureInfo("en-US"), out var _value1) && float.TryParse(value2, NumberStyles.Any, new CultureInfo("en-US"), out var _value2))
            {
                if (sign=="*")
                {
                    result = $"{_value1 * _value2}";
                    result = ChangePoint(result);
                    calc = calc.Replace(value1 + "*" + value2, result); 
                }
                else
                {
                    result = $"{_value1 / _value2}";
                    result = ChangePoint(result);
                    calc = calc.Replace(value1 + "/" + value2, result); 
                }
                return calc;
            }
            Debug.Log("Some problem with TryParse in DeletionOrMultiplication method");
            return calc;
        }
        
        private string ChangePoint(string value) //если после переводов в строке запятая, вместо точки (дробь)
        {
            if (value.Contains(","))
            {
                value = value.Replace(",", ".");
            }

            return value;
        }
}
