using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhoneManager : MonoBehaviour
{
    [SerializeField] private GameObject exitPanel;
    [SerializeField] private AudioClip answerAudioClip;
    [SerializeField] private GameObject phoneLight;
    [SerializeField] private GameObject buttonLight;
    [SerializeField] private Button doorButton;

    private void OnEnable()
    {
        EventManager.PhoneRinging += OnPhoneRinging;
        EventManager.CallEnded += OnCallEnded;
    }
    private void OnDisable()
    {
        EventManager.PhoneRinging -= OnPhoneRinging;
        EventManager.CallEnded -= OnCallEnded;
    }

    private void OnPhoneRinging()
    {
        phoneLight.SetActive(true);
        buttonLight.SetActive(true);
        doorButton.enabled = true;
    }

    private void OnCallEnded()
    {
        phoneLight.SetActive(false);
        buttonLight.SetActive(false);
        doorButton.enabled = false;
    }

    public void DoorButton()
    {
        Debug.Log("Empezar conversacion con el de fuera");
        EventManager.Call?.Invoke();        //empieza conversacion
        exitPanel.SetActive(false);
        SoundManager.instance.ReproduceSound(answerAudioClip);
        DialogueManager.instance.EnterDialogueMode(true);
    }

    public void IndoorButton()
    {
        Debug.Log("Empezar conversacion con el de dentro");
        EventManager.Call2?.Invoke();        //empieza conversacion
        DialogueManager.instance.EnterDialogueMode(false);
        exitPanel.SetActive(false);
        SoundManager.instance.ReproduceSound(answerAudioClip);
    }

}
