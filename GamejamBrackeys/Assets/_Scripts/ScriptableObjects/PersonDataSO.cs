using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PersonData",menuName = "GamejamProject/PersonData")]
[System.Serializable]
public class PersonDataSO : ScriptableObject
{
    public string _name; //Si esto sobra se quita porque no me quedo claro si lo hacia miriam o no, preguntar después
    public TextAsset _dialogueText; 
    public Sprite _sprite;
    public AudioClip _textAudioClip;
    public Sprite _dialogueSprite; //No se si habra asi que lo pongo y listos
}