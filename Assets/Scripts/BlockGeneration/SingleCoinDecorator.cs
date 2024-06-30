using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Basic concrete decorator class. Decorates a BaseObstacle with a single coin pattern
*/
public class SingleCoinDecorator : ObstacleDecorator
{
    /*
    Instantiates this coin prefab in this class's pattern from a given starting position
    */
    public override void SpawnPatternFromPos(Vector3 pos) 
    {
        Instantiate(gameObject, pos, Quaternion.identity);
    }
}
