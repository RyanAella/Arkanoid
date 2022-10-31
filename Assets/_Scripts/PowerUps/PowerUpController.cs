using _Scripts.Ball;
using _Scripts.Paddle;
using UnityEngine;

namespace _Scripts.PowerUps
{
    public class PowerUpController : MonoBehaviour
    {
        [SerializeField] private float speed = 5f;
        [SerializeField] private int stickTimes = 3;

        public PowerUpType type;

        public void Start()
        {
            switch (type)
            {
                case PowerUpType.IncreasePaddleSize:
                    GetComponent<MeshRenderer>().material = (Material)Resources.Load("Materials/SizePowerUp");
                    break;
                case PowerUpType.IncreasePaddleSpeed:
                    GetComponent<MeshRenderer>().material = (Material)Resources.Load("Materials/SpeedPowerUp");
                    break;
                case PowerUpType.StickyBall:
                    GetComponent<MeshRenderer>().material = (Material)Resources.Load("Materials/StickyPowerUp");
                    break;
            }
        }

        public void Update()
        {
            var pos = transform.position;
            transform.position += new Vector3(0, 0, -speed) * Time.deltaTime;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                switch (type)
                {
                    case PowerUpType.IncreasePaddleSize:
                        ChangePaddleSize(other.gameObject);
                        break;
                    case PowerUpType.IncreasePaddleSpeed:
                        IncreasePaddleSpeed(other.gameObject);
                        break;
                    case PowerUpType.StickyBall:
                        MakeBallSticky();
                        break;
                }
                GameObject.Find("PowerUpAudioSource").GetComponent<PowerUpAudioController>().PlayAudio(type);
                Destroy(gameObject);
            }
        }

        private void ChangePaddleSize(GameObject paddle)
        {
            var scale = paddle.transform.localScale.x;
            if (scale < 4.5f)
            {
                paddle.transform.localScale += new Vector3(+0.5f, 0, 0);
            }
        }

        private void IncreasePaddleSpeed(GameObject paddle)
        {
            var speed = paddle.GetComponent<PaddleController>().speed;
            if (speed < 10)
            {
                paddle.GetComponent<PaddleController>().speed += 1f;   
            }
        }
        
        private void MakeBallSticky()
        {
            var ball = GameObject.FindWithTag("Ball");
            ball.GetComponent<BallController>().EnableSticky(stickTimes);
        }
    }
}