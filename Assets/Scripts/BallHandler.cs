using System.Collections;
using UnityEngine;

// Проверка наличия и добавление Rigidbody в случае отсутствия
[RequireComponent(typeof(Rigidbody))]

// Скритп отвечает за контроль шара (назначать на шар)
public class BallHandler : MonoBehaviour
{
    private Rigidbody ball; // Сам шар (его физический компонент)

    [SerializeField] private float acceleration; // Множитель силы тяги
    [SerializeField] private float jumpForce; // Сила импульса прыжка
    [SerializeField] private GroundCheck checkGround; // Объект со скриптом GroundCheck

    private bool isGrounded = false;    // Сигнал, обозначающий приземлился ли шар или нет

    // Метод, вызывающийся при отрисовке первого кадра
    void Start()
    {
        // Обозачение компонента Rigidbody и блокировка курсора в окне игры
        ball = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Метод, вызывющийся при отрисовке каждого кадра
    void Update()
    {
        // Считывание осей движения и клавиши прыжка
        var xInput = Input.GetAxis("Horizontal");
        var zInput = Input.GetAxis("Vertical");
        var jumpInput = Input.GetButtonDown("Jump");

        // Добавление силы тяги по направлению осей
        ball.AddTorque(new Vector3(zInput, 0, -xInput) * acceleration * Time.deltaTime, ForceMode.Acceleration);

        // При нажатии клавиши прыжка и скором приземлении (механика помощи) запустится корутина прыжка
        if (jumpInput && checkGround.almostGrounded)
            StartCoroutine(Jump());
    }

    // Корутина прыжка
    IEnumerator Jump()
    {
        yield return new WaitUntil(() => isGrounded); // Ждет, пока шар окончательно не приземлится (если не приземлен)
        ball.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse); // Импульс, направленный вверх
        checkGround.almostGrounded = false; // Отключение триггера проверки приземления до момента, пока шар не выйдет из этой зоны
    }

    // Если шар касается пола, то переключается значение isGrounded на истинное
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
            isGrounded = true;
    }

    // Когда шар прекращает касаться пола, то isGrounded переключается на ложь
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
            isGrounded = false;
    }

}
