using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstacle;
    public GameObject cloud;
    private GameManager gameManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        InvokeRepeating("SpawnObstacle", 1, 2);
        InvokeRepeating("SpawnCloud", 1, Random.Range(7, 10));
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnObstacle()
    {
        if (gameManager.isGameActive)
        {
            Vector3 spawnPos = new Vector3(20, Random.Range(2f, -3f), 0);
            Instantiate(obstacle, spawnPos, obstacle.transform.rotation);
        }
    }

    void SpawnCloud()
    {
        if (gameManager.isGameActive)
        {
            Vector3 spawnPos = new Vector3(10, Random.Range(3f, 0f), 0);
            Instantiate(cloud, spawnPos, obstacle.transform.rotation);
        }

    }
}
