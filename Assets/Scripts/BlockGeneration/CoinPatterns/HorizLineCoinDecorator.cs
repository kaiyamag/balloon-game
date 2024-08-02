using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 
HorizLineCoinDecorator.cs
Kaiya Magnuson 2024

Basic concrete decorator class. Decorates a BaseBlock with a single coin pattern
*/
public class HorizLineCoinDecorator : ObstacleDecorator
{
    
    private float coinSpacing = 0.75f;      // X distance between coins in a line
    private float horizCoinOffset = 2.5f;   // X offset distance to center horizontal lines in obstacles
    private int horizLineCount = 6;         // Number of coins in a horizontal line

    /*
    Instantiates this coin prefab in this class's pattern from a given starting position
    */
    public override void SpawnPatternFromPos(Vector3 pos, GameObject coin)
    {
        Debug.Log("Spawn horizontal line starting at " + pos);
        Vector3 tempPos = pos;
        tempPos.x += horizCoinOffset;
        for (int i = 0; i < horizLineCount; i++) {
            tempPos.x -= coinSpacing;
            Instantiate(coin, tempPos, Quaternion.identity);
        }
    }
}
