using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeopleManager : MonoBehaviour
{
    public static PeopleManager instance;
    [SerializeField] private List<PersonDataSO> GoodPeopleList;
    [SerializeField] private List<PersonDataSO> BadPeopleList;

    private void Awake()
    {
        instance = this;
    }

    /// <summary>Return the next person to be at the door depending on the type it recieves</summary>
    public PersonDataSO NextPersonInLine(PeopleType peopleType)
    {
        PersonDataSO personData;
        int index;
        if (peopleType == PeopleType.Good)
        {
            index = Random.Range(0, GoodPeopleList.Count);
            personData = GoodPeopleList[index];
            GoodPeopleList.RemoveAt(index);
        }
        else
        {
            index = Random.Range(0, BadPeopleList.Count);
            personData = BadPeopleList[index];
            BadPeopleList.RemoveAt(index);
        }
        return personData;
    }
}

public enum PeopleType
{
    Good,
    Bad
}
