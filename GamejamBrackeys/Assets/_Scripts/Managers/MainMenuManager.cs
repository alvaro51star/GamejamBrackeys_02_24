using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private GameObject creditsGO;

    public void StartGame()
    {
        SceneManager.LoadScene(1);//game scene
    }

    public void Exit()
    {
        Application.Quit();
    }
}
