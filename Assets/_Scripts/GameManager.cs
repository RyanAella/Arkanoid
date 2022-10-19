using _Scripts.Ball;
using _Scripts.Blocks;
using _Scripts.UI;
using UnityEngine;

namespace _Scripts
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private GameObject ballPrefab;
        private static GameManager instance;

        [SerializeField] private int maxPlayerLive = 3;

        public static int _currentPlayerLive;

        // public static int highscore;
        public static float time;

        public static bool running = false;
        private static bool gameover = false;

        // UI
        // [SerializeField] private GameObject scoreboard;
        // [SerializeField] private GameObject victoryScreen;

        [SerializeField] private Canvas scoreboard;
        [SerializeField] private Canvas victoryScreen;

        public static GameManager Instance
        {
            get { return instance; }
        }

        void Awake()
        {
            time = 0;
            _currentPlayerLive = maxPlayerLive;
        }

        // Update is called once per frame
        void Update()
        {
            if (BlockController.GetObstacleCounter() == 0) WinOrLoose(true);
            
            if (!gameover)
            {
                if (Input.GetKey(KeyCode.Space) && !running)
                {
                    Debug.Log("Space");
                    StartGame();
                }

                if (running)
                {
                    time += Time.deltaTime;
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
            Time.timeScale = 0;
            gameover = true;
        }

        public void TakeDamage()
        {
            _currentPlayerLive -= 1;
            if (_currentPlayerLive > 0)
            {
                // Spawn new ball
                Instantiate(ballPrefab, new Vector3(0, 0.25f, -4.1f), Quaternion.identity, GameObject.Find("=== Game ===").transform);
            }
            else if (_currentPlayerLive <= 0)
            {
                Debug.Log("CurrentPlayerLife is 0");
                WinOrLoose(false);
            }
        }

        private void StartTimer()
        {
            running = true;
        }

        public void StopTimer()
        {
            running = false;
        }
    }
}