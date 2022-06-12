using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomCalculations : MonoBehaviour
{

    private int _randomCalculationNumber;
    private int _randomNumber1;
    private int _randomNumber2;
    private int _resultAddition;

    void Start()
    {
        for (int i = 0; i <= 5; i++)
        {
            _randomCalculationNumber = Random.Range(0, 5);
            _randomNumber1 = Random.Range(0, 15);
            _randomNumber2 = Random.Range(0, 15);

            _randomCalculation(_randomCalculationNumber, _randomNumber1, _randomNumber2);
        }

    }

    private void _randomCalculation(int randomNumber, int number1, int number2)
    {
        print("Число №1 = " + number1 + " Число №2 = " + number2 + " Рандомное число = " + randomNumber);
        switch (randomNumber)
        {
            case 0:
                Debug.Log("Сумма:");
                Debug.Log(_addition());
                break;
            case 1:
                Debug.Log("Вычитание:");
                Debug.Log(_substraction());
                break;
            case 2:
                Debug.Log("Умножение:");
                Debug.Log(_multiplication());
                break;
            case 3:
                Debug.Log("Деление:");
                Debug.Log(_division());
                break;
            case 4:
                Debug.Log("Степень:");
                Debug.Log(_degree());
                break;
            case 5:
                Debug.Log("Факториал:");
                Debug.Log(_factorial());
                break;
        }
    }

    private int _addition()
    {
        return _randomNumber1 + _randomNumber2;
    }

    private int _substraction()
    {
        return _randomNumber1 - _randomNumber2;
    }

    private int _multiplication()
    {
        return _randomNumber1 * _randomNumber2;
    }

    private double _division()
    {
        if (_randomNumber2 == 0)
        {
            print("Делить на ноль нельзя");
            return 0;
        }
        return (double)_randomNumber1 / _randomNumber2;

    }

    private int _degree()
    {
        if (_randomNumber1 == 0 || _randomNumber2 == 0)
        {
            return 1;
        }
        return (int)Mathf.Pow(_randomNumber1, _randomNumber2);
    }

    private int _factorial()
    {
        int result = 1;

        for (int i = 1; i <= _randomNumber1; i++) result *= i;

        return result;
    }
}
