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

    /* Reference to the coin patterns(s) that can decorate a block. Coin Pptterns
     must have the ObstacleDecorator.cs script.
    */ 
    public GameObject[] decoratorPrefabs; 

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
        
        int obstacleIndex = GetRandWeightedIndex(obstacleWeights);  // PLACEHOLDER
        GameObject randObstacle = obstaclePrefabs[obstacleIndex];
        GameObject randCoinPattern = randObstacle.GetComponent<BaseObstacle>().GetRandomCoinPattern();

        int decoratorIndex = 0; // PLACEHOLDER

        // Get a constructed block from the given obstacle and coin pattern prefabs
        BaseObstacle newBlock = blockDriver.ConstructBlock(obstaclePrefabs[obstacleIndex], decoratorPrefabs[decoratorIndex]);
        newBlock.Spawn();
    }

    /* Calls the SpawnBlock() method on repeat
    */
    void StartInvoke() {
        InvokeRepeating("SpawnBlock", startDelay, spawnInterval);
    }

    /*
    Returns the index of an array given a corresponding array of percentage chances that
    a given index is selected.
    */
    private int GetRandWeightedIndex(float[] weights)
    {
        int result = -1;    // TODO: Maybe change this to a usable index just in case
        int x = Random.Range(0, 100);     // Random is exclusive on the last bound
        float lowerBound = 0;
        //Debug.Log("-- Starting random. x = " + x);
        for (int i = 0; i < weights.Length; i++) {
            //Debug.Log("-- Comparing obstacleWeights[" + i + "] = " + obstacleWeights[i] + ", lowerBound = " + lowerBound);
            if (x < weights[i] + lowerBound) {
                //Debug.Log("--result = " + i);
                //testTally[result] = testTally[result] + 1;
                //PrintArray(testTally);
                result = i;
                return result;
            }

            lowerBound += weights[i];
        }
        //testTally[result] = testTally[result] + 1;
        //Debug.Log("Done, result = " + result);
        //PrintArray(testTally);
        return result;
    }
}

