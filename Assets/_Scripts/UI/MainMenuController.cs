using UnityEngine;
using UnityEngine.SceneManagement;

/**
 * Start a new Game
 * Select a Level to start with 
 * Leave Game 
 */
namespace _Scripts.UI
{
    public class MainMenuController : MonoBehaviour
    {
        public void NewGame()
        {
            Debug.Log("Pressed New Game");
            SceneManager.LoadScene("Demo Level");
        }
        
        public void CloseGame()
        {
            Debug.Log("Pressed Close Game");
            Application.Quit();
        }
    }
}