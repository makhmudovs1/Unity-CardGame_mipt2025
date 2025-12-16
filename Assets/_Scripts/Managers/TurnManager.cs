using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager: MonoBehaviour
{
    public enum States { 
        PlayersTurn,
        EnemysTurn,
        NoBattle
    }

    private States state;
    private static TurnManager instance;
    public static TurnManager GetInstance { get => instance; }
    public States State { get => state; }

    public void Awake()
    {
        instance = this;
        EndBattle();
    }

    public void ChangeState() {
        Debug.Log(state);

        if (state == States.PlayersTurn) state = States.EnemysTurn;
        else state = States.PlayersTurn;
    }

    public void EndBattle() {
        Debug.Log("Battle ends");

        state = States.NoBattle;
    }

    public void StartBattle() {
        Debug.Log("Battle begins");

        state = States.PlayersTurn;
    }
}
