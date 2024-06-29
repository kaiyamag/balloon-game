using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Defines the behavior of a basic Obstacle3 (center obstacle).
*/
public class ConcreteObstacle3 : BaseObstacle
{
    /* Array of prefabs for all coin patterns that are compatible with this obstacle type
    */
    public GameObject[] validCoinPatternPrefabs;

    private float spawnX = 20;      // X position of right-hand obstacle spawn

    /*
    Instantiates this gameObject
    */
    public override void Spawn()
    {
        // Set centered height
        float yPos = 0;
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