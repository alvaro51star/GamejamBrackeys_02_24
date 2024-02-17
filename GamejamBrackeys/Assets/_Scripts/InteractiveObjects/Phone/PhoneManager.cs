using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneManager : MonoBehaviour
{
    public void DoorButton()
    {
        Debug.Log("Empezar conversacion con el de fuera");
        EventManager.Call?.Invoke();
        //empieza conversacion
        gameObject.SetActive(false);
    }

    public void IndoorButton()
    {
        Debug.Log("Empezar conversacion con el de dentro");
        EventManager.Call2?.Invoke();
        //empieza conversacion
        gameObject.SetActive(false);
    }
    
}
