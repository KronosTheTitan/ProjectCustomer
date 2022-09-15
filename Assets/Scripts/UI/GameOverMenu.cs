using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class GameOverMenu : MonoBehaviour
    {
        [SerializeField] private Scene mainMenu;
        [SerializeField] private Scene level1;
        
        public void PlayAgain()
        {
            SceneManager.LoadScene(level1.buildIndex);
        }

        public void ReturnToMainMenu()
        {
            SceneManager.LoadScene(mainMenu.buildIndex);
        }
    }
}
