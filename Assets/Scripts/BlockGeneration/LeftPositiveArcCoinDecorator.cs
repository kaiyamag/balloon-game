using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Basic concrete decorator class. Decorates a BaseObstacle with a single coin pattern
*/
public class LeftPositiveArcCoinDecorator : ObstacleDecorator
{
    /* A block consisting of one obstacle base and any number of coin pattern decorators
    */
    protected BaseObstacle baseObstacle;

    private float coinSpacing = 0.75f;      // X distance between coins in a line
    private float horizCoinOffset = 2.5f;   // X offset distance to center horizontal lines in obstacles
    private int horizLineCount = 6;         // Number of coins in a horizontal line

    /*
    Replacement constructor for MonoBehaviours. Must be called upon Instantiating
    an ObstacleDecorator. Initializes the base obstacle.
    */
    public override void Init(BaseObstacle obstacle)
    {
        this.baseObstacle = obstacle;
    }

    /*
    Instantiates the gameObject tied to this BaseObstacle child class and instantiates
    a random compatible coin pattern.
    */
    public override void Spawn()
    {
        // Check for uniintialized base obstacle
        if (baseObstacle == null) {
            Debug.LogError("baseObstacle is null");
        }

        // Spawn the existing block
        baseObstacle.Spawn();

        // Get corresponding obstacle info from base obstacle
        ObstacleInfo obsInfo = baseObstacle.GetObstacleInfo();

        // Check for uninitialized base info
        if (obsInfo == null) {
            Debug.LogError("Obstacle info is null");
        }

        int obsID = obsInfo.id;
        float spawnX, spawnY, offset;
        Vector3 spawnPos = transform.position;

        // Set single coin spawn position based on base obstacle type and retrieved obstacle info
        switch(obsID) {
            // Split Obstacle
            case 2:
                offset = obsInfo.offset;
                spawnX = obsInfo.spawnX;
                spawnY = obsInfo.spawnY - offset;
                spawnPos = new Vector3(spawnX, spawnY, 0);
                break;
            
            // Center Obstacle
            case 3:
                spawnX = obsInfo.spawnX;
                offset = obsInfo.offset;
                int sign = 1;

                if (Random.Range(0, 100) < 50) {
                    sign = -1;
                }

                spawnY = sign * offset;
                spawnPos = new Vector3(spawnX, spawnY, 0);
                break;

            default:
                break;
        } 
        
        // Decorate existing block by instantiating this coin pattern
        Debug.Log("Spawn left positive arc starting at " + spawnPos);
            Vector3 tempPos = spawnPos;
            tempPos.x += horizCoinOffset;
            for (int i = 0; i < horizLineCount; i++) {
                tempPos.x -= coinSpacing;
                float steepness = 0.3f;     // Arc steepness
                tempPos.y = (float) System.Math.Pow(i * steepness, 2) + spawnPos.y;
                Instantiate(gameObject, tempPos, Quaternion.identity);
            }
    }

    /*
    PLACEHOLDER: This method should not be called from a decorator class, but is
    necessary to conform to BaseObstacle. Returns this gameObject
    */
    public override GameObject GetRandomCoinPattern() 
    {
        Debug.LogError("Inappropriate call of GetRandomCoinPattern from " + gameObject.name);
        return gameObject;
    }

     /*
    PLACEHOLDER: This method should not be called from a decorator class, but is
    necessary to conform to BaseObstacle. Returns a list of obstacle info
    */
    public override ObstacleInfo GetObstacleInfo()
    {
        return baseObstacle.GetObstacleInfo();
    }
}
