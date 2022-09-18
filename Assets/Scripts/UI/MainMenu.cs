using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    /// <summary>
    /// this class is used to control the main menu.
    /// attach it to a game object for it to work.
    /// </summary>
    public class MainMenu : MonoBehaviour
    {
        /// <summary>
        /// the variable keeping track of the game level.
        /// </summary>
        [SerializeField] private Scene level;
        
        /// <summary>
        /// the GameObject that functions as the parent for the settings menu.
        /// </summary>
        [SerializeField] private GameObject settingsMenu;
        
        /// <summary>
        /// the GameObject that functions as the parent for everything in the main menu.
        /// </summary>
        [SerializeField] private GameObject mainMenu;
        
        /// <summary>
        /// the GameObject that functions as the parent for everything in the highscore menu.
        /// </summary>
        [SerializeField] private GameObject highscoreMenu;

        public void StartGame()
        {
            SceneManager.LoadScene("SubmarineTest");
        }

        public void OpenSettingsMenu()
        {
            mainMenu.SetActive(false);
            settingsMenu.SetActive(true);
        }
        
        public void CloseSettingsMenu()
        {
            mainMenu.SetActive(true);
            settingsMenu.SetActive(false);
        }
    
        public void ExitGame()
        {
            Application.Quit();
            Debug.Log("Quit button works");
        }
        
        public void OpenHighscoreMenu()
        {
            mainMenu.SetActive(false);
            settingsMenu.SetActive(true);
        }
        
        public void CloseHighscoreMenu()
        {
            mainMenu.SetActive(true);
            settingsMenu.SetActive(false);
        }
        
        
    }
}
