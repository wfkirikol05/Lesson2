using UnityEngine;

public class Collectible : MonoBehaviour
{
    public int coinValue = 1; // ���������� ����� �� ������
    public AudioClip collectSound; // ���� ����� (�����������)
    public GameObject collectEffect; // ������ ����� (�����������)

    void OnTriggerEnter(Collider other)
    {
        // ���������, ��� ��� �����
        if (other.TryGetComponent<PlayerController>(out var player))
        {
            // �������� ����� ����� ������ � ������
            player.CollectCoin(coinValue);

            // ������������� ���� �����
            if (collectSound != null)
            {
                AudioSource.PlayClipAtPoint(collectSound, transform.position);
            }

            // ������� ������ �����
            if (collectEffect != null)
            {
                Instantiate(collectEffect, transform.position, transform.rotation);
            }

            // ���������� ������� ������
            Destroy(gameObject);
        }
    }
}
