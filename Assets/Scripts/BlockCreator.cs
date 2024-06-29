using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Manages the spawn cycle of random blocks (Randomizes block components and controls spawn loop)
*/
public class BlockCreator : MonoBehaviour
{
     /* Reference to the obstacle(s) that can form the base of a block. Obstacles
     must have the ConcreteObstacle.cs script.
    */
    public GameObject obstaclePrefab; 

    /* Reference to the coin patterns(s) that can decorate a block. Coin Pptterns
     must have the ObstacleDecorator.cs script.
    */ 
    public GameObject decoratorPrefab; 

    /* Stores a reference to this object's BlockDriver.cs script
    */
    private BlockDriver blockDriver;
    private float startDelay = 0;       // Time in seconds before starting spawn loop
    private float spawnInterval = 2;    // Time in seconds between each block spawn

    void Start()
    {
        blockDriver = GetComponent<BlockDriver>();
        StartInvoke();
    }
    /* Spawns a block with a set obstacle and coin pattern
    */
    void SpawnBlock()
    {
        // Get a constructed block from the given obstacle and coin pattern prefabs
        BaseObstacle newBlock = blockDriver.ConstructBlock(obstaclePrefab, decoratorPrefab);
        newBlock.Spawn();
    }

    /* Calls the SpawnBlock() method on repeat
    */
    void StartInvoke() {
        InvokeRepeating("SpawnBlock", startDelay, spawnInterval);

        //InvokeRepeating("GetRandObstacle", 0, 0.2f); 
    }
}

