using UnityEngine;

public class DeathZone : MonoBehaviour
{
    public Vector3 respawnPosition = new Vector3(0, 2, 0);
    public int damage = 1; // Количество урона

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Object in death zone: " + other.name);

        PlayerController player = null;

        // Ищем компонент PlayerController разными способами
        if (other.CompareTag("Player"))
        {
            player = other.GetComponent<PlayerController>();
        }
        else if (other.transform.parent != null && other.transform.parent.CompareTag("Player"))
        {
            player = other.transform.parent.GetComponent<PlayerController>();
        }
        else
        {
            player = other.GetComponentInParent<PlayerController>();
        }

        // Если нашли игрока, наносим урон и респавним
        if (player != null)
        {
            player.TakeDamage(damage);
            RespawnPlayer(player.gameObject);
        }
    }

    private void RespawnPlayer(GameObject player)
    {
        Debug.Log("Respawning player: " + player.name);
        player.transform.position = respawnPosition;

        Rigidbody rb = player.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }
}