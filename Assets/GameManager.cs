using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
    public int score = 0;
    public int lives = 3;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI livesText;

    public float gameSpeedMultiplier = 1f; 
    public float speedIncreaseRate = 0.02f;

    void Awake() 
    { 
        instance = this; 
    }

    void Start()
    {
        UpdateUI();
    }

    void Update()
    {
        // Поступово прискорюємо гру
        gameSpeedMultiplier += speedIncreaseRate * Time.deltaTime;
    }

    public void AddScore(int amount)
    {
        score += amount;
        UpdateUI();
    }

    public void LoseLife()
    {
        lives--;
        UpdateUI();

        if (lives <= 0) 
        {
            lives = 0;
            Debug.Log("ГРА ЗАКІНЧЕНА!");
            Time.timeScale = 0f;
        }
    }

    void UpdateUI()
    {
        if (scoreText != null) scoreText.text = "Очки: " + score;
        if (livesText != null) livesText.text = "Життя: " + lives;
    }
}