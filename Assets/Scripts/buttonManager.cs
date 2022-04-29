using UnityEngine;
using UnityEngine.SceneManagement;

// Скрипт для управления сценами с кнопок (назначать на пустышку)
public class buttonManager : MonoBehaviour
{
    // Метод перезапускающий сцену игры
    public void restart()
    {
        SceneManager.LoadScene(1);
    }

    // Метод, загружающий сцену с главным меню
    public void toMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    // Метод, вызывающийся при отрисовке каждого кадра
    private void Update()
    {
        // При нажатии клавиши Escape загружает главное меню и разблокирует курсор
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene(0);
        }
    }
}
