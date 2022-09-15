using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class PauseMenu : MonoBehaviour
    {
        [SerializeField] private Scene mainMenu;
        [SerializeField] private GameObject pauseMenu;
    
        private void Update()
        {
            if (!Input.GetKeyDown(KeyCode.Escape)) return;
            if (Time.timeScale == 0)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }

        public void ResumeGame()
        {
            Time.timeScale = 1;
            pauseMenu.SetActive(false);
        }

        public void PauseGame()
        {
            Time.timeScale = 0;
            pauseMenu.SetActive(true);
        }

        public void QuitToDesktop()
        {
            Application.Quit();
        }

        public void QuitToMainMenu()
        {
            SceneManager.LoadScene(mainMenu.buildIndex);
        }
    }
}
