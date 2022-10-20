using _Scripts.Ball;
using _Scripts.Blocks;
using _Scripts.UI;
using UnityEngine;

namespace _Scripts
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private GameObject ballPrefab;

        [SerializeField] private int maxPlayerLive = 3;

        public static int CurrentPlayerLive;

        // public static int highscore;
        public static float Time;

        public static bool Running;
        private static bool _gameOver;

        // UI
        // [SerializeField] private GameObject scoreboard;
        // [SerializeField] private GameObject victoryScreen;

        [SerializeField] private Canvas scoreboard;
        [SerializeField] private Canvas victoryScreen;

        void Awake()
        {
            Time = 0;
            CurrentPlayerLive = maxPlayerLive;
        }

        // Update is called once per frame
        void Update()
        {
            if (BlockController.GetObstacleCounter() == 0) WinOrLoose(true);

            if (!_gameOver)
            {
                if (Input.GetKey(KeyCode.Space) && !Running)
                {
                    Debug.Log("Space");
                    StartGame();
                }

                if (Running)
                {
                    Time += UnityEngine.Time.deltaTime;
                }
            }
        }

        private void StartGame()
        {
            GameObject.FindWithTag("Ball").GetComponent<BallController>().Launch();
            StartTimer();
        }

        private void WinOrLoose(bool win)
        {
            // Potential problem: Canvas disable/enable not always working
            // scoreboard.SetActive(false);
            // victoryScreen.SetActive(true);
            VictoryBehaviour.SetMessage(win);
            scoreboard.enabled = false;
            victoryScreen.enabled = true;

            StopTimer();
            UnityEngine.Time.timeScale = 0;
            _gameOver = true;
        }

        public void TakeDamage()
        {
            CurrentPlayerLive -= 1;
            if (CurrentPlayerLive > 0)
            {
                // Spawn new ball
                Instantiate(ballPrefab, new Vector3(0, 0.25f, -4.1f), Quaternion.identity,
                    GameObject.Find("=== Game ===").transform);
            }
            else if (CurrentPlayerLive <= 0)
            {
                Debug.Log("CurrentPlayerLife is 0");
                WinOrLoose(false);
            }
        }

        private void StartTimer()
        {
            Running = true;
        }

        public void StopTimer()
        {
            Running = false;
        }
    }
}