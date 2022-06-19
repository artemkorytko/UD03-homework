using System;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour // наш уровень
{
    private GameItem[] _gameItems; // массив GameItem с нашими переменными _gameItems
    private int _itemsCount; // числовая переменная отвечающая за подсчет кол-ва объетов в массиве

    public event Action OnCompleted; // инициализация  ивента OnCompleted
    public event Action<string> OnItemListChanged; // инициализация  ивента тектового типа OnItemListChanged

    public void Initialize() // метод инициализации объектов
    {
        _gameItems = GetComponentsInChildren<GameItem>(); // присвооение переменными _gameItems значение чайлдов

        for (int i = 0; i < _gameItems.Length; i++) // то кол-во чайлдов(при помощи Length), что сущевствует в массиве, подписывается на ивент OnFindItem
        {
            _gameItems[i].OnFind += OnFindItem; // каждый чайлд с ((OnFind??)) подписывается на метод OnFindItem
        }

        _itemsCount = _gameItems.Length; // кол-во предметов равно кол-во чайлдов
    }

    private void OnFindItem(string name) // метод который уменьшает значение _itemsCount 
    {
        _itemsCount--;

        if (_itemsCount > 0) // если больше 0 , то вызывает меняет Лист
        {
            OnItemListChanged.Invoke(name);
        }
        else
        {
            OnCompleted.Invoke(); // если не больше 0, то вызвает OnCompleted
        }
    }

    public Dictionary<string, GameItemData> GetItemDictionary() // создаем системный Dictionary 
    {
        Dictionary<string, GameItemData> itemsData = new Dictionary<string, GameItemData>();

        for (int i = 0; i < _gameItems.Length; i++)
        {
            string key = _gameItems[i].Name;
            if (itemsData.ContainsKey(key))
            {
                itemsData[key].IncreaseAmount();
            }
            else
            {
                itemsData.Add(key, new GameItemData(_gameItems[i].Sprite));
            }
        }

        return itemsData;
    }

}