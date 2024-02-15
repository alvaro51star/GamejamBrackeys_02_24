using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManager : MonoBehaviour
{
    public static DoorManager instance;

    public PersonDataSO personAtTheDoor;
    public int badPeople = 0;

    [SerializeField] private float secondsToNewPerson = 3f;


    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {

    }

    private IEnumerator SetNewPerson()
    {
        yield return new WaitForSeconds(secondsToNewPerson);
        //personAtTheDoor = PeopleManager.instance.NextPersonInLine();
    }
}
