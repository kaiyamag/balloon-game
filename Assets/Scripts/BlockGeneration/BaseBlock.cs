using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 
BaseBlock.cs
Kaiya Magnuson 2024

Abstract parent class defining the behaviour of a base obstacle (e.g., the
overarching object type of any base or decorated block). Child classes of BaseBlock
define the behavior of unique, concrete obstacles.
*/
public abstract class BaseBlock : MonoBehaviour
{
    /*
    Instantiates the gameObject tied to this BaseBlock child class
    */
    public abstract void Spawn();

    /*
    Returns a list of obstacle info
    */
    public abstract ObstacleInfo GetObstacleInfo();
}
