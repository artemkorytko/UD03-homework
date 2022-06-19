using System.Collections.Generic;
using UnityEngine;

public class UiGamePanel : MonoBehaviour
{
    [SerializeField] private RectTransform content; // создания поля для recttransofrm
    [SerializeField] private UIItem prefab; // создание поля для префабов содержащих UI
    Dictionary<string, UIItem> items = new Dictionary<string, UIItem>(); // Список предметов UI

    public void Initialize(Level level) // инициализация левела
    {
        foreach (var key in items.Keys) // для каждого key в items.Keys
        {
            Destroy(items[key].gameObject); // уничтожаем items по значению key как геймобджекты
        }
        items.Clear(); // не понял

        GenerateList(level.GetItemDictionary()); // генерируем левел?

        level.OnItemListChanged += OnItemListChanged; // подписываемся на события изменения листа
    }

    private void OnItemListChanged(string name) // метод изменения листа
    {
        if (items.ContainsKey(name)) // если в items есть ключ name то, значение items уменьшается
        {
            items[name].Decrease(); // декрементация items
        }
    }

    private void GenerateList(Dictionary<string, GameItemData> itemsData) // метод генерации листа
    {
        foreach (var key in itemsData.Keys) // плохо понимаю все ниже написанное
        {
            UIItem item = Instantiate(prefab, content);
            item.SetSprite(itemsData[key].Sprite);
            item.SetCount(itemsData[key].Amount);
            items.Add(key, item);
        }
    }
}