using UnityEngine;

public class SimpleCameraController : MonoBehaviour
{
    public Transform Target; // Цель для следования
    public Vector3 Offset = new Vector3(0, 2, -5); // Смещение от цели
    public float FollowSpeed = 2f; // Скорость следования
    public float ZoomSpeed = 2f; // Скорость зума

    private Camera cam;

    void Start()
    {
        cam = GetComponent<Camera>();

        // Автоматически находим игрока по тегу
        FindPlayerByTag();
    }

    void FindPlayerByTag()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            Target = player.transform;
            Debug.Log("Player found: " + player.name);
        }
        else
        {
            Debug.LogWarning("Player not found! Make sure your player has 'Player' tag");
        }
    }

    void LateUpdate()
    {
        if (Target == null) return;

        // Плавно следуем за целью
        Vector3 targetPosition = Target.position + Offset;
        transform.position = Vector3.Lerp(transform.position, targetPosition, FollowSpeed * Time.deltaTime);
        transform.LookAt(Target);

        // Зум колесом мыши
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        cam.fieldOfView = Mathf.Clamp(cam.fieldOfView - scroll * ZoomSpeed, 20f, 80f);
    }
}