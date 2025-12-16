using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class DungeonData : ScriptableObject
{
    [SerializeField] private int roomsNumber;
    [SerializeField] private int eventRoomsNumber;

    [SerializeField] private EventRoom[] eventRooms;
    [SerializeField] private BattleRoom[] battleRooms;

    [SerializeField] private List<BaseRoom> currentDungeon;
    private int roomPointer = 0;

    public BaseRoom[] CurrentDungeon { get => currentDungeon.ToArray(); }
    public int RoomsNumber { get => roomsNumber; set => roomsNumber = value; }
    public int EventRoomsNumber { get => eventRoomsNumber; set => eventRoomsNumber = value; }
    public int RoomPointer { get => roomPointer; }
    public BaseRoom CurrentRoom { get => currentDungeon[roomPointer]; }

    public void GenerateDungeon() 
    {
        currentDungeon = new List<BaseRoom>();

        int battleRoomIndex = Random.Range(0, battleRooms.Length);
        currentDungeon.Add(battleRooms[battleRoomIndex]);

        for (int i = 0; i < roomsNumber-eventRoomsNumber; i++) 
        { 
            currentDungeon.Add(GetRandomBattleRoom());
        }

        for (int i = 0; i < eventRoomsNumber; i++)
        {
            var roomIndex = Random.Range(1, currentDungeon.Count-1);
            Debug.Log("eventRoomPos: " + roomIndex);
            currentDungeon.Insert(roomIndex, GetRandomEventRoom());
        }

        currentDungeon.Add(GetRandomBattleRoom());

        roomPointer = 0;
    }

    BaseRoom GetRandomBattleRoom() {
        int index = Random.Range(0, battleRooms.Length);
        return battleRooms[index];
    }

    BaseRoom GetRandomEventRoom()
    {
        int index = Random.Range(0, eventRooms.Length);
        Debug.Log("eventRoomIndex: " + index);
        return eventRooms[index];
    }

    public int IncrementPointer() {
        roomPointer++;
        if (roomPointer < currentDungeon.Count) return roomPointer;
        else return -1;
    }
}
