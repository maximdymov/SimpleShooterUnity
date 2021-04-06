using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public void StartNewGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void LoadGame()
    {

    }

    public void ExitGame()
    {
        SaveGame();
        Application.Quit();
    }

    private void SaveGame()
    {

    }
}
