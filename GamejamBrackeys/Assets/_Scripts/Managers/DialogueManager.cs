using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    //Variables
    public static DialogueManager instance;

    private Story m_currentStory;
    private bool m_dialogueIsPlaying;
    private LogManager m_logManager;
    private int m_numChoices;

    [SerializeField] private string[] m_characterNames;

    //Constants
    private const string LETTHROUGH_TAG = "pasar";


    //Trial
    public TextAsset JSON;

    private void Awake()
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
        m_logManager = new LogManager();
    }

    private void Update()
    {
        if (!m_dialogueIsPlaying)
            return;
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Return)) && m_numChoices == 0) //cambiar el input
            ContinueDialogue();

    }

    public void EnterDialogueMode()
    {

        m_currentStory = new Story(DoorManager.instance.personAtTheDoor._dialogueText.text);
        m_currentStory?.BindExternalFunction("getName", () => {
            return m_characterNames[Random.Range(0, m_characterNames.Length)];
        });
        m_dialogueIsPlaying = true;
        UIManager.instance.DialogueSwitchMode(true);
        //FeedbacksPuerta
        DoorManager.instance.StartDialogue();

        ContinueDialogue();
    }

    //public void EnterDialogueMode(TextAsset inkJSON)
    //{
    //    m_currentStory = new Story(inkJSON.text);
    //    m_dialogueIsPlaying = true;
    //    UIManager.instance.DialogueSwitchMode(true);
    //
    //    ContinueDialogue();
    //}

    public void ExitDialogueMode()
    {
        m_currentStory.UnbindExternalFunction("getName");
        m_dialogueIsPlaying = false;
        UIManager.instance.DialogueSwitchMode(false);
        UIManager.instance.DialogueChangeText("");
        DoorManager.instance.EndDialogue();
        EventManager.CallEnded?.Invoke();
    }

    private void ContinueDialogue()
    {
        if (m_currentStory.canContinue)
        {
            string nextDialogue = m_currentStory.Continue();
            CheckChoices();
            HandleTags(m_currentStory.currentTags);
            m_logManager.AddText(nextDialogue);
            UIManager.instance.DialogueChangeText(nextDialogue);
            UIManager.instance.LogChat(m_logManager.GetLogText());
        }
        else
            ExitDialogueMode();
    }

    private void CheckChoices()
    {
        List<Choice> currentChoices = m_currentStory.currentChoices;
        m_numChoices = currentChoices.Count;
        int index = 0;

        foreach (Choice choice in currentChoices)
        {
            UIManager.instance.SwitchActiveChoices(true, index);
            UIManager.instance.ChangeChoiceText(currentChoices[index].text, index);
            index++;
        }

        int choicesLength = UIManager.instance.GetChoicesLength();
        for (int j = index; j < choicesLength; j++)
        {
            UIManager.instance.SwitchActiveChoices(false, j);
        }
    }

    public void MakeChoice(int choiceIndex)
    {
        m_currentStory.ChooseChoiceIndex(choiceIndex);
        m_numChoices = 0;
        ContinueDialogue();
    }

    private void HandleTags(List<string> currentsTags)
    {
        foreach (string tag in currentsTags)
        {
            string[] splitTag = tag.Split(":");
            string tagKey = splitTag[0].Trim();
            string tagValue = splitTag[1].Trim();

            switch (tagKey) //switch para en el futuro poner mas
            {
                case LETTHROUGH_TAG:
                    if (tagValue == "yes")
                    {
                        DoorManager.instance.isAccepted = true;
                    }
                    else if (tagValue == "no")
                    {
                        DoorManager.instance.isAccepted = false;
                    }
                    break;
            }
        }
    }

}
