using UnityEngine;
using UnityEngine.UI;

// Скрипт, который ведет подсчет всех очков
public class scoreScript : MonoBehaviour
{
    [SerializeField] private Text timeCounter;  // Счетчик времени в игре
    [SerializeField] private Text finalTime;    // Итоговый результат
    [SerializeField] private Text bestTime;     // Лучший результат

    private int timeScore = 0; // Текущее время
    private int bestScore; // Лучшее время

    private bool stopped = false; // Параметр включенности счетчиков

    // Метод, вызываемый для остановки счетчиков и сохранения их результатов
    public void stopTime()
    {
        // Переключение параметра включенности счетчиков, поиск и отключение объекта с тегом Timer
        stopped = true;
        GameObject.FindGameObjectWithTag("Timer").SetActive(false);

        // Сохранение итоговых результатов
        PlayerPrefs.SetInt("lastPlayTime", timeScore);
        if (timeScore < bestScore || !PlayerPrefs.HasKey("bestPlayTime"))
        {
            bestTime.text = $"Best time: {timeScore}";
            PlayerPrefs.SetInt("bestPlayTime", timeScore);
        }
    }

    // Метод, вызываемый во время отрисовки первого кадра
    private void Start()
    {
        // Проверка наличия и загрузка лучшего результата
        if (PlayerPrefs.HasKey("bestPlayTime"))
            bestScore = PlayerPrefs.GetInt("bestPlayTime");

        // Обновление счетчиков
        timeCounter.text = $"Time: {timeScore}";
        bestTime.text = $"Best time: {bestScore}";
        finalTime.text = $"Your time: {timeScore}";
    }

    // Метод, вызываемый во время отрисовки каждого кадра
    private void Update()
    {
        if (!stopped)
        {
            // Обновляет счетчики времени, пока игра не остановлена
            timeScore = (int)Time.timeSinceLevelLoad;
            timeCounter.text = $"Time: {timeScore}";
            finalTime.text = $"Your time: {timeScore}";
        }
    }
}