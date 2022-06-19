using UnityEngine;

public class GameItemData // класс, ктороый хранит в себе информацию о объекте
{
    public Sprite Sprite; // присваивает картинку объекту
    public int Amount; // задаем переменную Amount

    public GameItemData(Sprite sprite) // конструктор ???
    {
        Sprite = sprite; // переменная Sprite получает картинку
        Amount = 1; // присваиваем переменной значение
    }

    public void IncreaseAmount() // метод, который увеличивает значение переменной
    {
        Amount++; // +1 к переменной
    }

    public bool DecreaseAmount() // метод, который уменьшает значение переменной, если переменная не равна нулю или меньше
    {
        Amount--; // -1 к переменной
        if (Amount <= 0) // if и условие
        {
            return false; // если соблюдается условие, то уменьшается???
        }

        return true; // если не соблюдается условие, то не уменьшается??
    }
}