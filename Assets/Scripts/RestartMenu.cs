using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class RestartMenu : MonoBehaviour
{
    /*
    Reloads the current level
    */
    public void restartLevel() {
        Debug.Log("Reloading level " + SceneManager.GetActiveScene().name);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Gets and loads current level
    }
}
