using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseRoom : ScriptableObject
{
    public enum RoomTypes 
    { 
        Question,
        Battle
    }

    [SerializeField] List<ScriptableObject> treasures = new();

    [SerializeField] private RoomTypes type;

    public ScriptableObject[] Treasures { get => treasures.ToArray(); }

    public ITreasure RandomTreasure
    {
        get
        {
            var treasure = treasures[Random.Range(0, treasures.Count)];
            if (treasure is ITreasure) return treasure as ITreasure;
            else return null;
        }
    }



    public RoomTypes Type { get => type; }
}
