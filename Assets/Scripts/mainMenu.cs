using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// Скрипт управления главным меню (назначать на пустой объект)
public class mainMenu : MonoBehaviour
{
    [SerializeField] private Text bestTimeText; // Текст лучшего времени игры на панели результатов
    [SerializeField] private Text lastTimeText; // Текст времени последней игры на панели результатовы

    // Метод, запускающийся при отрисовке первого кадра
    private void Start()
    {
        // Проверка и выгрузка (при наличии) даты последней игры
        if (PlayerPrefs.HasKey("bestPlayTime"))
        bestTimeText.text = $"Best Time:\n{PlayerPrefs.GetInt("bestPlayTime")}";

        // Проверка и выгрузка (при наличии) результата последней игры
        if (PlayerPrefs.HasKey("lastPlayTime"))
        lastTimeText.text = $"Last Time:\n{PlayerPrefs.GetInt("lastPlayTime")}";
    }

    // Метод, запускаемый при нажатии на кнопку "Играть". Блокирует курсор, загружает игровое поле.
    public void playButtonClick()
    {
        SceneManager.LoadScene(1);
        Cursor.lockState = CursorLockMode.Locked;
    }

}
