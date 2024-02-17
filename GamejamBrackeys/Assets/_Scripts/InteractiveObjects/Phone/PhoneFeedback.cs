using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneFeedback : MonoBehaviour
{
    private bool recievingCall;//comprobante por si acasp
    [SerializeField] private GameObject ringingLightGO;
    [SerializeField] private PhoneZoomInteractiveObject phoneIntObjScript;
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
    }


    private void OnDisable()
    {
        EventManager.PhoneRinging -= OnPhoneRinging;
        EventManager.Call -= OnCall;
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

}
