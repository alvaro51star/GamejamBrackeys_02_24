using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Mathematics;
using UnityEngine;
using Random = System.Random;

public class DoorManager : MonoBehaviour
{
    public static DoorManager instance;

    public PersonDataSO personAtTheDoor;
    public int badPeople = 0;
    [SerializeField] private int peopleNumber = 10;

    [SerializeField] private PeopleType[] peopleTypes;
    [SerializeField] private int peopleIndex = 0;

    //Al principio del dia se genera un array de tipos de persona y eso lo ordeno aleatoriamente al principio

    [SerializeField] private float secondsToNewPerson = 3f;


    private void Awake()
    {
        instance = this;
        peopleTypes = new PeopleType[peopleNumber];
    }

    private void Start()
    {
        GeneratePeople();


    }

    public void SetNewPersonInDoor()
    {
        StartCoroutine(SetNewPerson());
    }

    private IEnumerator SetNewPerson()
    {
        yield return new WaitForSeconds(secondsToNewPerson);
        personAtTheDoor = PeopleManager.instance.NextPersonInLine(peopleTypes[peopleIndex]);
    }

    private void GeneratePeople()
    {
        for (int i = 0; i < peopleTypes.Length; i++)
        {
            if (badPeople > 0)
            {
                peopleTypes[i] = PeopleType.Bad;
                badPeople--;
            }
            else
            {
                peopleTypes[i] = PeopleType.Good;
            }
        }

        Randomizer.Randomize(peopleTypes);
    }
}

public class Randomizer
{
    public static void Randomize<T>(T[] items)
    {
        Random rand = new Random();

        // For each spot in the array, pick
        // a random item to swap into that spot.
        for (int i = 0; i < items.Length - 1; i++)
        {
            int j = rand.Next(i, items.Length);
            T temp = items[i];
            items[i] = items[j];
            items[j] = temp;
        }
    }
}
