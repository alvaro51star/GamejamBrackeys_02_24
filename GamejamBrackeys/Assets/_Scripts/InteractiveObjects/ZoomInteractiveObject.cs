using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomInteractiveObject : InteractiveObject
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] protected GameObject m_UIObject;
    protected override void Action()
    {
        DialogueManager.instance.m_isViewClear = false;
        m_UIObject.SetActive(true);
        audioSource.Play();
    }
}
