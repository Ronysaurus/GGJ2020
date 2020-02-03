using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Sc_GameOver : MonoBehaviour
{
    public void MainMenu()
    {
        Destroy(FindObjectOfType<Scr_Audio>().gameObject);
        SceneManager.LoadScene(0);
    }
}
