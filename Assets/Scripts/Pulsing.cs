using UnityEngine;

// Скрит пульсации свечения материала шара (назначать на шар)
public class Pulsing : MonoBehaviour
{
    [SerializeField] private float bright = 2.0f;   // Максимальная яркость свечения
    [SerializeField] private float speed = 2.0f;    // Множитель частоты колебаний (мигания) - так же влияет на яркость

    private Material _material;     // Материал шара
    private float intensity = 0;    // Интенсивность свечения (начинает от нуля)

    // Метод, вызывающийся при отрисовке первого кадра
    private void Start()
    {
        // Сохранение материала шара
        _material = GetComponent<Renderer>().material;
    }

    // Метод, вызывающийся фиксированное количество раз в секунду (по дефолту 50 раз)
    private void FixedUpdate()
    {
        // Изменение интенсиности свеченния зацикливается по принципу пинг понга (туда-обратно)
        intensity = Mathf.PingPong(Time.time, bright)*speed;
        _material.SetColor("_EmissionColor", new Color(0.0f, 0.7f, 1.0f, 1.0f)*intensity);
    }
}
