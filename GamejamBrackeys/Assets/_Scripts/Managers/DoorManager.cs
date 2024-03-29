using System;
using System.Collections;
using DG.Tweening;
using UnityEditor.ShaderKeywordFilter;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

public class DoorManager : MonoBehaviour
{
    public static DoorManager instance;

    //public PersonDataSO personAtTheDoor;

    public PersonData personAtTheDoor;
    public int badPeople = 0;
    public bool isAccepted = false;
    [SerializeField] private int peopleNumber = 10;

    [SerializeField] private PeopleType[] peopleTypes;
    [SerializeField] private int peopleIndex = 0;

    [SerializeField] private int currentPeopleIn = 0;
    [SerializeField] private int badPeopleIn = 0;
    [SerializeField] private int goodPeopleOut = 0;

    [SerializeField] private GameObject personImage;

    //Al principio del dia se genera un array de tipos de persona y eso lo ordeno aleatoriamente al principio

    [SerializeField] private float secondsToNewPerson = 3f;

    [Space]
    [Header("Feedback variables")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip audioClip;
    [SerializeField] private AudioClip doorOpen, doorClose;
    [SerializeField] private AudioClip doorViewSound;
    [SerializeField] private GameObject doorLight, doorView, doorKnob;
    [Space]
    [SerializeField] private Transform initialDoorShadowPosition, finalDoorShadowPosition;
    [Space]
    [SerializeField] private Transform initialDoorViewPosition, finalDoorViewPosition;
    [Space]
    [SerializeField] private Transform initialDoorKnobPosition, finalDoorKnobPosition;

    private void Awake()
    {
        instance = this;
        peopleTypes = new PeopleType[peopleNumber];
    }

    private void Start()
    {
        GeneratePeople();
        StartCoroutine(StartGame());
    }

    public void SetNewPersonInDoor()
    {
        if (currentPeopleIn >= peopleNumber)
        {
            GameManager.instance.GameOver();
        }
        StartCoroutine(SetNewPerson());
    }

    private IEnumerator StartGame()
    {
        yield return new WaitForSeconds(1f);
        SetNewPersonInDoor();
    }

    private IEnumerator SetNewPerson()
    {
        yield return new WaitForSeconds(secondsToNewPerson);
        personAtTheDoor = PeopleManager.instance.NextPersonInLine(peopleTypes[peopleIndex]);
        peopleIndex++;
        currentPeopleIn++;
        //Falta feedback de la puerta cuando se pone una persona
        audioSource.PlayOneShot(audioClip);
        yield return new WaitForSeconds(audioClip.length);
        EventManager.PhoneRinging?.Invoke();
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

    public void EndDialogue()
    {
        if (isAccepted)
        {
            if (personAtTheDoor._personType == PeopleType.Bad)
            {
                badPeopleIn++;
                GameManager.instance.AddBadPeopleIn();
            }
            //La puerta se debe abrir dejando pasar al pavo
            //animacion puerta
            doorLight.SetActive(false);
            doorView.transform.position = initialDoorViewPosition.position;
            StartCoroutine(ShowPerson());
            Invoke(nameof(SetNewPersonInDoor), 0.5f);
            DeletePersonFromDoor();
        }
        else
        {
            if (personAtTheDoor._personType == PeopleType.Good)
            {
                goodPeopleOut++;
                GameManager.instance.AddGoodPeopleOut();
            }
            StartCoroutine(CloseDoorViewFeedbacks());
            Invoke(nameof(SetNewPersonInDoor), 0.5f);
            DeletePersonFromDoor();
        }
    }

    public void StartDialogue()
    {
        StartCoroutine(OpenDoorViewFeedbacks());
    }

    #endregion

    #region Feedbacks

    /// <summary>Reproduce feedbacks al abrir la puerta para dejar pasar</summary>
    public IEnumerator OpenDoorViewFeedbacks()
    {
        //TODO Reproducir audio
        doorView.transform.DOMove(finalDoorViewPosition.position, 0.5f).SetEase(Ease.InSine);
        audioSource.PlayOneShot(doorViewSound);
        yield return null;
    }

    /// <summary>Reproduce feedbacks al abrir la mirilla de la puerta</summary>
    public IEnumerator OpenDoorFeedbacks()
    {
        doorKnob.transform.DORotate(new Vector3(0, 0, 180), 1);
        //TODO animacion de la puerta cuando se abre
        yield return null;
    }

    /// <summary>Reproduce feedbacks al cerrar la puerta</summary>
    public IEnumerator CloseDoorViewFeedbacks()
    {
        //TODO reproducir audio
        doorView.transform.DOMove(initialDoorViewPosition.position, 0.5f).SetEase(Ease.InSine);
        audioSource.PlayOneShot(doorViewSound);
        yield return new WaitForSeconds(0.5f);
        //Aqui tambien va audio de pasos cuando se va
        doorLight.SetActive(false);
    }

    private IEnumerator ShowPerson()
    {
        personImage.GetComponent<SpriteRenderer>().sprite = personAtTheDoor._sprite;
        audioSource.PlayOneShot(doorOpen);
        personImage.SetActive(true);
        yield return new WaitForSeconds(2f);
        personImage.SetActive(false);
        audioSource.PlayOneShot(doorClose);
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
