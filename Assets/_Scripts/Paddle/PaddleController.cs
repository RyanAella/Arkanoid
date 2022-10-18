using UnityEngine;

namespace _Scripts.Paddle
{
    public class PaddleController : MonoBehaviour
    {
        [SerializeField] public float speed = 1f;

        private float _borderLeft, _borderRight;

        void Awake()
        {
            CalculateBorders();
        }

        void Update()
        {
            PaddleMovement();
        }

        private void CalculateBorders()
        {
            var ground = GameObject.Find("Ground");
            var pos = ground.transform.position;
            var scale = ground.transform.localScale;

            _borderLeft = pos.x - (scale.x * 10 / 2);
            _borderRight = pos.x + (scale.x * 10 / 2);
        }

        private void PaddleMovement()
        {
            var dir = Input.GetAxis("Horizontal");
            var pos = transform.position;

            if (CheckBorders())
            {
                // calculate new position
                var newPosX = pos.x + dir * speed * Time.deltaTime;
                transform.position = new Vector3(newPosX, pos.y, pos.z);
            }
        }

        private bool CheckBorders()
        {
            var paddle = transform;
            var dir = Input.GetAxis("Horizontal");
            var pos = paddle.position;
            var scale = paddle.localScale;

            return (!(pos.x - scale.x / 2 <= _borderLeft) && dir < 0) ||
                   (!(pos.x + scale.x / 2 >= _borderRight) && dir > 0) ||
                   (pos.x - scale.x / 2 <= _borderLeft && dir > 0) ||
                   (pos.x + scale.x / 2 >= _borderRight && dir < 0);
        }
    }
}