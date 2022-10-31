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

        // UI
        // [SerializeField] private GameObject scoreboard;
        // [SerializeField] private GameObject victoryScreen;

        [SerializeField] private Canvas scoreboard;
        [SerializeField] private Canvas victoryScreen;
        // [SerializeField] private Canvas escapeScreen;
        
        public static int CurrentPlayerLive;
        public static float TimeCounter;

        public static bool Running;
        
        private static bool _gameOver;
        // private static bool _gamePaused;

        void Awake()
        {
            TimeCounter = 0;
            CurrentPlayerLive = maxPlayerLive;
            
            // init on load Scene
            Time.timeScale = 1;
            Running = false;
            _gameOver = false;
            // _gamePaused = false;
        }

        // Update is called once per frame
        void Update()
        {
            if (BlockController.GetObstacleCounter() == 0) WinOrLoose(true);

            if (!_gameOver)
            {
                if (Input.GetKey(KeyCode.Space) && !Running)
                {
                    StartGame();
                }

                if (Running)
                {
                    TimeCounter += Time.deltaTime;
                }
            }

            // if (Input.GetKey(KeyCode.Escape))
            // {
            //     if (!_gamePaused)
            //     {
            //         // pause game
            //         Pause();
            //         Time.timeScale = 0;
            //         escapeScreen.enabled = true;
            //         
            //         _gamePaused = true;
            //     }
            //     else
            //     {
            //         // resume game
            //         Run();
            //         Time.timeScale = 1;
            //         escapeScreen.enabled = false;
            //         
            //         _gamePaused = false;
            //     }
            // }
        }

        private void StartGame()
        {
            GameObject.FindWithTag("Ball").GetComponent<BallController>().Launch();
            Run();
        }

        private void WinOrLoose(bool win)
        {
            // Potential problem: Canvas disable/enable not always working
            // scoreboard.SetActive(false);
            // victoryScreen.SetActive(true);
            
            scoreboard.enabled = false;
            victoryScreen.enabled = true;

            VictoryBehaviour.SetMessage(win);
            
            Run();
            
            Time.timeScale = 0;
            _gameOver = true;
        }

        public void TakeDamage()
        {
            CurrentPlayerLive -= 1;
            Pause();
            
            if (CurrentPlayerLive > 0)
            {
                // Spawn new ball
                Instantiate(ballPrefab, new Vector3(0, 0.25f, -4.1f), Quaternion.identity,
                    GameObject.Find("=== Game ===").transform);
            }
            else if (CurrentPlayerLive <= 0)
            {
                WinOrLoose(false);
            }
        }

        private static void Run()
        {
            Running = true;
        }

        private static void Pause()
        {
            Running = false;
        }
    }
}