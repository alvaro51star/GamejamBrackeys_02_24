using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogManager : MonoBehaviour
{
    //Variables
    private string m_textContent = "";

    public void AddText(string newText)
    {
        m_textContent += newText + "\n";
        //Debug.Log(m_textContent);
    }

    public string GetLogText()
    {
        return m_textContent;
    }
}
