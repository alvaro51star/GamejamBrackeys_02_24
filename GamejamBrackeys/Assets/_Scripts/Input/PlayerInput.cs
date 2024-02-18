using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private UIManager uiManager;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(!uiManager.pauseMenu.activeSelf)
            {
                uiManager.PauseMenu();                
            }
            else
            {
                uiManager.Resume();
            }
        }
    }
}
