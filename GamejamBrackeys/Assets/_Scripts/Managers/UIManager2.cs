using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager2 : MonoBehaviour
{
    public GameObject pauseMenu;

    //pause menu
    public void Resume()
    {
        EventManager.Resume?.Invoke();

        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }
    public void PauseMenu()
    {
        EventManager.Pause?.Invoke();

        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    } 
}
