using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float laneDistance = 2.0f; // Відстань між смугами
    private int currentLane = 1; // 0 - ліва смуга, 1 - центр, 2 - права смуга

    void Update()
    {
        // Якщо натиснули вліво (A або Стрілка вліво)
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (currentLane > 0) currentLane--; // Зміщуємось вліво, якщо є куди
        }
        
        // Якщо натиснули вправо (D або Стрілка вправо)
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (currentLane < 2) currentLane++; // Зміщуємось вправо, якщо є куди
        }

        // Розраховуємо цільову позицію по осі X
        float targetX = (currentLane - 1) * laneDistance;
        Vector3 targetPosition = new Vector3(targetX, transform.position.y, 0);
        
        // Плавно переміщуємо машину на нову смугу
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * 15f);
    }
}