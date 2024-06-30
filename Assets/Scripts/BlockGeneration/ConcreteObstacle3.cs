using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Defines the behavior of a basic Obstacle3 (center obstacle). Inherits from StandardObstacle
*/
public class ConcreteObstacle3 : StandardObstacle
{
    /*
    Initialize obstacle properties from parent class 
    */
    void Start()
    {
        obstacleID = 3;
        offset = 4.5f;      // Offset to center Split Obstacle
        spawnX = 20;      // X position of right-hand obstacle spawn
        spawnY = 0;
    }

    /*
    Instantiates this gameObject. Overrides the default Spawn() method from StandardObstacle
    */
    public override void Spawn()
    {
        // Set centered height
        Vector3 spawnPos = new Vector3(spawnX, spawnY, 0);

        Instantiate(gameObject, spawnPos, Quaternion.identity);
    }
}