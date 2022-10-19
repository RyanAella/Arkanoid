using System.Collections.Generic;
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
        // UI
        [SerializeField] private Canvas mainCanvas;
        [SerializeField] private Canvas sceneSelectCanvas;
        
        public void NewGame()
        {
            Debug.Log("Pressed New Game");
            SceneManager.LoadScene("Demo Level");
        }
        
        public void SelectLevel()
        {
            Debug.Log("Pressed Select Level");
            
            mainCanvas.enabled = false;
            sceneSelectCanvas.enabled = true;
        }
        
        public void CloseGame()
        {
            Debug.Log("Pressed Close Game");
            Application.Quit();
        }

        public void LoadLevel1()
        {
            Debug.Log("Pressed Level 1");
            SceneManager.LoadScene("Level 1");
        }
        
        public void LoadLevel2()
        {
            Debug.Log("Pressed Level 1");
            SceneManager.LoadScene("Level 2");
        }

        public void Return()
        {
            sceneSelectCanvas.enabled = false;
            mainCanvas.enabled = true;
        }
    }
}