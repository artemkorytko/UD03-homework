using System;
using UnityEngine;

public class GameItem : MonoBehaviour
{
    public Sprite Sprite; // Хранит картинку
    public string Name;  // наше Имя
    private SpriteRenderer _spriteRenderer;   // компанент нашей визуализация  
    public event Action<string> OnFind;  // событие , вызываеться когда мы себя нашли

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>(); // получаем, находим, компонет
        Name = _spriteRenderer.sprite.name; // получили наше имя
        Sprite = _spriteRenderer.sprite; // получили нашу картинку
    }

    private void OnMouseUpAsButton() // метод, объект, на нажатии кнопки
    {
        Find();                            // метод , поиска когда мы себя нашли
    }

    private void Find() // метод  объекта
    {
        Debug.Log($"Find object {gameObject.name}"); // объект найден
        OnFind.Invoke(Name); // вызов события, передает имя объекта
    }
}
