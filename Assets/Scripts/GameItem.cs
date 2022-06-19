using System;
using UnityEngine;

public class GameItem : MonoBehaviour // компонент который вешается на игровой объект который нужно найти
{
    public Sprite Sprite; // картинка объекта
    public string Name; // имя объекта
    private SpriteRenderer _spriteRenderer; // переменная, отвечающая за отрисовку объекта в игре
    public event Action<string> OnFind; // текстовой ивент OnFind

    private void Awake() // конструктор юнити
    {
        _spriteRenderer = GetComponent<SpriteRenderer>(); // получаем ссылку на компонент, который на объекте
        Name = _spriteRenderer.sprite.name; // присваиваем переменной Name в конструкторе её отрисовку, картинку и имя (Зачем переменной Name ссылка на картинку и на имя, если у нас есть переменная Sprite?)
        Sprite = _spriteRenderer.sprite; // присваиваем  переменной Sprite картинку
    }

    private void OnMouseUpAsButton() // метод, который реагирует на клик мышки на объект с коллайдером
    {
        Find(); // найден объект с коллайдером когда мы кликаем на объект
    }

    private void Find() // метод, когда объект найден, то есть когда мы кликнули на него и активировался Find() из метода OnMouseAsButton()
    {
        Debug.Log($"Find object {gameObject.name}"); // выводим в консоль инфу о объекте и его имени, а доллар для отображения имени предмета из юнити в консоль
        OnFind.Invoke(Name); // (я не понял что за Invoke) активируем событие OnFind из 9-ой строки и причем это происходит только когда произошел клик по объекту с коллайдером, то есть активайия Find()
    }
}