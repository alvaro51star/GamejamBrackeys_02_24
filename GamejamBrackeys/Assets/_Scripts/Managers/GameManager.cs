using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int badPeopleIn = 0;
    public int goodPeopleOut = 0;
    public int totalErrors = 0;
    //[SerializeField] private int maxPeople = 10;


    private void Awake()
    {
        if (instance != null && instance != this)
            Destroy(this);
        else
            instance = this;

        DontDestroyOnLoad(instance);
    }

    public void AddBadPeopleIn()
    {
        badPeopleIn++;
        totalErrors++;
    }

    public void AddGoodPeopleOut()
    {
        goodPeopleOut++;
        totalErrors++;
    }

    public void BackToMainMenu()
    {
        Initiate.Fade("MainMenu", Color.black, 1f);
    }

    public void GameOver()
    {
        switch (totalErrors)
        {
            case 0:
                Initiate.Fade("0Errors_FinalScene", Color.black, 1f);
                break;
            case 1:
                Initiate.Fade("1Errors_FinalScene", Color.black, 1f);
                break;
            case 2:
                Initiate.Fade("2Errors_FinalScene", Color.black, 1f);
                break;
            default:
                Initiate.Fade("Failed_FinalScene", Color.black, 1f);
                break;
        }

        //LLevar al usuario a la escena correspondiente
    }
}
