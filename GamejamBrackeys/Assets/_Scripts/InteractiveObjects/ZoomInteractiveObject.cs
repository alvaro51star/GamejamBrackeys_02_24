using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomInteractiveObject : InteractiveObject
{
    [SerializeField] private GameObject m_UIObject;
    protected override void Action()
    {
        m_UIObject.SetActive(true);
    }
}
