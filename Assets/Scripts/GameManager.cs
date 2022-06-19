using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Level[] allLevels; // создаем поле в редакторе заполняемое уровнями

    [SerializeField] private GameObject mainPanel; // создаем поле в редакторе для стартовой панели 
    [SerializeField] private UiGamePanel gamePanel; // создаем поле в редакторе для игрового интерфейса 
    [SerializeField] private GameObject winPanel; // создаем поле в редакторе для панели победы

    private int _currentLevelIndex;
    private Level _currentLevel;

    private void Awake() // системный метод Awake, который загружает дату, создает уровень и инициализирует объекты
    {
        LoadData();
        CreateLevel();
        Initialize();
    }

    private void Initialize() // метод инициализации
    {
        _currentLevel.Initialize(); // инициализация текущего левела с объектами

        mainPanel.SetActive(true); // активация начальной панели
        gamePanel.gameObject.SetActive(false);
        winPanel.SetActive(false);
    }

    private void CreateLevel() // метод создания левела
    {
        _currentLevel = InstantiateLevel(_currentLevelIndex); // текущий уровень
    }

    private Level InstantiateLevel(int index) // Метод который зацикливает уровни при прохождение делением с остатком
    {
        if (_currentLevel) 
        {
            Destroy(_currentLevel.gameObject);
        }

        if (index >= allLevels.Length)
        {
            index %= allLevels.Length;
        }

        return Instantiate(allLevels[index]);
    }

    private void LoadData() // метод который загружает номер уровня
    {
        _currentLevelIndex = PlayerPrefs.GetInt("level_index", 0); // номер уровня присваивается через GetInt и меняется с 0 до n-ого уровня
    }

    private void SaveData() // устанавливает значение _currentLevelIndex и сохраняет уровень
    {
        PlayerPrefs.SetInt("level_index", _currentLevelIndex);
    }

    public void StartGame() // активируется уровень после нажатия на старт
    {
        mainPanel.SetActive(false); // отключаем старт панель
        winPanel.SetActive(false); // отключаем вин панель

        gamePanel.Initialize(_currentLevel); // инициализируем текущий левел
        gamePanel.gameObject.SetActive(true); // включаем объеты

        _currentLevel.OnCompleted += StopGame; // подписываемся на событие при заверщении
    }

    private void StopGame() // метод завершения игры
    {
        _currentLevel.OnCompleted -= StopGame; // при завершении отписывемся
        mainPanel.SetActive(false);
        gamePanel.gameObject.SetActive(false);
        winPanel.SetActive(true); // включаем победную панель

        _currentLevelIndex++; // добавляем 1 к значению индекса левела
        SaveData(); // сохраняем левел
    }

    public void StartNewGame() // начинаем новый уровень
    {
        CreateLevel();
        _currentLevel.Initialize();
        StartGame();
    }
}