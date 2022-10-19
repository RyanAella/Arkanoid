using _Scripts.Blocks;
using UnityEngine;

namespace _Scripts.Ball
{
    public class BallController : MonoBehaviour
    {
        [SerializeField] private float speed = 5f;
        [SerializeField] private LayerMask mask;

        private float _zDirection = 1;
        private float _xDirection = 0;

        // x and z Coordinates
        private float _borderLeft, _borderRight;
        private float _borderTop, _borderBottom;

        private bool _running;

        private const float YPos = 0.25f;

        public void Awake()
        {
            _running = false;
            CalculateBorders();
        }

        public void Update()
        {
            if (GameManager.running && _running)
            {
                BallMovement();
            }
            else
            {
                var pos = transform.position;
                var paddlePos = GameObject.Find("Paddle").transform.position;
                transform.position = new Vector3(paddlePos.x, YPos, pos.z);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                var ball = transform;
                var ballPos = ball.position;
                var ballScale = ball.localScale;

                var paddle = other.transform;
                var paddlePos = paddle.position;
                var paddleScale = paddle.localScale;

                var maxDist = 0.5f * paddleScale.x + 0.25f * ballScale.x;
                var dist = ballPos.x - paddlePos.x;
                _xDirection = dist / maxDist;
                _zDirection = -_zDirection;
                
                transform.GetComponent<AudioSource>().Play();
            }
        }

        // Launch the ball
        public void Launch()
        {
            _zDirection = 1;
            _running = true;
        }

        private void CalculateBorders()
        {
            var ground = GameObject.Find("Ground");

            // calculate left, right, top and bottom edge of the playfield
            var pos = ground.transform.position;
            var scale = ground.transform.localScale;

            _borderLeft = pos.x - (scale.x * 10 / 2);
            _borderRight = pos.x + (scale.x * 10 / 2);
            _borderBottom = pos.z - (scale.z * 10 / 2);
            _borderTop = pos.z + (scale.z * 10 / 2);
        }

        private void BallMovement()
        {
            var ball = transform;
            var pos = ball.position;
            var scale = ball.localScale;

            if ((pos.z + scale.z / 2) >= _borderTop)
            {
                _zDirection = -_zDirection;
                transform.GetComponent<AudioSource>().Play();
            }
            else if ((pos.z - scale.z / 2) <= _borderBottom) // Lost because reached bottom
            {
                Die();
            }
            else if (((pos.x - scale.x / 2) <= _borderLeft) ||
                     ((pos.x + scale.x / 2) >= _borderRight)) // Hiting left or right border
            {
                _xDirection = -_xDirection;
                transform.GetComponent<AudioSource>().Play();
            }

            transform.position += new Vector3(_xDirection * speed, 0, _zDirection * speed) * Time.deltaTime;

            CheckForBlockCollision();
        }

        private void CheckForBlockCollision()
        {
            var ball = transform;
            var pos = ball.position;
            var scale = ball.localScale;

            Collider[] colliders = Physics.OverlapSphere(pos, 0.5f * scale.x, mask);

            if (colliders.Length > 0)
            {
                if (_zDirection > 0)
                {
                    _zDirection = -_zDirection;
                }
                else if (_zDirection < 0)
                {
                    _zDirection = -_zDirection;
                }

                foreach (var coll in colliders)
                {
                    // Debug.Log("Hit: " + colliders.Length + " colliders");
                    // Debug.Log("Ball hit: " + coll.gameObject.name);
                    coll.GetComponent<BlockController>().Damage();
                }
            }
        }

        private void Die()
        {
            Debug.Log("Ball Died");
            var manager = GameObject.Find("GameManager").GetComponent<GameManager>();
            manager.TakeDamage();
            manager.StopTimer();
            Destroy(gameObject);
        }
    }
}