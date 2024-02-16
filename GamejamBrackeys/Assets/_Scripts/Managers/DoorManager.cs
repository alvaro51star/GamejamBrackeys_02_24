using System;
using System.Collections;
using DG.Tweening;
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

    [Space]
    [Header("Feedback variables")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip audioClip;
    [SerializeField] private GameObject doorLight, doorView, openingDoor;
    [Space]
    [SerializeField] private Transform initialDoorShadowPosition, finalDoorShadowPosition;
    [Space]
    [SerializeField] private Transform initialDoorViewPosition, finalDoorViewPosition;

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
        peopleIndex++;
        //Falta feedback de la puerta cuando se pone una persona
        audioSource.PlayOneShot(audioClip);
        yield return new WaitForSeconds(audioClip.length);
        doorLight.SetActive(true);
        //Quizas hacer que la puerta este desactivada para interactuar hasta aqui.
    }

    public void DeletePersonFromDoor()
    {
        StartCoroutine(DeletePerson());
    }

    private IEnumerator DeletePerson()
    {
        personAtTheDoor = null;
        yield return null;
    }

    /// <summary>Reproduce feedbacks al abrir la puerta</summary>
    public IEnumerator OpenDoorFeedbacks()
    {
        //TODO Reproducir audio
        doorView.transform.DOMove(finalDoorViewPosition.position, 0.5f).SetEase(Ease.InSine);
        yield return null;
    }

    /// <summary>Reproduce feedbacks al cerrar la puerta</summary>
    public IEnumerator CloseDoorFeedbacks()
    {
        //TODO reproducir audio
        doorView.transform.DOMove(initialDoorViewPosition.position, 0.5f).SetEase(Ease.InSine);
        yield return new WaitForSeconds(0.5f);
        //Aqui tambien va audio de pasos cuando se va
        doorLight.SetActive(false);
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

    #region FunctionsToCallInDialogue

    public void EndDialogue(bool isAccepted)
    {
        if (isAccepted)
        {
            //La puerta se debe abrir dejando pasar al pavo
            //animacion puerta
            doorLight.SetActive(false);
            doorView.transform.position = initialDoorViewPosition.position;
            Invoke(nameof(SetNewPersonInDoor), 0.5f);
        }
        else
        {
            StartCoroutine(CloseDoorFeedbacks());
            Invoke(nameof(SetNewPersonInDoor), 0.5f);
        }
    }

    public void StartDialogue()
    {
        StartCoroutine(OpenDoorFeedbacks());
    }

    #endregion
}

public class Randomizer
{
    /// <summary>Randomize an array</summary>
    public static void Randomize<T>(T[] items)
    {
        Random rand = new Random();
        for (int i = 0; i < items.Length - 1; i++)
        {
            int j = rand.Next(i, items.Length);
            T temp = items[i];
            items[i] = items[j];
            items[j] = temp;
        }
    }
}
