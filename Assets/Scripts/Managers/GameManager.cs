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

    // SCORE
    private int _score = 0;
    public int score
    {
        get { return _score; }
        set
        {
            _score = value;
            OnScoreValueChanged.Invoke(_score);
            Debug.Log("Your score is:" + score.ToString());
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
    }

    public void SpawnPlayer(Transform spawnLocation)
    {
        playerInstance = Instantiate(playerPrefab, spawnLocation.position, spawnLocation.rotation);
    }

    public void Respawn()
    {
        playerInstance.transform.position = currentSpawnPoint.position;
    }
}
