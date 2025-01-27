using System.Collections;
using UnityEngine;

public class FishSpawner : MonoBehaviour
{
    public GameObject fishObject;
    public Transform fishSpawnPoint;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SpawnFish());
    }

    private IEnumerator SpawnFish()
    {
        while (true)
        {
            GameObject spawnLocation = (GameObject)Instantiate(fishObject, fishSpawnPoint.position, Quaternion.identity);
            float delay = Random.Range(2.0f, 8.0f);
            yield return new WaitForSeconds(delay);
        }
    }
}
