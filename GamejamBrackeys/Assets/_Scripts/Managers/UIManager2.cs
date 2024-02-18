using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager2 : MonoBehaviour
{
    public GameObject pauseMenu;
    [SerializeField] private Button doorButton;

    private void Update()
    {
        if (DoorManager.instance.personAtTheDoor == null)
        {
            doorButton.enabled = false;
        }
        else
        {
            doorButton.enabled = true;
        }
    }

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
