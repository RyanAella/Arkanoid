using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace _Scripts.UI
{
    public class VictoryBehaviour : MonoBehaviour
    {
        private static string _message;

        private static int _nextLevelIndex;

        private TextMeshProUGUI _victoryText;

        private void Awake()
        {
            var maxIndex = SceneManager.sceneCountInBuildSettings - 1;
            var activeSceneIndex = SceneManager.GetActiveScene().buildIndex;

            Debug.Log("Scene Count Build Index: " + SceneManager.sceneCountInBuildSettings);

            if (maxIndex == activeSceneIndex)
            {
                GameObject.Find("RestartLevelButton").SetActive(false);
            }
        }

        private void Start()
        {
            _victoryText = GameObject.Find("Victory Text").GetComponent<TextMeshProUGUI>();
        }

        void Update()
        {
            var time = GameManager.Time;
            var vTime = time.ToString("F2");
            var score = ScoreBehaviour.Score;

            _victoryText.SetText("Score: " + score + "\nTime: " + vTime + "\n \nYou " + _message);
        }

        public static void SetMessage(bool win)
        {
            var maxIndex = SceneManager.sceneCountInBuildSettings - 1;
            var activeSceneIndex = SceneManager.GetActiveScene().buildIndex;

            if (maxIndex != activeSceneIndex)
            {
                var buttonText = GameObject.Find("RestartLevelButton").GetComponentInChildren<TextMeshProUGUI>();

                if (win)
                {
                    _nextLevelIndex = activeSceneIndex + 1;
                    buttonText.SetText("Next Level");
                }
                else
                {
                    _nextLevelIndex = activeSceneIndex;
                    buttonText.SetText("Restart Level");
                }
            }

            _message = win ? "won" : "lost";
        }

        public void RestartOrNextLevel()
        {
            SceneManager.LoadScene(_nextLevelIndex);
        }

        public void BackToMainMenu()
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}