using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneFeedback : MonoBehaviour
{
    private bool recievingCall;//comprobante por si acasp
    [SerializeField] private GameObject ringingLightGO;
    [SerializeField] private AudioSource loopAudioSource;

    private void Start()
    {
        EventManager.PhoneRinging?.Invoke();//provisional, deberia invocarlo la puerta       
    }

    private void OnEnable()
    {
        EventManager.PhoneRinging += OnPhoneRinging;
        EventManager.Call += OnCall;
        EventManager.Call2 += OnCall2;
        EventManager.Resume += OnResume;
        EventManager.Pause += OnPause;
    }


    private void OnDisable()
    {
        EventManager.PhoneRinging -= OnPhoneRinging;
        EventManager.Call -= OnCall;
        EventManager.Call2 -= OnCall2;
        EventManager.Resume -= OnResume;
        EventManager.Pause -= OnPause;
    }

    private void OnPhoneRinging()
    {
        Debug.Log("Esta sonando el telefono");
        recievingCall = true;

        if (recievingCall)
        {
            ringingLightGO.SetActive(true);//aqui meteriamos la animacion o lo que sea de la luz
            loopAudioSource.Play();
        }
    }

    private void OnCall()
    {
        recievingCall = false;

        ringingLightGO.SetActive(false);//aqui meteriamos la animacion o lo que sea de la luz
        loopAudioSource.Stop();
    }
    private void OnCall2()
    {
        loopAudioSource.Stop();
    }

    private void OnResume()
    {
        if(recievingCall)
        {
            loopAudioSource.Play();
        }
    }

    private void OnPause()
    {
        if(recievingCall)
        {
            loopAudioSource.Stop();
        }
    }
}
