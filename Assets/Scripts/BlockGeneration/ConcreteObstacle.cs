using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Defines the behavior of a basic obstacle.
TODO: Obstacles with more complex behaviors should be sibling classes to this one
*/
public class ConcreteObstacle : BaseObstacle
{
    /* Array of prefabs for all coin patterns that are compatible with this obstacle type
    */
    public GameObject[] validCoinPatternPrefabs;

    /*
    Instantiates this gameObject
    */
    public override void Spawn()
    {
        Instantiate(gameObject, transform.position, Quaternion.identity);
    }

    /*
    Returns a random coin pattern decorator that is compatible with this base obstacle
    */
    public override GameObject GetRandomCoinPattern()
    {
        return validCoinPatternPrefabs[0];
    }
}