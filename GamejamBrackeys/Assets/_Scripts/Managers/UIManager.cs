using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Ink.Runtime;

public class UIManager : MonoBehaviour
{
    //Variables
    public static UIManager instance;

    [Header("UI GameObjects")]
    public GameObject pauseMenu;

    [Header("Dialogue UI")]
    [SerializeField] private GameObject m_dialoguePanel;
    [SerializeField] private TextMeshProUGUI m_dialogueText;
    [SerializeField] private TextMeshProUGUI m_logText;

    [Header("CHoices UI")]
    [SerializeField] private GameObject[] m_choices;
    [SerializeField] private TextMeshProUGUI[] m_choiceTexts;

    [Header("PostIt")]
    [SerializeField] private TMP_Text postItText;
    private int m_postItCounter = 0;

    private void Awake() //set singleton 
    {
        if (instance != null)
        {
            Destroy(this);
        }
        else
            instance = this;
    }

    private void Start()
    {
        InitializeChoices();
    }


    #region Dialogue

    public void DialogueSwitchMode(bool mode)
    {
        m_dialoguePanel.SetActive(mode);
    }

    public void DialogueChangeText(string text)
    {
        m_dialogueText.text = text;
    }

    public void LogChat(string text)
    {
        m_logText.text = text;
    }

    
    //Choices
    private void InitializeChoices()
    {
        m_choiceTexts = new TextMeshProUGUI[m_choices.Length];
        for (int i = 0; i < m_choices.Length; i++)
        {
            m_choiceTexts[i] = m_choices[i].GetComponentInChildren<TextMeshProUGUI>();
        }
    }

    public void ChangeChoiceText(string choiceText, int index)
    {
        m_choiceTexts[index].text = choiceText;
    }

    public void SwitchActiveChoices(bool mode, int index)
    {
        m_choices[index].SetActive(mode);
    }

    public void DisplayChoices(Story currentStory)
    {
        List<Choice> currentChoices = currentStory.currentChoices;
        int index = 0;

        foreach (Choice choice in currentChoices)
        {
            m_choices[index].SetActive(true);
            m_choiceTexts[index].text = currentChoices[index].text;
            index++;
        }

        for (int j = index; j < m_choices.Length; j++)
        {
            Debug.Log("Jaja");
            m_choices[j].SetActive(false);
        }
    }

    public int GetChoicesLength()
    {
        return m_choices.Length;
    }

    #endregion   



    public void ChangePostItText(string text)//llamar en otra parte cuando OnCall2
    {
        postItText.text = text;
    }

    public int GetPostItCounter()
    {
        return m_postItCounter;
    }

    public void ChangePostItCounter(int counter)
    {
        m_postItCounter = counter;
    }

    //pause menu
    public void Resume()
    {
        EventManager.Resume?.Invoke();

        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void PauseMenu()
    {
        EventManager.Pause?.Invoke();

        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }
}
