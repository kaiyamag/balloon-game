using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// A concrete obstacle class
public class ConcreteObstacle : BaseObstacle
{
    //public GameObject obstaclePrefab; // Assign the prefab in the inspector

    public override void Spawn()
    {
        Instantiate(/*obstaclePrefab*/ gameObject, transform.position, Quaternion.identity);
        Debug.Log("Spawned base obstacle");
    }
}