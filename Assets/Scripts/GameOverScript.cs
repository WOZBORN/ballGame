using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Скрипт, отвечающий за поражение (назначать на окно Game Over)
public class GameOverScript : MonoBehaviour
{
    [SerializeField] private GameObject ball; // Игровой шар
    [SerializeField] private GameObject gameOverScreen; // Окно GameOver
    [SerializeField] private float minYPosition = -15.0f; // Y координата, ниже которой опускаться нельзя (смерть)


    // Метод поражения, вызываемый при падении шарика
    public void gameOver()
    {
        // Уничтожение шара, включение окна GameOver, разблокировка курсора, отключение счетчика
        Destroy(ball);
        gameOverScreen.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        GameObject.FindGameObjectWithTag("Timer").SetActive(false);
    }

    private void Update()
    {
        // Если шарик упадет с платформы (окажется ниже minYPosition)
        if (ball)
        if (ball.transform.position.y < minYPosition)
            gameOver();
    }
}
