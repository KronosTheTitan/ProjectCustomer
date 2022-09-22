using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    /// <summary>
    /// This class is used to control the game over menu.
    /// It has to be added to a gameObject in that scene in order to be used.
    /// </summary>
    public class GameOverMenu : MonoBehaviour
    {
        /// <summary>
        /// The variable used to keep track of the main menu. 
        /// </summary>
        [SerializeField] private Scene mainMenu;
        
        /// <summary>
        /// The variable used to keep track of the first level.
        /// </summary>
        [SerializeField] private Scene level1;

        [SerializeField] private GameObject restartScreen;

        [SerializeField] private GameObject deathMenu;
        public TMP_Text High_Score;

        /// <summary>
        /// Loads the first level.
        /// Warning, scene has to be added to the build list.
        /// </summary>
        /// <returns></returns>
        private void Start()
        {
            High_Score.text = PlayerPrefs.GetInt("highscore", 0).ToString();
        }

        public void PlayAgain()
        {
            deathMenu.SetActive(false);
            
            restartScreen.SetActive(true);
        }
        
        /// <summary>
        /// Loads the main menu scene.
        /// Warning, scene has to be added to the build list.
        /// </summary>
        /// <returns></returns>
        public void ReturnToMainMenu()
        {
            //load the scene asigned to the mainMenu variable
            SceneManager.LoadScene("mainMenu");
        }
    }
}
