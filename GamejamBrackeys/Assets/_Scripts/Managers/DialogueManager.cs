using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;
using UnityEngine.UI;


public enum DialogueOrigin
{
    Puerta, Telefonillo
}

public class DialogueManager : MonoBehaviour
{
    //Variables
    public static DialogueManager instance;

    private Story m_currentStory;
    private bool m_dialogueIsPlaying;
    private LogManager m_logManager;
    private int m_numChoices;
    private bool m_isPuerta;

    [SerializeField] private string[] m_characterNames;

    //Constants
    private const string LETTHROUGH_TAG = "pasar";
    private const string POSTIT_TAG = "postIt";
    private const string PLUSTRIES_TAG = "plusTries";
    private const string SPEAKER_TAG = "plusTries";


    //Trial
    public TextAsset m_telefonilloDialogo;

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

    public void EnterDialogueMode(bool isPuerta)
    {
        m_isPuerta = isPuerta;
        if (m_isPuerta)
        {
            m_currentStory = new Story(DoorManager.instance.personAtTheDoor._dialogueText.text);
            DoorManager.instance.StartDialogue();
        }
        else
        {
            m_currentStory = new Story(m_telefonilloDialogo.text);
        }
        m_currentStory?.BindExternalFunction("getName", () => {
            return m_characterNames[Random.Range(0, m_characterNames.Length)];
        });
        m_currentStory?.BindExternalFunction("getNumberOfTries", () => {
            return UIManager.instance.GetPostItCounter();
        });
        m_currentStory?.BindExternalFunction("getNumberOfBadGuysInside", () => {
            return GameManager.instance.badPeopleIn;
        });
        m_dialogueIsPlaying = true;
        UIManager.instance.DialogueSwitchMode(true);
        //FeedbacksPuerta

        ContinueDialogue();
    }

    public void ExitDialogueMode()
    {
        m_currentStory.UnbindExternalFunction("getName");
        m_currentStory.UnbindExternalFunction("getNumberOfTries");
        m_currentStory.UnbindExternalFunction("getNumberOfBadGuysInside");
        m_dialogueIsPlaying = false;
        UIManager.instance.DialogueSwitchMode(false);
        UIManager.instance.DialogueChangeText("");
        EventManager.CallEnded?.Invoke();
        if (m_isPuerta)
        {
            DoorManager.instance.EndDialogue();
        }
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

                case POSTIT_TAG:
                    UIManager.instance.ChangePostItText(tagValue);
                    break;
                //case PLUSTRIES_TAG:
                //    EventManager.Call2?.Invoke();
                //    break;
                //case SPEAKER_TAG:

            }
        }
    }

}
