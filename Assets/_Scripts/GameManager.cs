using _Scripts.Ball;
using UnityEngine;

namespace _Scripts
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private GameObject ballPrefab;
        private static GameManager instance;

        [SerializeField] private int maxPlayerLive = 3;
        public static int _currentPlayerLive;
        public static int highscore;
        public static float time;
        
        public static bool running = false;

        // UI
        [SerializeField] private Canvas scoreboard;
        [SerializeField] private Canvas victoryScreen;

        public static GameManager Instance
        {
            get
            {
                return instance;
            }
        }

        void Awake()
        {
            time = 0;
            _currentPlayerLive = maxPlayerLive;
        }

        // Update is called once per frame
        void Update()
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
            
            if (_currentPlayerLive == 0)
            {
                Loose();
            }
        }

        private void StartGame()
        {
            GameObject.FindWithTag("Ball").GetComponent<BallController>().Launch();
            StartTimer();
        }

        private void Loose()
        {
            scoreboard.enabled = false;
            victoryScreen.enabled = true;
            StopTimer();
            Time.timeScale = 0;
        }

        public void TakeDamage()
        {
            _currentPlayerLive -= 1;
            if (_currentPlayerLive > 0)
            {
                // Spawn new ball
                Instantiate(ballPrefab, new Vector3(0,0.25f,-4.1f), Quaternion.identity);
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