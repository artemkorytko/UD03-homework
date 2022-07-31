using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace CalculatorRPN
{
    public class CalculatorRPN
    {
        private Regex regex = new Regex(@"(?<!\d)-?\d*[.,]?\d+|[+-/*()]");
        private OperatorsContainer _container = new OperatorsContainer();
        
        public string Calculate(string input)
        {
            Stack<double> _reversePolishStack = new Stack<double>();
            input = ConvertToRPN(input);
            string[] subsInputRPN = input.Split(' ');
            
            foreach (var sub in subsInputRPN)
            {
                if (double.TryParse(sub, out double num))
                {
                    _reversePolishStack.Push(num);
                }
                else
                {
                    double op2;
                    switch(sub)
                    {
                        case "+":
                            _reversePolishStack.Push(_reversePolishStack.Pop() + _reversePolishStack.Pop());
                            break;
                        case "*":
                            _reversePolishStack.Push(_reversePolishStack.Pop() * _reversePolishStack.Pop());
                            break;
                        case "-":
                            op2 = _reversePolishStack.Pop();
                            _reversePolishStack.Push(_reversePolishStack.Pop() - op2);
                            break;
                        case "/":
                            op2 = _reversePolishStack.Pop();
                            if (op2 != 0.0)
                                _reversePolishStack.Push(_reversePolishStack.Pop() / op2);
                            else
                                Console.WriteLine("Ошибка. Деление на ноль");
                            break;
                    }
                }
            }

            return _reversePolishStack.Pop().ToString();
        } 
        
        private string ConvertToRPN(string input)
        {
            Stack<string> _reversePolishStack = new Stack<string>();
            string modified = "";

            input = input.Replace(" ", "");
            input = input.Replace(".", ",");
            string[] subsInput = regex.Matches(input).Cast<Match>().Select(m => m.Value).ToArray();

            foreach (var sub in subsInput)
            {
                if (double.TryParse(sub, out double num))
                {
                    modified += sub + " ";
                }

                if (sub == "+" || sub == "-" || sub == "*" || sub == "/")
                {
                    if (_reversePolishStack.Count == 0)
                    {
                        _reversePolishStack.Push(sub);
                        continue;
                    }

                    if (_container.FindOperator(_reversePolishStack.Peek()).Priority < _container.FindOperator(sub).Priority)
                    {
                        _reversePolishStack.Push(sub);
                        continue;
                    }

                    try
                    {
                        while (_container.FindOperator(_reversePolishStack.Peek()).Priority >= _container.FindOperator(sub).Priority)
                        {
                            modified += _reversePolishStack.Pop() + " ";
                        }
                    }
                    catch
                    {
                    }

                    if (_reversePolishStack.Count == 0)
                    {
                        _reversePolishStack.Push(sub);
                        continue;
                    }

                    if (_container.FindOperator(_reversePolishStack.Peek()).Priority < _container.FindOperator(sub).Priority)
                    {
                        _reversePolishStack.Push(sub);
                        continue;
                    }
                }
                if (sub == "(")
                {
                    _reversePolishStack.Push(sub);
                    continue;
                }

                if (sub == ")")
                {
                    while (_reversePolishStack.Peek()!="(")
                    {
                        modified += _reversePolishStack.Pop() + " ";
                    }

                    _reversePolishStack.Pop();
                }
            }
            while (_reversePolishStack.Count != 0)
            {
                modified += _reversePolishStack.Pop() + " ";
            }
            return modified;
        }
    }
}
