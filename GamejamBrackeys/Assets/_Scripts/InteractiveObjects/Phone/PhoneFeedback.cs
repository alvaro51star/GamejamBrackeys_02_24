using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneFeedback : MonoBehaviour
{
    public bool recievingCall;//comprobante por si acasp
    [SerializeField] private GameObject ringingLightGO;

    private void Start()
    {
        EventManager.PhoneRinging?.Invoke();//provisional, deberia invoarlo la puerta       
    }

    private void OnEnable()
    {
        EventManager.PhoneRinging += OnPhoneRinging;
        EventManager.Call += OnCall;
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
        }
    }

    private void OnCall()
    {
        recievingCall = false;
    }    
}
