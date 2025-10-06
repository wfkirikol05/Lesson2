using UnityEngine;
using UnityEngine.UI;

public class ExitButton : MonoBehaviour
{
    private Button exitButton;

    void Start()
    {
        exitButton = GetComponent<Button>();
        exitButton.onClick.AddListener(OnExitButtonClick);
    }

    void OnExitButtonClick()
    {
        QuitGame();
    }

    public void QuitGame()
    {
        Debug.Log("����� �� ����...");

#if UNITY_EDITOR
        // � ��������� Unity ������������� ���������������
        UnityEditor.EditorApplication.isPlaying = false;
#else
        // � ��������� ������ ��������� ����������
        Application.Quit();
#endif
    }
}