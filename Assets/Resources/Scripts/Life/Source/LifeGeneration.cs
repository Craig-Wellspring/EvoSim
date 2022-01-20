using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeGeneration : MonoBehaviour
{
    int spawnFrames = 250;

    int fCounter = 0;

    public GameObject spawn;

    public int eggs;

    public float spawnRadius = 10f;
    public float minHeight = 10f;
    public float maxHeight = 90f;

    public GameObject GenerateSpawn()
    {
        float xRange = Random.Range(-spawnRadius, spawnRadius);
        float yRange = Random.Range(minHeight, maxHeight);
        float zRange = Random.Range(-spawnRadius, spawnRadius);
        GameObject newSpawn =
            GameObject
                .Instantiate(spawn,
                transform.position + new Vector3(xRange, yRange, zRange),
                transform.rotation);
        newSpawn.name = spawn.name;

        return newSpawn;
    }

    void Update()
    {
        fCounter++;
        if (fCounter > spawnFrames)
        {
            fCounter = 0;
            if (eggs > 0)
            {
                GenerateSpawn();
                eggs--;
            }
        }
    }
}
