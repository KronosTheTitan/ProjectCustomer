using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    /// <summary>
    /// This class allows the player to pause the game.
    /// WATCH OUT, the pauseMenu should not be the same GameObject
    /// or a parent of the object that this class is attached to.
    /// otherwise the ESC button stops opening the menu.
    /// </summary>
    public class PauseMenu : MonoBehaviour
    {
        /// <summary>
        /// the variable keeping track of the main menu.
        /// </summary>
        [SerializeField] private Scene mainMenu;
        
        /// <summary>
        /// the variable keeping track of the parent object
        /// used for the pause menu.
        /// </summary>
        [SerializeField] private GameObject pauseMenu;

        /// <summary>
        /// the vatiale keeping track of the parent object
        /// used for the ingame user interface
        /// </summary>
        [SerializeField] public GameObject ingameMenu;
        
        [SerializeField] private GameObject confirmQuitMenu;

        [SerializeField] private GameObject tutorialScreen;
        
        /// <summary>
        /// Update loop to make the ESC key do its job.
        /// </summary>
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
            ingameMenu.SetActive(true);
        }

        public void PauseGame()
        {
            Time.timeScale = 0;
            pauseMenu.SetActive(true);
            ingameMenu.SetActive(false);
        }

        public void Restart()
        {
            SceneManager.LoadScene("SubmarineTest");
        }

        public void QuitToDesktop()
        {
            Application.Quit();
        }

        public void QuitToMainMenu()
        {
            SceneManager.LoadScene("MainMenu");
        }
        
        public void openConfirm()
        {
            confirmQuitMenu.SetActive(true);
        }

        public void closeConfirm()
        {
            confirmQuitMenu.SetActive(false);
        }

        public void openTutorial()
        {
            tutorialScreen.SetActive(true);
            pauseMenu.SetActive(false);
        }

        public void closetutorial()
        {
            tutorialScreen.SetActive(false);
            pauseMenu.SetActive(true);
        }
    }
}
