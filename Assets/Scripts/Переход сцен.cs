using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI
{
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
            SceneManager.LoadScene("Игра");
        }
    }
}