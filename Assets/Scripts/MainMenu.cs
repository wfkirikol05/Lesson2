using UnityEngine;
using UnityEngine.SceneManagement;

public class EscapeToMenu : MonoBehaviour
{
    [Header("Settings")]
    public string mainMenuSceneName = "MainMenu";
    public bool showConfirmation = false;

    void Update()
    {
        // Проверяем нажатие Escape
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (showConfirmation)
            {
                ShowConfirmation();
            }
            else
            {
                LoadMainMenu();
            }
        }
    }

    void LoadMainMenu()
    {
        Debug.Log("Загрузка главного меню...");
        SceneManager.LoadScene("Меню");
    }

    void ShowConfirmation()
    {
        // Здесь можно реализовать UI диалог
        Debug.Log("Вернуться в главное меню? (Нажмите Y для подтверждения)");

        // Простая проверка в консоли (для сложного UI нужен отдельный код)
        if (Input.GetKeyDown(KeyCode.Y))
        {
            LoadMainMenu();
        }
    }
}