using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Defines the behaviour of collectible objects when collected.
*/
public class Collectible : MonoBehaviour
{
    /* Score value assigned to this collectible
    */
    public int value;

    /* Stores a reference to this object's mesh renderer
    */
    private MeshRenderer mesh;
    
    /* Stores a reference to the player object that can trigger collection
    */
    private GameObject player;

    /*
    Initialize mesh renderer
    */
    void Start()
    {
        player = GameObject.Find("HotAirBalloon");
        if (player == null)
        {
            Debug.LogError("Player/HotAirBalloon object not found!");
        }
        mesh = GetComponent<MeshRenderer>();
        mesh.enabled = true;
    }

    /*
    Handles collisions with the player object and increments the score by this collectible's value.
    Hides collectible on collision.
    */
    private void OnTriggerEnter(Collider collisionInfo)
    {
        if (collisionInfo.gameObject.name == player.name)
        {
            ScoreTracker st = collisionInfo.gameObject.GetComponent<ScoreTracker>();
            if (st != null)
            {
                Debug.Log("Collision between " + collisionInfo.gameObject.name + " and " + gameObject.name);
                st.IncrementScore(value);
                mesh.enabled = false;
            } else {
                Debug.LogError("ScoreTracker for " + collisionInfo.gameObject.name + " is null!");    
            }
        }
    }
}
