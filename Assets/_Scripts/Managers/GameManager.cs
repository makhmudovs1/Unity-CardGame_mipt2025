using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

class GameManager : MonoBehaviour
{
    [SerializeField] private Button confirmButton;

    private static GameManager instance;
    public static GameManager GetInstance { get => instance; }
    public Button ConfirmButton { get => confirmButton; }

    private void Awake()
    {
        HeroController.OnCardUse.AddListener(CardLog);
        instance = this;
        ConfirmButton.onClick.AddListener(ConfirmHeroes);

    }

    private void Start()
    {
        if (DungeonManager.GetInstance.GetEnemiesForRoom() != null)
            EnemyDirector.GetInstance.LoadEnemies(DungeonManager.GetInstance.GetEnemiesForRoom());

        foreach (var enemy in EnemyDirector.GetInstance.Enemies)
        {
            enemy.OnHit.AddListener(CheckIfIsEnemiesDied);
        }

    }

    private void ChangeConfirmButtonText(string text)
    {
        ConfirmButton.gameObject.GetComponentInChildren<Text>().text = text;
    }



    private void ConfirmHeroes()
    {
        if (!Player.GetInstance.ConfirmHeroes()) return;

        ConfirmButton.onClick.RemoveAllListeners();
        ChangeConfirmButtonText("Start");
        ConfirmButton.onClick.AddListener(StartBattle);
    }


    private void StartBattle() {

        TurnManager.GetInstance.StartBattle();
        Player.GetInstance.SetDefaultActions();

        CardManager.GetInstance.FillHand();
        ChangeConfirmButtonText("Pass the turn");

        ConfirmButton.onClick.RemoveAllListeners();
        ConfirmButton.onClick.AddListener(EndPlayersTurn);
    }

    private void EndPlayersTurn()
    {
        TurnManager.GetInstance.ChangeState();
        ConfirmButton.onClick.RemoveAllListeners();

        EndEnemysTurn();
    }

    private void EndEnemysTurn()
    {
        TurnManager.GetInstance.ChangeState();
        EnemyDirector.GetInstance.PerformActions();
        if (CheckIfPlayerDied()) return;

        Player.GetInstance.AddAction(Player.Roles.Melee);
        Player.GetInstance.AddAction(Player.Roles.Support);
        Player.GetInstance.AddAction(Player.Roles.Range);

        CardManager.GetInstance.FillHand();

        ConfirmButton.onClick.AddListener(EndPlayersTurn);
    }  
    
    private void LoseBattle()
    {
        TurnManager.GetInstance.EndBattle();

        ConfirmButton.onClick.RemoveAllListeners();
        Debug.Log("Player lost");

        //endgame screen
        EndScreenManager.GetInstance.ShowEndScreen(false);

    }
    private void WinBattle()
    {
        TurnManager.GetInstance.EndBattle();

        ConfirmButton.onClick.RemoveAllListeners();
        Debug.Log("Player won");

        //endgame screen
        EndScreenManager.GetInstance.ShowEndScreen(true);

        var reward = DungeonManager.GetInstance.GiveRandomReward();
        RewardMenuHandler.GetInstance.ShowItem(reward);
    }

    void CardLog() {
        Debug.Log("Card used");
    }

    void CheckIfIsEnemiesDied() {
        Debug.Log("CheckIfIsEnemiesDied");
        Debug.Log(!EnemyDirector.GetInstance.isEnemiesAlive());
        if (!EnemyDirector.GetInstance.isEnemiesAlive()) 
        {
            WinBattle();
        }
    }

    bool CheckIfPlayerDied()
    {
        if (Player.GetInstance.GetCurrentHealth() > 0) return false;

        LoseBattle();
        return true;
    }
}

