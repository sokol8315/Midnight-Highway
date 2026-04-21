using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject obstaclePrefab; // Сюди ми покладемо наш шаблон ями
    public float spawnInterval = 1.5f; // Як часто з'являтимуться ями

    void Start()
    {
        // Командуємо: "Запусти функцію SpawnObstacle через 1 сек, і повторюй кожні 1.5 сек"
        InvokeRepeating("SpawnObstacle", 1f, spawnInterval);
    }

    void SpawnObstacle()
    {
        // Вибираємо випадкову смугу (0, 1 або 2)
        int randomLane = Random.Range(0, 3);
        
        // Вираховуємо позицію (ліва = -2, центр = 0, права = 2)
        float xPos = (randomLane - 1) * 2.0f; 
        
        // Створюємо нову яму на координаті (xPos, 6)
        Instantiate(obstaclePrefab, new Vector3(xPos, 6f, 0), Quaternion.identity);
        GameManager.instance.AddScore(10); // Даємо 10 очок за кожну яму, що з'явилася
    }
}