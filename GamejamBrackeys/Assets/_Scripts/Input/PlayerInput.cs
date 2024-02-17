using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private UIManager uiManager;
    [SerializeField] private UIManager2 uiManager2;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(!uiManager2.pauseMenu.activeSelf)
            {
                uiManager2.PauseMenu();                
            }
            else
            {
                uiManager2.Resume();
            }
        }
    }
}
