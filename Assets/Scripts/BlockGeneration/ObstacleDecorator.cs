using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
ObstacleDecorator.cs
Kaiya Magnuson 2024

Abstract parent class for all block decorators (coin patterns). Contains properties
and methods shared by all coin patterns, and the abstract method SpawnPatternFromPos(Vector3)
that all child classes must implement
*/
public abstract class ObstacleDecorator : BaseBlock
{
    /* A block consisting of one obstacle base and any number of coin pattern decorators
    */
    protected BaseBlock baseObstacle;

    /* The GameObject to spawn as a collectible
    */
    public GameObject coin; 

    /* Container for all variables related to obstacle spawn position
    */
    protected ObstacleInfo obsInfo;
    protected Vector3 spawnPos;     // Stores calculated obstacle spawn position in world space

    /*
    Replacement constructor for MonoBehaviours. Must be called upon Instantiating
    an ObstacleDecorator. Initializes the base obstacle.
    */
    public void Init(BaseBlock obstacle)
    {
        this.baseObstacle = obstacle;
    }

    /*
    Instantiates the gameObject tied to this BaseBlock child class and instantiates
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
        obsInfo = baseObstacle.GetObstacleInfo();

        // Check for uninitialized base info
        if (obsInfo == null) {
            Debug.LogError("Obstacle info is null");
        }

        int obsID = obsInfo.id;
        float spawnX, spawnY, offset;
        spawnPos = transform.position;

        // Set single coin spawn position based on base obstacle type and retrieved obstacle info
        switch(obsID) {
            // Empty Obstacle
            case 0:
                offset = obsInfo.offset;
                spawnX = obsInfo.spawnX;
                spawnY = obsInfo.spawnY;
                spawnPos = new Vector3(spawnX, spawnY, 0);
                break;
                
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
                Debug.LogError("Unexpected obstacle ID " + obsID + " in ObstacleDecorator.cs");
                break;
        } 
        
        // Decorate existing block by instantiating this coin pattern
        SpawnPatternFromPos(spawnPos, coin);
    }

    /*
    Instantiates this coin prefab in this class's pattern from a given starting position
    */
    public abstract void SpawnPatternFromPos(Vector3 pos, GameObject coin);

     /*
    PLACEHOLDER: This method should not be called from a decorator class, but is
    necessary to conform to BaseBlock. Returns a list of obstacle info
    */
    public override ObstacleInfo GetObstacleInfo()
    {
        return baseObstacle.GetObstacleInfo();
    }
    
}
