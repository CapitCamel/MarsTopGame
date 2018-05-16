 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Xml.Linq;

public class LoadScript : MonoBehaviour {

    public GameHalper gh;

    private void Start()
    {
        gh = GetComponent<GameHalper>();
    }

    public void NewGame()
    {
        gh.CreateNewGame();

    }

    public void LoadGame()
    {
        SceneManager.LoadScene(1);
    }

    public void Menu()
    {
        SceneManager.LoadScene(0);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
