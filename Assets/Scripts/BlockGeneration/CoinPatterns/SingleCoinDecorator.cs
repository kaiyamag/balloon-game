using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 
SingleCoinDecorator.cs
Kaiya Magnuson 2024

Basic concrete decorator class. Decorates a BaseBlock with a single coin pattern
*/
public class SingleCoinDecorator : ObstacleDecorator
{
    /*
    Instantiates this coin prefab in this class's pattern from a given starting position
    */
    public override void SpawnPatternFromPos(Vector3 pos) 
    {
        Debug.Log("Spawn single coin starting at " + pos);
        Instantiate(gameObject, pos, Quaternion.identity);
    }
}
