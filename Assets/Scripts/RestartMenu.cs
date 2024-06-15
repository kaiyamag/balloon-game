using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
RestartMenu.cs
Kaiya Magnuson, 06/2024

Contains functionality for all buttons on the restart menu UI canvas
*/
public class RestartMenu : MonoBehaviour
{
    /*
    Reloads the current level
    */
    public void restartLevel() {
        Debug.Log("Reloading level " + SceneManager.GetActiveScene().name);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);     // Gets and loads current level
    }
}
