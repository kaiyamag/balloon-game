using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
SpawnManager.cs
Kaiya Magnuson 2024

Manages the instantiation of random obstacles.
*/


public class SpawnManager : MonoBehaviour
{
    public GameObject[] obstacles;   // Stores obstacle prefabs. Filled in editor
    private float spawnX = 20;      // X position of right-hand obstacle spawn
    private float startDelay = 2;   // Number of seconds before starting obstacle spawn
    private float spawnInterval = 2;   // Number of seconds between obstacles spawning
    private float obsYMin = -3;     // Range of spawn y-values for obstacles
    private float obsYMax = 3;
    private float offset = -7;      // Offset to center Obstacle2

    void Start()
    {
        StartInvoke();
    }
    void Update()
    {

    }

    // Spawns a new random obstacle
    void SpawnRandomObstacle() 
    {
        // Pick random obstacle
        int index = Random.Range(0, obstacles.Length);

        // Pick random y-position for applicable obstacles
        float yPos;
        if (index == 0) {
            yPos = offset + Random.Range(obsYMin, obsYMax);
        }
        else {
            yPos = 0;
        }
        Vector3 spawnPos = new Vector3(spawnX, yPos, 0);

        // Instantiate random object
        Instantiate(obstacles[index], spawnPos, obstacles[index].transform.rotation);
    }

    void StartInvoke() {
        InvokeRepeating("SpawnRandomObstacle", startDelay, spawnInterval);
    }
}
