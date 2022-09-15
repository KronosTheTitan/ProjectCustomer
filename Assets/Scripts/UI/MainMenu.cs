using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] private Scene level1;

        [SerializeField] private GameObject settingsMenu;
        [SerializeField] private GameObject mainMenu;

        public void StartGame()
        {
            SceneManager.LoadScene(level1.buildIndex);
        }

        public void OpenSettingsMenu()
        {
            mainMenu.SetActive(false);
            settingsMenu.SetActive(true);
        }
    
        public void ExitGame()
        {
            Application.Quit();
        }
    }
}
