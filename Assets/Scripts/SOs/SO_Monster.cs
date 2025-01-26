using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Monster",
    menuName = "Scriptable Objects/Monsters", order = 1)]

public class SO_Monster : ScriptableObject
{
    public enum EMonsterBuild
    {
        Humanoid,
        Automaton,
        Gelatinous,
        Fae,
        Avian,
        Aquatic,
        Reptillian,
        Insect,
        Golem,
        Demon
    }

    public enum EMonsterElement
    {
        Standard,
        Fire,
        Water,
        Nature,
        Shock,
        Rock,
        Metallic,
        Undead,
        Golem
    }

    public enum EMonsterClass
    {
        S,
        A,
        B,
        C,
        D,
        E,
        F
    }

    [Header ("Name / ID")]
    public string MonsterDisplayName;
    public string MonsterID;

    [Header("Details")]
    public int MonsterpediaEntryValue;
    [Space]
    public EMonsterBuild MonsterBuild;
    [Space]
    public EMonsterElement MonsterElement;
    [Space]
    public EMonsterClass MonsterClass;
    [Space]
    public GameObject DroppedItem;
    [Space]  
    [TextArea(1, 30)]
    public string MonsterDescription = "";

}
