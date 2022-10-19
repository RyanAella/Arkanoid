using _Scripts.PowerUps;
using _Scripts.UI;
using UnityEngine;

namespace _Scripts.Blocks
{
    public class BlockController : MonoBehaviour
    {
        [SerializeField] private int blockLife;
        [SerializeField] private GameObject powerUpPrefab;

        public static int _obstacleCounter = 0;
        
        private static readonly float PowerUpPercentage = 0.2f;

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
            ScoreBehaviour.score += 1;

            if (blockLife == 0)
            {
                Die();
            }
        }

        private void Die()
        {
            if (_hasPowerUp)
            {
                var powerUp = Instantiate(powerUpPrefab, transform.position, Quaternion.identity, GameObject.Find("=== Game ===").transform);
                powerUp.GetComponent<PowerUpController>().type = _powerUpType;
            }

            _obstacleCounter--;
            Destroy(gameObject);
        }

        private void ChoosePowerUp()
        {
            var random = new System.Random();
            _hasPowerUp = random.NextDouble() <= PowerUpPercentage;

            if (_hasPowerUp)
            {
                // var powerUpTypes = Enum.GetValues(typeof(PowerUpType));

                if (random.NextDouble() <= 0.5f)
                {
                    _powerUpType = PowerUpType.IncreasePaddleSize;
                }
                else
                {
                    _powerUpType = PowerUpType.IncreasePaddleSpeed;
                }
            }
        }
    }
}