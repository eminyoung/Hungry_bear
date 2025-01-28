using System.Collections;
using UnityEngine;

public class FishSpawner : MonoBehaviour
{    
    [SerializeField] private GameObject goodProjectile;
    [SerializeField] private GameObject badProjectile;
    [SerializeField] private float spawnRate;
    [SerializeField] private float timer = 0;
    [SerializeField] private float heightOffset = 3;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawnFish();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < spawnRate) {
            timer = timer + Time.deltaTime;
        } else {
            spawnFish();
            timer = 0;
        }
    }

    void spawnFish() {
        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset;
        GameObject projectilePrefab = Random.value > 0.7f ? goodProjectile : badProjectile;

        GameObject newFish = Instantiate(projectilePrefab, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), 0), transform.rotation);
    }
}
