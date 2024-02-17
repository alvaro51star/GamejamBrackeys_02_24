using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NamesDatabase",menuName = "GamejamProject/NameDatabase")]
public class NamesDatabaseSO : ScriptableObject
{
    public List<string> names;
}
