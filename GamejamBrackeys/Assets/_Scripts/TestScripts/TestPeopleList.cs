using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPeopleList : MonoBehaviour
{
    [SerializeField] private PersonDataSO person;
 
    public void GetPerson()
    {
        person = PeopleManager.instance.NextPersonInLine(PeopleType.Good);

        Debug.Log($"Name: {person._name}");
    }
}
