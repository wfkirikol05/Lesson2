using UnityEngine;

public class Bouncer : MonoBehaviour
{
    [Header("Bounce Settings")]
    public float bounceForce = 2f;
    public float cooldownTime = 0.5f; // Задержка между прыжками

    [Header("Effects")]
    public ParticleSystem bounceEffect;
    public AudioClip bounceSound;

    private bool canBounce = true;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (!canBounce) return;

        // Проверяем, что это игрок
        if (collision.gameObject.CompareTag("Player"))
        {
            BouncePlayer(collision.gameObject);
        }
    }

    void BouncePlayer(GameObject player)
    {
        // Применяем силу прыжка
        Rigidbody playerRb = player.GetComponent<Rigidbody>();
        if (playerRb != null)
        {
            // Сбрасываем текущую вертикальную скорость перед прыжком
            Vector3 velocity = playerRb.linearVelocity;
            velocity.y = 0;
            playerRb.linearVelocity = velocity;

            // Применяем силу прыжка
            playerRb.AddForce(Vector3.up * bounceForce, ForceMode.Impulse);

            Debug.Log("Player bounced with force: " + bounceForce);
        }

        // Проигрываем эффекты
        PlayBounceEffects();

        // Активируем кд
        StartCoroutine(BounceCooldown());
    }

    void PlayBounceEffects()
    {
        // Визуальный эффект
        if (bounceEffect != null)
        {
            Instantiate(bounceEffect, transform.position, Quaternion.identity);
        }

        // Звуковой эффект
        if (bounceSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(bounceSound);
        }
    }

    private System.Collections.IEnumerator BounceCooldown()
    {
        canBounce = false;
        yield return new WaitForSeconds(cooldownTime);
        canBounce = true;
    }
}