using _Scripts.PowerUps;
using _Scripts.UI;
using UnityEngine;

namespace _Scripts.Blocks
{
    public class BlockController : MonoBehaviour
    {
        [SerializeField] private int blockLife;
        [SerializeField] private GameObject powerUpPrefab;

        public static int _obstacleCounter;

        private static readonly float PowerUpPercentage = 1.0f;

        private PowerUpType _powerUpType;
        private bool _hasPowerUp;

        public void Awake()
        {
            _obstacleCounter++;
            ChoosePowerUp();
        }

        public static int GetObstacleCounter()
        {
            return _obstacleCounter;
        }

        public void Damage()
        {
            blockLife -= 1;
            ScoreBehaviour.Score += 1;

            if (blockLife == 0)
            {
                Die();
            }
        }

        private void Die()
        {
            if (_hasPowerUp)
            {
                var powerUp = Instantiate(powerUpPrefab, transform.position, Quaternion.identity,
                    GameObject.Find("=== Game ===").transform);
                powerUp.GetComponent<PowerUpController>().type = _powerUpType;
            }

            _obstacleCounter--;
            GameObject.Find("ObstacleAudioSource").GetComponent<AudioSource>().Play();
            Destroy(gameObject);
        }

        private void ChoosePowerUp()
        {
            var random = new System.Random();
            _hasPowerUp = random.NextDouble() <= PowerUpPercentage;

            if (_hasPowerUp)
            {
                // var powerUpTypes = Enum.GetValues(typeof(PowerUpType));
                var rndValue = random.NextDouble();
                
                if (rndValue <= 0.33f)
                {
                    _powerUpType = PowerUpType.IncreasePaddleSize;
                }
                else if (rndValue <= 0.66f)
                {
                    _powerUpType = PowerUpType.IncreasePaddleSpeed;
                }
                else
                {
                    _powerUpType = PowerUpType.StickyBall;
                }
                Debug.Log(_powerUpType);
            }
        }
    }
}