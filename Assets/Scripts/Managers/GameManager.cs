using System.Collections;
using System.Collections.Generic;
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

    void Update()
    {

    }

    public void SpawnPlayer(Transform spawnLocation)
    {
        playerInstance = Instantiate(playerPrefab, spawnLocation.position, spawnLocation.rotation);
    }

    void Respawn() {
        playerInstance.transform.position = currentSpawnPoint.position;
    }
}
