using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Defines the behavior of a basic Obstacle2 (split obstacle). Inherits from StandardObstacle
*/
public class ConcreteObstacle2 : /*BaseObstacle*/ StandardObstacle
{
    /*
    Initialize obstacle properties from parent class 
    */
    void Start()
    {
        obstacleID = 2;
        obsYMin = -3;     // Range of spawn y-values for obstacles
        obsYMax = 3;
        offset = -7;      // Offset to center Split Obstacle
        spawnX = 20;      // X position of right-hand obstacle spawn
        spawnY = -7;      // Height of obstacle spawn
    }

    /*
    Instantiates this gameObject. Overrides the default Spawn() method from StandardObstacle
    */
    public override void Spawn()
    {
        // Get random height
        int randHeight = (int) Random.Range(obsYMin, obsYMax);
        spawnY = offset + randHeight;
        Vector3 spawnPos = new Vector3(spawnX, spawnY, 0);

        Instantiate(gameObject, spawnPos, Quaternion.identity);

    }
}