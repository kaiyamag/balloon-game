using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Defines the behavior of a basic Obstacle2 (split obstacle)
*/
public class ConcreteObstacle2 : BaseObstacle
{
    /* Array of prefabs for all coin patterns that are compatible with this obstacle type
    */
    public GameObject[] validCoinPatternPrefabs;

    private float obsYMin = -3;     // Range of spawn y-values for obstacles
    private float obsYMax = 3;
    private float offset = -7;      // Offset to center Split Obstacle
    private float spawnX = 20;      // X position of right-hand obstacle spawn

    /*
    Instantiates this gameObject
    */
    public override void Spawn()
    {
        // Get random height
        float yPos = offset + Random.Range(obsYMin, obsYMax);
        Vector3 spawnPos = new Vector3(spawnX, yPos, 0);
        
        Instantiate(gameObject, spawnPos, Quaternion.identity);
    }

    /*
    Returns a random coin pattern decorator that is compatible with this base obstacle
    */
    public override GameObject GetRandomCoinPattern()
    {
        return validCoinPatternPrefabs[0];
    }
}