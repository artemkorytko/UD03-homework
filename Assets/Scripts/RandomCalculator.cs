using UnityEngine;

public class RandomCalculator : MonoBehaviour
{
    private int _value1;
    private int _value2;
    private int _value3;

    private void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            _value1 = Random.Range(0, 15);
            _value2 = Random.Range(0, 15);
            _value3 = Random.Range(1, 8);

            switch (_value3)
            {
                case 0:
                    Debug.Log($"{_value1} + {_value2} = {Addition(_value1, _value2)}");
                    break;

                case 1:
                    Debug.Log($"{_value1} - {_value2} = {Subtraction(_value1, _value2)}");
                    break;

                case 2:
                    Debug.Log($"{_value1} * {_value2} = {Multiply(_value1, _value2)}");
                    break;

                case 3:
                    Debug.Log($"{_value1} / {_value2} = {Division(_value1, _value2)}");
                    break;

                case 4:
                    Debug.Log($"{_value1} ^ {_value2} = {PowerOf(_value1, _value2)}");
                    break;

                case 5:
                    Debug.Log($"{_value1}, {_value2} Log = {Log(_value1, _value2)}");
                    break;

                case 6:
                    Debug.Log($"{_value1}, {_value2} Max = {Max(_value1, _value2)}");
                    break;

                case 7:
                    Debug.Log($"{_value1}, {_value2} Min = {Min(_value1, _value2)}");
                    break;
            }
        }
    }

    private int Addition(int Summand,int Addend)
    {
        return Summand + Addend;
    }

    private int Subtraction(int Minuend, int Subtrahend)
    {
        return Minuend - Subtrahend;
    }

    private int Multiply(int Multiplicanda, int Multiplier)
    {
        return Multiplicanda * Multiplier;
    }

    private float Division(float Dividend, float Divisor)
    {
        return Divisor == 0 ? 0 : Dividend / Divisor;
    }

    private float PowerOf(int FirstValue, int SecondValue)
    {
        return Mathf.Pow(FirstValue, SecondValue);
    } 

    private float Log(int Value, int BaseValue)
    {
        return Mathf.Log(Value, BaseValue);
    }

    private int Max(int FirstValue, int SecondValue)
    {
        return FirstValue > SecondValue ? FirstValue : SecondValue;
    } 
    
    private int Min(int FirstValue, int SecondValue)
    {
        return FirstValue < SecondValue ? FirstValue : SecondValue;
    }

}
