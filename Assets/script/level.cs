using System;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    private GameItem[] _gameItems;   // наши айтемы на сцене ( [] синтексис массива )
    private int _itemsCount;         // считает количество объектов

    public event Action OnCompleted;  // метод эвента, вызова экшена ( уровень пройден)
    public event Action<string> OnItemListChanged; // событие , ( убираем объект, реагируем на изменение)

    public void Initialize() // инициализирует лвл и ГМ
    {
        _gameItems = GetComponentsInChildren<GameItem>(); //находим компоненты

        for (int i = 0; i < _gameItems.Length; i++)  // создает циклы,перебирает элементы в масиве
        {
            _gameItems[i].OnFind += OnFindItem; // подписка на событие, найденый объект
        }

        _itemsCount = _gameItems.Length; // возвращает количество элементов в масиве
    }

    private void OnFindItem(string name)     // метод уменьшающий наше количество предметов 
    {
        _itemsCount--; // вычетание количество объектов

        if (_itemsCount > 0) // обновление листа , если объектов больше 0
        {
            OnItemListChanged.Invoke(name); // вычетаем объект , вызывает все методы на кого подписан
        }
        else                  // завершение игры 
        {
            OnCompleted.Invoke();
        }
    }

    public Dictionary<string, GameItemData> GetItemDictionary()  // создание массива у которого есть ключ и его значения 
    {
        Dictionary<string, GameItemData> itemsData = new Dictionary<string, GameItemData>();  // ?

        for (int i = 0; i < _gameItems.Length; i++) // длина масива ?
        {
            string key = _gameItems[i].Name; // идя ключа
            if (itemsData.ContainsKey(key)) // проверка на ключ
            {
                itemsData[key].IncreaseAmount(); //  увелчиваем наше значение
            }
            else // если нету
            {
                itemsData.Add(key, new GameItemData(_gameItems[i].Sprite)); // добавляем ключ
            }
        }

        return itemsData;
    }

}