using UnityEngine;

public class Collectible : MonoBehaviour
{
    public int coinValue = 1; // Количество очков за монету
    public AudioClip collectSound; // Звук сбора (опционально)
    public GameObject collectEffect; // Эффект сбора (опционально)

    void OnTriggerEnter(Collider other)
    {
        // Проверяем, что это игрок
        if (other.TryGetComponent<PlayerController>(out var player))
        {
            // Вызываем метод сбора монеты у игрока
            player.CollectCoin(coinValue);

            // Воспроизводим звук сбора
            if (collectSound != null)
            {
                AudioSource.PlayClipAtPoint(collectSound, transform.position);
            }

            // Создаем эффект сбора
            if (collectEffect != null)
            {
                Instantiate(collectEffect, transform.position, transform.rotation);
            }

            // Уничтожаем текущий объект
            Destroy(gameObject);
        }
    }
}
