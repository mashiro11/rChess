using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    public static int TurnCount;
    public enum TurnState
    {
        Player1 = 1,
        Player2 = 2,
        DiceRoll = 3
    };

    // CurrentState define em qual turno estamos
    public static TurnState CurrentState = TurnState.Player1;
    // LastState armazena quem foi último a jogar
    public static TurnState LastState;

}
