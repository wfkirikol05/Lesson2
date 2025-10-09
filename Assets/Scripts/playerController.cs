using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 5f;
    public float jumpForce = 300f;

    [Header("Health System")]
    public int maxHealth = 3;
    public int currentHealth;
    public TextMeshProUGUI healthText; // Текст для сердечек

    [Header("Coin System")]
    public int collectedCoins = 0;
    public TextMeshProUGUI coinsText;

    // Ссылка на точку респавна (можно задать в инспекторе)
    public Vector3 respawnPoint = new Vector3(0, 2, 0);

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthUI();
        UpdateCoinsUI();

        // Устанавливаем начальную точку респавна
        respawnPoint = transform.position;
    }

    void Update()
    {
        // Движение вперед-назад (A/D keys)
        float horizontal = Input.GetAxis("Horizontal");
        transform.Translate(horizontal * moveSpeed * Time.deltaTime, 0, 0);

        // Движение влево-вправо (W/S keys)
        float vertical = Input.GetAxis("Vertical");
        transform.Translate(0, 0, vertical * moveSpeed * Time.deltaTime);

        // Прыжок
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce);
        }
    }

    // Метод для сбора монет
    public void CollectCoin(int value = 1)
    {
        collectedCoins += value;
        UpdateCoinsUI();
        Debug.Log($"Монета собрана! Всего: {collectedCoins}");
    }

    // Метод для получения урона (будет вызываться из DeathZone)
    public void TakeDamage(int damage = 1)
    {
        currentHealth -= damage;
        UpdateHealthUI();

        Debug.Log($"Получен урон! Осталось жизней: {currentHealth}");

        // Проверяем смерть игрока
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    // Смерть игрока
    private void Die()
    {
        Debug.Log("Игрок умер! Game Over");
        // Здесь можно добавить:
        // - Экран Game Over
        // - Перезагрузку сцены
        // - Рестарт уровня

        // Пример перезагрузки сцены (раскомментируйте если нужно):
        // UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }

    // Обновление UI здоровья
    private void UpdateHealthUI()
    {
        if (healthText != null)
        {
            string hearts = "";
            for (int i = 0; i < maxHealth; i++)
            {
                if (i < currentHealth)
                    hearts += "♥ "; // Полное сердечко
                else
                    hearts += "<alpha=#44>♥ "; // Полупрозрачное сердечко
            }
            healthText.text = hearts;
        }
    }

    // Обновление UI счетчика монет
    private void UpdateCoinsUI()
    {
        if (coinsText != null)
        {
            coinsText.text = $"Монеты: {collectedCoins}";
        }
    }

    // Респавн игрока в указанной позиции
    public void Respawn(Vector3 position)
    {
        transform.position = position;

        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }

    // Автоматическое определение столкновения с монетой
    void OnTriggerEnter(Collider other)
    {
        // Если столкнулись с монетой
        Collectible collectible = other.GetComponent<Collectible>();
        if (collectible != null)
        {
            CollectCoin(1);
        }
    }
}