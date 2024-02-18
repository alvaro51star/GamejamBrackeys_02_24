using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class VictimsFinalText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;

    // Start is called before the first frame update
    void Start()
    {
        text.text = $"{GameManager.instance.badPeopleIn} people have ended up dying because of your decisions";
    }
}
