using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeopleManager : MonoBehaviour
{
    public static PeopleManager instance;
    [SerializeField] private List<PersonDataSO> GoodPeopleList;
    [SerializeField] private List<PersonDataSO> BadPeopleList;

    //?He pensado que lo que se puede hacer para que no se repitan las personas literalmente se podrian borrar y listo, ya que no se va a usar en un dia siguiente ni nada asi

    private void Awake()
    {
        instance = this;
    }

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
