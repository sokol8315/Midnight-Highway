using UnityEngine;

public class FallingObject : MonoBehaviour
{
    public float speed = 5f;

    void Update()
    {
        // Беремо точний множник з GameManager
        float currentSpeed = speed * GameManager.instance.gameSpeedMultiplier;
        transform.Translate(Vector3.down * currentSpeed * Time.deltaTime);

        // Якщо яма пролетіла екран — даємо очки і знищуємо її
        if (transform.position.y < -6f) 
        {
            GameManager.instance.AddScore(10);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Якщо врізалися в гравця
        if (collision.CompareTag("Player"))
        {
            GameManager.instance.LoseLife();
            Destroy(gameObject); 
        }
    }
}