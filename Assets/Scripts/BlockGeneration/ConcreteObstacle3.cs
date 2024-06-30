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

    /* Numeric ID for this obstacle type
    */
    protected int obstacleID = 3;
    public ObstacleInfo obsInfo;

    private float offset = 4.5f;      // Offset to center Split Obstacle
    private float spawnX = 20;      // X position of right-hand obstacle spawn
    private float spawnY = 0;
    
    /*
    Initializes/updates ObstacleInfo object for this obstacle based on private properties
    */
    private void SetObstacleInfo()
    {
        if (obsInfo == null) {
            obsInfo = ScriptableObject.CreateInstance<ObstacleInfo>();
        }
        obsInfo.Init(obstacleID, offset, spawnX, spawnY);
    }

    /*
    Instantiates this gameObject
    */
    public override void Spawn()
    {
        // Set centered height
        Vector3 spawnPos = new Vector3(spawnX, spawnY, 0);

        Instantiate(gameObject, spawnPos, Quaternion.identity);
    }

    /*
    Returns a random coin pattern decorator that is compatible with this base obstacle
    */
    public override GameObject GetRandomCoinPattern()
    {
        return validCoinPatternPrefabs[0];
    }

    /*
    Returns a list of obstacle info
    */
    public override ObstacleInfo GetObstacleInfo()
    {
        SetObstacleInfo();
        return obsInfo;
    }
}