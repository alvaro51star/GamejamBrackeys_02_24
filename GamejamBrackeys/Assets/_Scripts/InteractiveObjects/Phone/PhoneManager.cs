using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneManager : MonoBehaviour
{
    public GameObject phoneUILightGO;
    public void DoorButton()
    {
        Debug.Log("Empezar conversacion con el de fuera");
        EventManager.Call?.Invoke();
        //empieza conversacion
        phoneUILightGO.SetActive(false);   
        gameObject.SetActive(false);
    }

    public void IndoorButton()
    {
        Debug.Log("Empezar conversacion con el de dentro");
        EventManager.Call?.Invoke();
        //empieza conversacion
        gameObject.SetActive(false);
    }
    
}
