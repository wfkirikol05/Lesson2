using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // �������� ��������
    public float Speed = 5f;
    public float JumpForce = 300f;

    void Update()
    {
        // �������� �����-������
        float horizontal = Input.GetAxis("Horizontal");
        transform.Translate(horizontal * Speed * Time.deltaTime, 0, 0);

        // ������
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up * JumpForce);
        }
    }
}