using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    GameManager gm;

    private void Start()
    {
        gm = GameObject.FindGameObjectWithTag("gm").GetComponent<GameManager>();
    }

    public void Startgame()
    {
        gm.lastCheckpoint = new Vector2(-19.7257f, 1.746318f);
        SceneManager.LoadScene("Dungeon1");
    }
    public void Credit()
    {
        SceneManager.LoadScene("Credit");
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void Back()
    {
        SceneManager.LoadScene("Menu");
    }
}
