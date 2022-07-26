using TMPro;  // плагин отвечающий за работу с текстовыми элементами
using UnityEngine;
using UnityEngine.UI; // подключаем неймспейс для использование SerializeField

public class UIItem : MonoBehaviour
{
    [SerializeField] private Image image; // передача ссылок на наш image
    [SerializeField] private TextMeshProUGUI countText; // передача ссылок на текст

    private int _count; // переменная отвечающая за количество объектов(значения)

    public void SetSprite(Sprite sprite) // установка спрайта(картинки)
    {
        image.sprite = sprite; // присвоение 
    }

    public void SetCount(int count) // значение количества объектов
    {
        _count = count; // значение ?
        countText.text = _count.ToString(); // перевод цифрового значение в строчное значение(из цифры в букву) 
    }

    public void Decrease() // метод дикриса
    {
        _count--; // уменьшаем количество значений
        if (_count > 0) // больше чем ноль 
        {
            countText.text = _count.ToString(); // присваеваем значение
        }
        else
        {
            gameObject.SetActive(false); // выключаем объект в UI item (не будь активным)
        }
    }
}