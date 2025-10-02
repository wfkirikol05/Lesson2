using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayButton : MonoBehaviour
{
    private Button playButton;

    void Start()
    {
        playButton = GetComponent<Button>();
        playButton.onClick.AddListener(OnPlayButtonClick);
    }

    void OnPlayButtonClick()
    {
        // Загружаем игровую сцену по имени
        SceneManager.LoadScene("Игра");

    }
}
