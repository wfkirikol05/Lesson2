using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 5f;
    public float jumpForce = 300f;

    void Update()
    {
        // Движение ВЛЕВО-ВПРАВО (A/D keys)
        float horizontal = Input.GetAxis("Horizontal");
        transform.Translate(horizontal * moveSpeed * Time.deltaTime, 0, 0);

        // Движение ВПЕРЕД-НАЗАД (W/S keys)
        float vertical = Input.GetAxis("Vertical");
        transform.Translate(0, 0, vertical * moveSpeed * Time.deltaTime);

        // Прыжок
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce);
        }
    }
}