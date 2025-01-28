using System.Collections;
using UnityEngine;

public class FishSpawner : MonoBehaviour
{
    public GameObject fishPrefab;
    public Transform target;

    private float randomSpawnTimer;
    private float randomSpawnInterval;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SpawnFish());
    }

    void Update()
    {
        randomSpawnTimer -= Time.deltaTime;

        if (randomSpawnTimer <= 0)
        {
            randomSpawnTimer = randomSpawnInterval;
            Instantiate(fishPrefab, transform.position, Quaternion.identity);
        }
    }

    private IEnumerator SpawnFish()
    {
        while (true)
        {
            GameObject spawnLocation = (GameObject)Instantiate(fishPrefab, target.position, Quaternion.identity);
            float delay = Random.Range(2.0f, 8.0f);
            yield return new WaitForSeconds(delay);
        }
    }
}
