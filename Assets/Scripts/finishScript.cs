using UnityEngine;
using UnityEngine.UI;

// Скрипт, завершающий игру (назначать на финишный триггер)
public class finishScript : MonoBehaviour
{
    [SerializeField] private GameObject finishScreen;   // Экран победы
    [SerializeField] private scoreScript score;     // Объект с компонентом scoreScript

    // Метод, вызываемый при срабатывании триггера геймобджекта
    private void OnTriggerEnter(Collider other)
    {
        // Если триггер сработал на игрока (шар),то:
        if (other.CompareTag("Player"))
        {
            Destroy(other.gameObject);  // Удаляем шар
            score.stopTime();   // Вызываем метод остановки счетчика и сохранения результатов
            Cursor.lockState = CursorLockMode.None; // Разблокируем курсор
            finishScreen.SetActive(true);   // Включаем финишный экран
        }
    }
}
