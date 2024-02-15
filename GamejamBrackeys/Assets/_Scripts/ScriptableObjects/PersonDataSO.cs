using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PersonData",menuName = "GamejamProject/PersonData")]
public class PersonDataSO : ScriptableObject
{
    //!JSON que no se de donde viene
    public Sprite _sprite;
    public AudioClip _textAudioClip;
    public Sprite _dialogueSprite; //No se si habra asi que lo pongo y listos
}
