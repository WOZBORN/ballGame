using UnityEngine;

// Скрипт проверки приближающегося касания пола шаром (назначать пустышку с триггером, созданную в шаре)
public class GroundCheck : MonoBehaviour
{
    public bool almostGrounded = false; // Параметр, обозначающий наличие приближающегося прикосновения

    // При срабатывании триггера на пол, переключает значение almostGrounded на истинное
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Floor"))
        {
            almostGrounded = true;
        }
    }

    // При выхода триггера из пола, переключает значение almostGrounded на ложное (на самом деле оно уже переключено из корутины, но этот скрипт можно использовать и отдельно)
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Floor"))
        {
            almostGrounded = false;
        }
    }
}
