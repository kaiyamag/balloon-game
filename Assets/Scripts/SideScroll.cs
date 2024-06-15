using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
SpawnManager.cs
Kaiya Magnuson 2024

Manages the side-scrolling movement of obstacles.
*/
public class SideScroll : MonoBehaviour
{
    public GameObject gameManager;      // Reference to game manager object
    private float speed;                // Gets current scroll speed
    private HashSet<GameObject> touchingObjects = new HashSet<GameObject>();    // List of objects touching this object
    private float priorSpeed;           // Placeholder for game manager speed

    void Start()
    {
        gameManager = GameObject.Find("GameManager");
    }

    void Update()
    {
        // Get current speed
        speed = gameManager.GetComponent<GameManager>().scrollSpeed;

        // Move object
        transform.Translate(-1 * transform.right * Time.deltaTime * speed);

    }

    /*
    Updates list of objects touching this object when a collision starts
    */
    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.name == "HotAirBalloon") {
            touchingObjects.Add(collision.gameObject);
            Debug.Log("Collision Enter -- HotAirBalloon");
        }
    }

    /*
    Updates list of objects touching this object when a collision ends
    */
    private void OnCollisionExit(Collision collision) {
        if (collision.gameObject.name == "HotAirBalloon") {
            touchingObjects.Remove(collision.gameObject);
            Debug.Log("Collision Exit -- HotAirBalloon");
        }
    }
}
