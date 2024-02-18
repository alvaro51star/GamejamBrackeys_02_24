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
        int peopleKilled = GameManager.instance.badPeopleIn * Random.Range(1,5);

        text.text = $"{peopleKilled} people have ended up dying because of your decisions";
    }
}
