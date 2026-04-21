using UnityEngine;

public class FallingObject : MonoBehaviour
{
    public float speed = 5f; // Швидкість падіння ями

    void Update()
    {
        // Рухаємо яму вниз кожного кадру
        transform.Translate(Vector3.down * speed * Time.deltaTime);
        
        // Якщо яма пролетіла повз екран (дуже низько), знищуємо її, щоб не засмічувати пам'ять
        if (transform.position.y < -7f)
        {
            Destroy(gameObject);
        }
    }

    // Ця функція спрацьовує, коли яма торкається машини
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Перевіряємо, чи врізалися ми саме в гравця (синій квадрат)
        if (collision.CompareTag("Player"))
        {
            Debug.Log("💥 БАМ! Ти врізався в яму!");
            
            // Звертаємося до нашого Менеджера і кажемо відняти життя
            GameManager.instance.LoseLife();
            
            // Знищуємо яму
            Destroy(gameObject); 
        }
    }
}