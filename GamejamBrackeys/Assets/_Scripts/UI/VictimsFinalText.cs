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
        int peopleKilled = GameManager.instance.badPeopleIn * Random.Range(2,5);
        
        //text.text = $"{peopleKilled} people have ended up dying because of your decisions";
        text.text = $"You left {GameManager.instance.goodPeopleOut} outside the bunker and you let {GameManager.instance.badPeopleIn} Alters inside the bunker, causing in total {peopleKilled + GameManager.instance.goodPeopleOut} deaths";
    }
}
