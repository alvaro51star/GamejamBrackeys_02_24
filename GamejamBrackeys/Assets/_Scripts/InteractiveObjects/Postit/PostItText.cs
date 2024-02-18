using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PostItText : MonoBehaviour
{
    [SerializeField] private TMP_Text postItText;

    public void ChangeText(string text)//llamar en otra parte cuando OnCall2
    {
        postItText.text = text;
    }
}
