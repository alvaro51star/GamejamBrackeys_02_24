using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitInteractive : InteractiveObject
{    
    protected override void Action()
    {
        gameObject.SetActive(false);
    }
}
