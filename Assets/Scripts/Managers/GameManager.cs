using UnityEngine.Events;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    static GameManager _instance = null;
    public static GameManager instance
    {
        get { return _instance; }
        set { _instance = value; }
    }

    [SerializeField] PlayerController playerPrefab;
    [HideInInspector] public PlayerController playerInstance;
    [SerializeField] Transform currentSpawnPoint;


    [HideInInspector] public UnityEvent<int> OnScoreValueChanged;
    [HideInInspector] public UnityEvent<int> OnAttemptsValueChanged;

    // SCORE
    private int _score = 0;
    public int score
    {
        get { return _score; }
        set
        {
            _score = value;
            OnScoreValueChanged.Invoke(_score);
        }
    }

    // ATTEMPTS
    private int _attempts = 1;
    public int attempts
    {
        get { return _attempts; }
        set
        {
            _attempts = value;
            OnAttemptsValueChanged.Invoke(_attempts);
        }
    }

    void Awake()
    {
        if (instance)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        SpawnPlayer(currentSpawnPoint);
        score = 0;
        attempts = 1;
    }

    public void SpawnPlayer(Transform spawnLocation)
    {
        playerInstance = Instantiate(playerPrefab, spawnLocation.position, spawnLocation.rotation);
    }

    public void Respawn()
    {
        playerInstance.transform.position = currentSpawnPoint.position;
        attempts ++;
    }
}
