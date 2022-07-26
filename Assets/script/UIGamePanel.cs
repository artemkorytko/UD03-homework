using System.Collections.Generic;
using UnityEngine;

public class UiGamePanel : MonoBehaviour
{
    [SerializeField] private RectTransform content; // атрибуты материалов 
    [SerializeField] private UIItem prefab; // ссылка на префаб(ресурс)
    Dictionary<string, UIItem> items = new Dictionary<string, UIItem>(); // ?

    public void Initialize(Level level)  // публичный метод со своим названием,передаем туда наш лвл.
    {
        foreach (var key in items.Keys) // логика удаление старых объектов
        {
            Destroy(items[key].gameObject); // удаляет все  гейм обьекты
        }
        items.Clear(); // чистит всю дату 

        GenerateList(level.GetItemDictionary());  // генерируем и получаем информацию об уникальных объектах на сцене

        level.OnItemListChanged += OnItemListChanged; // подписываемся на уровень(что на нем происходит)
    }

    private void OnItemListChanged(string name) // создаем метод, имя объекта
    {
        if (items.ContainsKey(name)) // обращение к объекту в листе по имени
        {
            items[name].Decrease(); // делаем дикрис объекта 
        }
    }

    private void GenerateList(Dictionary<string, GameItemData> itemsData)  // список наших объектов
    {
        foreach (var key in itemsData.Keys)  // обращение к ключу( дикшенари)
        {
            UIItem item = Instantiate(prefab, content);  // генерируем лист, создаем иконки
            item.SetCount(itemsData[key].Amount); // присваеваем значения
            items.Add(key, item); // добавляем  ключи 
        }
    }
}