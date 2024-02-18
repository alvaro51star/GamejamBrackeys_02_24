using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PostItCounter : MonoBehaviour
{
    [SerializeField] private GameObject firstPostIt;
    [SerializeField] private GameObject secondPostIt;
    [SerializeField] private GameObject thirdPostIt;
    [SerializeField] private Button line2button;
    private int counter;
    private void OnEnable()
    {
        EventManager.Call2 += OnCall2;
    }
    private void OnDisable()
    {
        EventManager.Call2 -= OnCall2;
    }

    private void OnCall2()
    {
        counter++;
        UIManager.instance.ChangePostItCounter(counter);
        if(counter == 1)
        {
            firstPostIt.SetActive(true);
        }
        else if(counter == 2)
        {
            secondPostIt.SetActive(true);
        }
        else if(counter == 3)
        {
            thirdPostIt.SetActive(true);
            line2button.enabled = false;
        }
    }
}
