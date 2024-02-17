using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneZoomInteractiveObject : ZoomInteractiveObject
{
    public bool isInCall;

    private void OnEnable()
    {
        EventManager.Call += OnCall;
        EventManager.PhoneRinging += OnPhoneRinging;
    }
    private void OnDisable()
    {
        EventManager.Call += OnCall;
        EventManager.PhoneRinging += OnPhoneRinging;
    }

    private void OnCall()
    {
        isInCall = true;
    }

    private void OnPhoneRinging()
    {
        isInCall= false;
    }

    protected override void Action()
    {
        if(!isInCall)
        {
            base.Action();
        }
    }

}
