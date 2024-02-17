using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private GameObject creditsGO;

    public void StartGame()
    {
        var nextScene = SceneManager.GetSceneByBuildIndex(1);
        var nextSceneName = nextScene.name;

        Initiate.Fade(nextSceneName, Color.black, 10);
        SceneManager.LoadScene(1);//game scene
    }

    public void Credits()
    {
        StartCoroutine(ActivateGOAfterTimer(creditsGO));
    }

    public void Exit()
    {
        Application.Quit();
    }

    private IEnumerator ActivateGOAfterTimer(GameObject goToActivate)
    {
        yield return new WaitForSeconds(0.2f);
        goToActivate.SetActive(true);
    }
}
