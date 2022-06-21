using UnityEngine;

public class GameItemData
{
    public Sprite Sprite; // информация о картнках
    public int Amount; // информация о количество объектов

    public GameItemData(Sprite sprite)  // присылаем наши картинки
    {
        Sprite = sprite; // картинка 
        Amount = 1; // количество один
    }

    public void IncreaseAmount() // дабавление объектов
    {
        Amount++; // увеличивает значение к текущему на один
    }

    public bool DecreaseAmount() // уменьшаем значение (возвращаем)
    {
        Amount--; // уменьшить на одно значение
        if (Amount <= 0) // если меньше либо = 0
        {
            return false; // не возвращаем
        }

        return true; // возвращаем 
    }
}