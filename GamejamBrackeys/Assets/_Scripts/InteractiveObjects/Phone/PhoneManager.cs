using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneManager : MonoBehaviour
{
    [SerializeField] private GameObject exitPanel;
    [SerializeField] private AudioClip answerAudioClip;
    public void DoorButton()
    {
        Debug.Log("Empezar conversacion con el de fuera");
        EventManager.Call?.Invoke();        //empieza conversacion
        exitPanel.SetActive(false);
        SoundManager.instance.ReproduceSound(answerAudioClip);
    }

    public void IndoorButton()
    {
        Debug.Log("Empezar conversacion con el de dentro");
        EventManager.Call2?.Invoke();        //empieza conversacion
        exitPanel.SetActive(false);
        SoundManager.instance.ReproduceSound(answerAudioClip);
    }

}
