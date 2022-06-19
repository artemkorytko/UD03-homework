using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIItem : MonoBehaviour
{
    [SerializeField] private Image image; // добавили поле Image для спрайта
    [SerializeField] private TextMeshProUGUI countText; // добавили поле Count Text для отображения кол-ва объектов текстом

    private int _count; // переменная которая будет считать кол-во объектов

    public void SetSprite(Sprite sprite) // метод устанавливающий переменной sprite картинку
    {
        image.sprite = sprite;
    }

    public void SetCount(int count) // метод присваивающий тексту, который мы перетащили в поле Count Text, в редакторе значение _count и перевод его в текст
    {
        _count = count; // зачем нам присваивать _count = count? так как _count глобальная, а count локальная переменная?
        countText.text = _count.ToString();
    }

    public void Decrease() // метод уменьшающий значение _count, а в случае, если _count > 0 присвоение значение в текст, в случае если _count = 0 исчезает объект 
    {
        _count--;
        if (_count > 0)
        {
            countText.text = _count.ToString();
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}