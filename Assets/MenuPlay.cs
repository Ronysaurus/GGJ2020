using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPlay : MonoBehaviour
{

    public void Jugar()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void GGJ()
    {
        Application.OpenURL("https://globalgamejam.org/2020/games/unnamed-tower-defense-game-1");
    }

    public void Credits()
    {
        SceneManager.LoadScene(2);
    }

    public void ToggleScreen()
    {
        Screen.fullScreen = !Screen.fullScreen;
    }

}
