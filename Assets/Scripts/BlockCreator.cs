using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Another script that calls ConstructBlock from BlockDriver
public class BlockCreator : MonoBehaviour
{
    public GameObject blockPrefab; // Assign this prefab in the inspector
    public GameObject decoratorPrefab; // Assign this prefab in the inspector
    private BlockDriver blockDriver;
    private float startDelay = 0;
    private float spawnInterval = 2;

    void Start()
    {
        // Find the BlockDriver component on the GameObject
        // BlockDriver blockDriver = FindObjectOfType<BlockDriver>();
        blockDriver = GetComponent<BlockDriver>();
        
        StartInvoke();
    }

    void SpawnBlock()
    {
        // Call ConstructBlock and pass the prefab you want to instantiate
        BaseObstacle newBlock = blockDriver.ConstructBlock(blockPrefab, decoratorPrefab);

        // Now you have a new block with the base obstacle and decorations
        //ADDED
        newBlock.Spawn();
    }

    void StartInvoke() {
        InvokeRepeating("SpawnBlock", startDelay, spawnInterval);

        //InvokeRepeating("GetRandObstacle", 0, 0.2f); 
    }
}

