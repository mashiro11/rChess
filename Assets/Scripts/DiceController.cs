using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceController : MonoBehaviour {

    public static SpriteRenderer spriteRenderer = null;
    public Sprite[] sprites;
    public static int diceFace = 0;
    public static DiceController instance = null;

	void Awake () {
        if (instance == null)
        {
            instance = this;
            spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        }
	}
	
	void Update()
    {
        if (TurnManager.CurrentState == TurnManager.TurnState.DiceRoll)
        {
            RollDice();

            if (TurnManager.LastState == TurnManager.TurnState.Player1)
            {
                TurnManager.CurrentState = TurnManager.TurnState.Player2;
                Debug.Log("Agora é a vez do Player 2!");
            }

            if (TurnManager.LastState == TurnManager.TurnState.Player2)
            {
                TurnManager.CurrentState = TurnManager.TurnState.Player1;
                Debug.Log("Agora é a vez do Player 1!");
            }
        }
	}

    public static void RollDice()
    {
        diceFace = Random.Range(0, 6);
        if (diceFace == 6) diceFace -= 1;
        spriteRenderer.sprite = instance.sprites[diceFace];
        DiceEffect();
        Debug.Log("O dado terminou de rolar");

    }

    public static void DiceEffect()
    {
        switch (diceFace){
            case 0:
                Debug.Log("Realiza efeito " + (diceFace + 1) + ": PoneyPoop");
                PoneyPoop();
                break;
            case 1:
                Debug.Log("Realiza efeito " + (diceFace + 1));
                break;
            case 2:
                Debug.Log("Realiza efeito " + (diceFace + 1));
                break;
            case 3:
                Debug.Log("Realiza efeito " + (diceFace + 1));
                break;
            case 4:
                Debug.Log("Realiza efeito " + (diceFace + 1));
                break;
            case 5:
                Debug.Log("Realiza efeito " + (diceFace + 1));
                break;
        }
    }
    public static void PoneyPoop()
    {
        for(int i = 0; i < 3; i++)
        {
            int sorteado = Random.Range(0, GridManager.GetFreeTiles().Count);
            GameObject poneyPoop = (GameObject)Instantiate(Resources.Load("Poop"), GridManager.GetFreeTiles()[sorteado].GetPosition(), Quaternion.identity);
            GridManager.GetFreeTiles()[sorteado].ReceiveObject(poneyPoop);
            GridManager.GetFreeTiles().RemoveAt(sorteado);
        }
    }
        
}
