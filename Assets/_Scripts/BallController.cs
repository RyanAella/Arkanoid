using UnityEngine;

public class BallController : MonoBehaviour
{
    private GameObject _manager;
    private GameObject _ground;
    
    [SerializeField] private float speed = -2f;
    
    private float _currentSpeedZ;
    private float _currentSpeedX;

    // x Koordinate
    private float _borderLeft, _borderRight;

    // z Koordinate
    private float _borderTop, _borderBottom;

    private void Awake()
    {
        _manager = GameObject.Find("GameManager");
        _ground = GameObject.Find("Ground");
        
        // setze currentSpeed
        _currentSpeedZ = speed;
        _currentSpeedX = 0;

        // berechne linke, rechte, obere und untere Kante vom Spielfeld
        var pos = _ground.transform.position;
        var scale = _ground.transform.localScale;

        _borderLeft = pos.x - (scale.x * 10 / 2);
        _borderRight = pos.x + (scale.x * 10 / 2);
        _borderBottom = pos.z - (scale.z * 10 / 2);
        _borderTop = pos.z + (scale.z * 10 / 2);

        // Debug.Log("BorderLeft: " + borderLeft);
        // Debug.Log("BorderRight: " + borderRight);
        // Debug.Log("BorderBottom: " + borderBottom);
        // Debug.Log("BorderTop: " + borderTop);
    }

    // Update is called once per frame
    void Update()
    {
        var pos = transform.position;
        var scale = transform.localScale;
        
        if ((pos.z + scale.z / 2) >= _borderTop)
        {
            // Debug.Log("Touched Top");
            _currentSpeedZ = -_currentSpeedZ;
        }

        // Lost cause reached bottom
        if ((pos.z - scale.z / 2) <= _borderBottom)
        {
            // Debug.Log("Touched Bottom");
            Die();
        }

        if ((pos.x - scale.x / 2) <= _borderLeft)
        {
            // Debug.Log("Touched Left");
            _currentSpeedX = -_currentSpeedX;
        }

        if ((pos.x + scale.z / 2) >= _borderRight)
        {
            // Debug.Log("Touched Right");
            _currentSpeedX = -_currentSpeedX;
        }

        var zPos = pos.z + _currentSpeedZ * Time.deltaTime;
        var xPos = pos.x + _currentSpeedX * Time.deltaTime;
        transform.position = new Vector3(xPos, pos.y, zPos);
    }

    private void Die()
    {
        Debug.Log("Ball Died");
        _manager.GetComponent<GameManager>().TakeDamage();
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Player")) return;

        var ballPos = transform.position;
        var ballScale = transform.localScale;
        var paddlePos = other.transform.position;
        var paddleScale = other.transform.localScale;

        if ((ballPos.x + ballScale.x / 4) >= (paddlePos.x - paddleScale.x / 2) && ballPos.x < paddlePos.x)
        {
            if (_currentSpeedX == 0)
            {
                _currentSpeedX = speed;
            }
            
            _currentSpeedX = -Mathf.Abs(_currentSpeedX);
            _currentSpeedZ = -_currentSpeedZ;
        }
        else if ((ballPos.x - ballScale.x / 4) <= (paddlePos.x + paddleScale.x / 2) && ballPos.x > paddlePos.x)
        {
            if (_currentSpeedX == 0)
            {
                _currentSpeedX = speed;
            }
            
            _currentSpeedX = Mathf.Abs(_currentSpeedX);
            _currentSpeedZ = -_currentSpeedZ;
        }
        else if (ballPos.x == paddlePos.x)
        {
            _currentSpeedZ = -_currentSpeedZ;
        }
        else
        {
            _currentSpeedX = -_currentSpeedX;
        }
    }
}