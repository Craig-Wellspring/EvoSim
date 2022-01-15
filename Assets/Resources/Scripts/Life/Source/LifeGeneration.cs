using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeGeneration : MonoBehaviour
{
    int spawnFrames = 250;

    int fCounter = 0;

    public GameObject spawn;

    public int eggs;

    public GameObject GenerateSpawn()
    {
        GameObject newSpawn =
            GameObject
                .Instantiate(spawn,
                transform.position + new Vector3(0, 1, 0),
                transform.rotation);
        newSpawn.name = spawn.name;
        Rigidbody rb = spawn.GetComponent<Rigidbody>();
        rb.AddForce(new Vector3(0, 100, 0), ForceMode.VelocityChange);

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
