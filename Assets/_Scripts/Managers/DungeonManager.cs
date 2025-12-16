using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DungeonManager : MonoBehaviour
{
    [SerializeField] private DungeonData data;
    [SerializeField] private PlayerData pData;

    private UnityEvent onGiveReward = new();

    private static DungeonManager instance;
    public static DungeonManager GetInstance { get => instance; }
    public DungeonData Data { get => data; }
    public UnityEvent OnGiveReward { get => onGiveReward; }

    private void Awake()
    {
        instance = this;
    }

    public void StartDungeon()
    {
        data.GenerateDungeon();

        pData.ReloadCardsFromTemplate();
        pData.ReloadHeroesFromTemplate();
        pData.SetFullHealth();

        Loader.Load(Loader.Scenes.BattleScene);
    }

    public BaseEnemy[] GetEnemiesForRoom() {
        BattleRoom room = data.CurrentRoom as BattleRoom;
        if (room) return room.Enemies;
        return null;
    }

    public void ChangeLevel()
    {
        if (Player.GetInstance) Player.GetInstance.SaveCurrentHealthPercent();
        int index = data.IncrementPointer();

        if (index < 0) { Loader.Load(Loader.Scenes.WinScene); return; }

        Loader.Load(data.CurrentRoom);
    }

    public ITreasure GiveReward(ITreasure reward) 
    {
        if (reward is BaseHero) pData.AddHero(reward as BaseHero);
        if (reward is Card) pData.AddCard(reward as Card);
        OnGiveReward?.Invoke();

        return reward;

    }

    public ITreasure GiveRandomReward()
    {
        var room = data.CurrentRoom;
        var reward  = room.RandomTreasure;

        return GiveReward(reward);
    }
}
