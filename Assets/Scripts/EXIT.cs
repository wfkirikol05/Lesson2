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
        Debug.Log("Выход из игры...");

#if UNITY_EDITOR
        // В редакторе Unity останавливаем воспроизведение
        UnityEditor.EditorApplication.isPlaying = false;
#else
        // В собранной версии закрываем приложение
        Application.Quit();
#endif
    }
}