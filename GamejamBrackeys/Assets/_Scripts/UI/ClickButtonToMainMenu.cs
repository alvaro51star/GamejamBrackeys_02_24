using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickButtonToMainMenu : MonoBehaviour
{
    [SerializeField] private Button button;

    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(TaskOnClick);
    }

    private void TaskOnClick()
    {
        GameManager.instance.BackToMainMenu();
    }
}
