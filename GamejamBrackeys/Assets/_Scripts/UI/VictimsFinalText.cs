using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class VictimsFinalText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private TextMeshProUGUI bottomText;

    // Start is called before the first frame update
    void Start()
    {
        int peopleKilled = GameManager.instance.badPeopleIn * Random.Range(2, 5);

        //text.text = $"{peopleKilled} people have ended up dying because of your decisions";
        text.text = $"You left {GameManager.instance.goodPeopleOut} humans outside the bunker and you let {GameManager.instance.badPeopleIn} Alters come inside, causing a total of {peopleKilled + GameManager.instance.goodPeopleOut} deaths";

        if (GameManager.instance.goodPeopleOut == 1)
        {
            bottomText.text += "You let one person outside the bunker, that person is dead because of you, be careful with the decisions you make.";
        }
        else if (GameManager.instance.goodPeopleOut > 1)
        {
            bottomText.text += $"You let {GameManager.instance.goodPeopleOut} people outside the bunker, these people are dead because of you, be careful with the decisions you make.";
        }

    }
}
