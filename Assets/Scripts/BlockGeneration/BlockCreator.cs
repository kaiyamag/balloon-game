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
    public GameObject[] obstaclePrefabs; 

    /* Stores a reference to this object's BlockDriver.cs script
    */
    private BlockDriver blockDriver;

    /* Stores percentage chance of generating the corresponding obstacle in the `obstaclePrefabs` array
    `obstacleWeights` and `obstaclePrefabs` must be the same length. All weights in this array should
    sum to 100.
    */
    public float[] obstacleWeights;  
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
        
        int obstacleIndex = Utils.GetRandWeightedIndex(obstacleWeights);  // PLACEHOLDER
        GameObject randObstacle = obstaclePrefabs[obstacleIndex];
        GameObject randCoinPattern = randObstacle.GetComponent<BaseObstacle>().GetRandomCoinPattern();

        // Get a constructed block from the given obstacle and coin pattern prefabs
        BaseObstacle newBlock = blockDriver.ConstructBlock(obstaclePrefabs[obstacleIndex]/*, decoratorPrefabs[decoratorIndex]*/);
        newBlock.Spawn();
    }

    /* Calls the SpawnBlock() method on repeat
    */
    void StartInvoke() {
        InvokeRepeating("SpawnBlock", startDelay, spawnInterval);
    }
}

