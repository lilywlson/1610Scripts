using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private int sceneToLoad;

    public void StartGame()
    {
        SceneManager.LoadScene(sceneToLoad); // index scene to load
        Debug.Log("New Game Begun!");
    }

    public void QuitGame()
    {
        Application.Quit(); // quits game
        Debug.Log("You Have Quit The Game, Goodbye!");
    }
}
