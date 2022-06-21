using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Level[] allLevels;   // массив всех уровней

    [SerializeField] private GameObject mainPanel; //  3 ссылки на наш UI панели
    [SerializeField] private UiGamePanel gamePanel;
    [SerializeField] private GameObject winPanel;

    private int _currentLevelIndex;  // глобальные переменные
    private Level _currentLevel;

    private void Awake()    // тоже самое что и старт, но вызывается раньше, нужны для того что бы быть уверенным что у всех прошла инициализация переменных
    {
        LoadData();  // создаем дату
        CreateLevel();  // загружаем уровень
        Initialize();   // вызываем инициализацию
    }

    private void Initialize()
    {
        mainPanel.SetActive(true); // включить , выключить панели 
        gamePanel.gameObject.SetActive(false); // включает объекты
        winPanel.SetActive(false);  // выключает winPanel
    }

    private void CreateLevel() // метод отвечающий за загрузку уровня
    {
        _currentLevel = InstantiateLevel(_currentLevelIndex); // создаёт и присваивает ссылку
        _currentLevel.name = Random.Range(0, 100).ToString(); // возвращает значение в диапозоне, тостринг переводит из цифр в буквы
        _currentLevel.Initialize();                    // инициализируем уровни
    }

    private Level InstantiateLevel(int index)  // проверка при создании уровня
    {
        if (_currentLevel)
        {
            Destroy(_currentLevel.gameObject);  // удаляет игровой объект текущего уровня
        }

        if (index >= allLevels.Length)  // проверка находится ли наш объект в массиве уровня
        {
            index %= allLevels.Length; // остаток от деления
        }

        return Instantiate(allLevels[index]);   // создает и возвращает уровень
    }

    private void LoadData()   // система сохранения уровня
    {
        _currentLevelIndex = PlayerPrefs.GetInt("level_index", 0); // получает сохранненую информацию,установка даты, единичные уровни
    }

    private void SaveData() // сохраняет дату, уровень
    {
        PlayerPrefs.SetInt("level_index", _currentLevelIndex); // сохранение даты,информации, из нашего уровня
    }

    public void StartGame() // запуск игры
    {
        mainPanel.SetActive(false); // выключаем mainPanel
        winPanel.SetActive(false);  // выключаем winPanel

        gamePanel.Initialize(_currentLevel); // передаем сида наш уровень
        gamePanel.gameObject.SetActive(true); // инициализируем панель

        _currentLevel.OnCompleted += StopGame; // подписка на остановку игры
    }

    private void StopGame()  // запуск игры
    {
        _currentLevel.OnCompleted -= StopGame; // отписыемся
        mainPanel.SetActive(false);   // выключаем mainPanel
        gamePanel.gameObject.SetActive(false); // выключение объектов
        winPanel.SetActive(true); // включаем winPanel

        _currentLevelIndex++; // прибовляем себе один ещё один уровень
        SaveData(); // сохраняем дату 
    }

    public void StartNewGame()  // старт новой игры
    {
        CreateLevel(); // создать уровень
        StartGame(); // старт игры
    }
} 