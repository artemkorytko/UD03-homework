using System;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    private GameItem[] _gameItems;
    private int _itemsCount;

    public event Action OnCompleted;
    public event Action<string> OnItemListChanged;

    public void Initialize()
    {
        _gameItems = GetComponentsInChildren<GameItem>();

        for (int i = 0; i < _gameItems.Length; i++)
        {
            _gameItems[i].OnFind += OnFindItem;
        }

        _itemsCount = _gameItems.Length;
    }

    private void OnFindItem(string name)
    {
        _itemsCount--;

        if (_itemsCount > 0)
        {
            OnItemListChanged.Invoke(name);
        }
        else
        {
            OnCompleted.Invoke();
        }
    }

    public Dictionary<string, GameItemData> GetItemDictionary()
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