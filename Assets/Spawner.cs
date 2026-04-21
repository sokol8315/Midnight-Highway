using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public float baseSpawnRate = 2f; // Початкова пауза між ямами
    private float timer = 0f;

    void Update()
    {
        // Рахуємо час до наступного спавну
        timer += Time.deltaTime;

        // Чим вища швидкість гри, тим менша пауза між ямами
        float currentSpawnRate = baseSpawnRate / GameManager.instance.gameSpeedMultiplier;

        if (timer >= currentSpawnRate)
        {
            Spawn();
            timer = 0f;
        }
    }

    void Spawn()
{
    // Створюємо масив із трьох можливих позицій (смуг)
    float[] lanes = { -2f, 0f, 2f };
    
    // Вибираємо випадкову смугу з масиву
    float selectedLane = lanes[Random.Range(0, lanes.Length)];
    
    // Спавнимо яму рівно в центрі обраної смуги
    Instantiate(obstaclePrefab, new Vector3(selectedLane, 6f, 0f), Quaternion.identity);
}
}