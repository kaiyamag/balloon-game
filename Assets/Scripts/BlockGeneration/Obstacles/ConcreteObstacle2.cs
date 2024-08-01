using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
ConcreteObstacle2.cs
Kaiya Magnuson 2024

Defines the behavior of a basic Obstacle2 (split obstacle). Inherits from StandardObstacle
*/
public class ConcreteObstacle2 : StandardObstacle
{
    private const int obstacleID = 2;       // Numeric ID for the split obstacle
    private const float obsYMin = -3;       // Range of spawn y-values for obstacles
    private const float obsYMax = 3;
    private const float offset = -7;        // Offset to center Split Obstacle
    private const float spawnX = 20;        // X position of right-hand obstacle spawn
    private  float spawnY = -7;             // Height of obstacle spawn

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
        // Get random height
        int randHeight = (int) Random.Range(obsYMin, obsYMax);
        spawnY = obsInfo.offset + randHeight;
        UpdateObstacleInfo();
        Vector3 spawnPos = new Vector3(obsInfo.spawnX, obsInfo.spawnY, 0);

        Debug.Log("Random height: " + randHeight + ", offset: " + obsInfo.offset + ", spawnY: " + obsInfo.spawnY);

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