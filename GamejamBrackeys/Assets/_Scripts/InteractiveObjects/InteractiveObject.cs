using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Collider2D))]
public class InteractiveObject : MonoBehaviour, IEventClick
{
    public void OnPointerDown(PointerEventData eventData)
    {
        Action();
    }

    public void OnPointerUp(PointerEventData eventData)
    {

    }

    public void OnPointerClick(PointerEventData eventData)
    {

    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        //DialogueManager.instance.m_isViewClear = false;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //DialogueManager.instance.m_isViewClear = true;
    }

    protected virtual void Action()
    {

    }
}
