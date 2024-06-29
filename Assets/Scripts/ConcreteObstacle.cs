using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Defines the behavior of a basic obstacle.
TODO: Obstacles with more complex behaviors should be sibling classes to this one
*/
public class ConcreteObstacle : BaseObstacle
{
    /*
    Instantiates this gameObject
    */
    public override void Spawn()
    {
        Instantiate(/*obstaclePrefab*/ gameObject, transform.position, Quaternion.identity);
        Debug.Log("Spawned base obstacle");
    }
}