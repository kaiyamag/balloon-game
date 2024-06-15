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
    private float speed;    // Gets current scroll speed
    private HashSet<GameObject> touchingObjects = new HashSet<GameObject>();    // List of objects touching this object
    private float priorSpeed;   // Placeholder for game manager speed

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
    }

    // Update is called once per frame
    void Update()
    {
        // Get current speed
        //speed = gameManager.GetComponent<GameManager>().scrollSpeed;
        // Move object
        transform.Translate(-1 * transform.right * Time.deltaTime * speed);

    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.name == "HotAirBalloon") {
            touchingObjects.Add(collision.gameObject);

            // Set speed to 0
            // priorSpeed = gameManager.GetComponent<GameManager>().scrollSpeed;
            // gameManager.GetComponent<GameManager>().scrollSpeed = 0;

            Debug.Log("Collision Enter -- HotAirBalloon");
        }
    }

    private void OnCollisionExit(Collision collision) {
        if (collision.gameObject.name == "HotAirBalloon") {
            touchingObjects.Remove(collision.gameObject);

            // Set speed to 0
            // gameManager.GetComponent<GameManager>().scrollSpeed = priorSpeed;

            Debug.Log("Collision Exit -- HotAirBalloon");
        }
    }
}
