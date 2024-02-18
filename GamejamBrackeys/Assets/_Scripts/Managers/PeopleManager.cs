using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeopleManager : MonoBehaviour
{
    public static PeopleManager instance;
    // [SerializeField] private List<PersonDataSO> GoodPeopleList;
    // [SerializeField] private List<PersonDataSO> BadPeopleList;

    [SerializeField] private List<TextAsset> GoodDialogues;
    [SerializeField] private List<TextAsset> BadDialogues;

    [SerializeField] private List<Sprite> PeopleSprites;

    //[SerializeField] private List<string> names;

    private void Awake()
    {
        instance = this;
    }

    // /// <summary>Return the next person to be at the door depending on the type it recieves</summary>
    // public PersonDataSO NextPersonInLine(PeopleType peopleType)
    // {
    //     PersonDataSO personData;
    //     int index;
    //     if (peopleType == PeopleType.Good)
    //     {
    //         index = Random.Range(0, GoodPeopleList.Count);
    //         personData = GoodPeopleList[index];
    //         GoodPeopleList.RemoveAt(index);
    //     }
    //     else
    //     {
    //         index = Random.Range(0, BadPeopleList.Count);
    //         personData = BadPeopleList[index];
    //         BadPeopleList.RemoveAt(index);
    //     }
    //     return personData;
    // }

    public PersonData NextPersonInLine(PeopleType peopleType)
    {
        PersonData personData = new();
        int index;
        if (peopleType == PeopleType.Good)
        {
            personData._personType = PeopleType.Good;
            index = Random.Range(0, GoodDialogues.Count);
            personData._dialogueText = GoodDialogues[index];
            GoodDialogues.RemoveAt(index);
        }
        else
        {
            personData._personType = PeopleType.Bad;
            index = Random.Range(0, BadDialogues.Count);
            personData._dialogueText = BadDialogues[index];
            BadDialogues.RemoveAt(index);
        }
        index = Random.Range(0, PeopleSprites.Count);
        personData._sprite = PeopleSprites[index];
        PeopleSprites.RemoveAt(index);
        //Le pone imagen random
        return personData;
    }
}

[System.Serializable]
public enum PeopleType
{
    Good,
    Bad
}
