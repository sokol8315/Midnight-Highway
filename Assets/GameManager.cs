using UnityEngine;
using TMPro; // Підключаємо бібліотеку для тексту

public class GameManager : MonoBehaviour
{
    public static GameManager instance; // Робимо його доступним для всіх скриптів

    public int score = 0;
    public int lives = 3; // Обмеження з пункту 4 твоєї лаби!
    
    public TextMeshProUGUI scoreText; // Посилання на наш текст на екрані

    void Awake()
    {
        instance = this; // Зберігаємо себе в пам'ять при старті
    }

    // Функція, яка додає очки
    public void AddScore(int points)
    {
        score += points;
        UpdateUI();
    }

    // Функція, яка віднімає життя (її викличе яма)
    public void LoseLife()
    {
        lives--;
        UpdateUI();
        
        if (lives <= 0)
        {
            Debug.Log("💀 ГРА ЗАКІНЧЕНА!");
            Time.timeScale = 0; // Зупиняємо час у грі
        }
    }

    // Оновлюємо текст на екрані
    void UpdateUI()
    {
        scoreText.text = "Очки: " + score + "\nЖиття: " + lives;
    }
}