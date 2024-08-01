using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
ConcreteObstacle3.cs
Kaiya Magnuson 2024

Defines the behavior of a basic Obstacle3 (center obstacle). Inherits from StandardObstacle
*/
public class ConcreteObstacle3 : StandardObstacle
{
    private const int obstacleID = 3;       // Numeric ID for the center obstacle
    private const float obsYMin = -3;       // Range of spawn y-values for obstacles
    private const float obsYMax = 3;
    private const float offset = 4.5f;      // Offset to center Split Obstacle
    private const float spawnX = 20;        // X position of right-hand obstacle spawn
    private float spawnY = 0;               // Height of obstacle spawn

    /*
    Initialize obstacle properties from parent class 
    */
    void Awake()
    {
        obsInfo = ScriptableObject.CreateInstance<ObstacleInfo>();
        UpdateObstacleInfo();

        // Debug.Log(" FIRST ## Concrete protecteds ## obsID: " + obstacleID + ", offset: " + offset + ", spawnY: " + spawnY);
        // Debug.Log(" FIRST ## Concrete obsInfo ## obsID: " + obsInfo.id + ", offset: " + obsInfo.offset + ", spawnY: " + obsInfo.spawnY);
    }

    /*
    Instantiates this gameObject. Overrides the default Spawn() method from StandardObstacle
    */
    public override void Spawn()
    {
        UpdateObstacleInfo();
        // Set centered height
        Vector3 spawnPos = new Vector3(obsInfo.spawnX, obsInfo.spawnY, 0);

        // Debug.Log("SpawnX: " + obsInfo.spawnX);

        Instantiate(gameObject, spawnPos, Quaternion.identity);
    }

    /*
    Reinitializes this ObstacleInfo object
    */
    private void UpdateObstacleInfo() {
        if (obsInfo == null) {
            obsInfo = ScriptableObject.CreateInstance<ObstacleInfo>();
        }
        obsInfo.Init(obstacleID, offset, spawnX, spawnY);
    }
}