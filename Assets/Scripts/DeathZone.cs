using UnityEngine;

public class DeathZone : MonoBehaviour
{
    public Vector3 respawnPosition = new Vector3(0, 2, 0);

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Object in death zone: " + other.name);

        // Вариант 1: По имени (если тэги не работают)
        if (other.name == "Player" || other.name.Contains("Player"))
        {
            RespawnPlayer(other.gameObject);
            return;
        }

        // Вариант 2: По тэгу
        if (other.CompareTag("Player"))
        {
            RespawnPlayer(other.gameObject);
            return;
        }

        // Вариант 3: По родителю (если коллайдер на дочернем объекте)
        if (other.transform.parent != null && other.transform.parent.CompareTag("Player"))
        {
            RespawnPlayer(other.transform.parent.gameObject);
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