using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject ballPrefab;

    [SerializeField] private int maxPlayerLive = 3;
    private int _currentPlayerLive;

    // UI
    [SerializeField] private Canvas scoreboard;
    [SerializeField] private Canvas victoryScreen;

    // Start is called before the first frame update
    void Awake()
    {
        _currentPlayerLive = maxPlayerLive;
    }

    // Update is called once per frame
    void Update()
    {
        if (_currentPlayerLive == 0)
        {
            Loose();
        }
    }

    private void Loose()
    {
        scoreboard.enabled = false;
        victoryScreen.enabled = true;
    }

    private void SpawnBall()
    {
        Debug.Log("Respawned Ball");
        Instantiate(ballPrefab, new Vector3(0,0.25f,0), Quaternion.identity);
    }

    public void TakeDamage()
    {
        _currentPlayerLive -= 1;
        if (_currentPlayerLive > 0) SpawnBall();
    }
}