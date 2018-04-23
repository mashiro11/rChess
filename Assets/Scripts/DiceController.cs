using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceController : MonoBehaviour {

    public static SpriteRenderer spriteRenderer = null;
    public Sprite[] sprites;
    public static int diceFace = 0;
    public static DiceController instance = null;
    public static Ponei poneiScript;
    public static Dinossaur dino;

	void Awake () {
        if (instance == null)
        {
            instance = this;
            spriteRenderer = GetComponentInChildren<SpriteRenderer>();
            //poneiScript = GameObject.Find("Ponei").GetComponent<Ponei>();
            dino = GameObject.Find("Dinossour").GetComponent<Dinossaur>();
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
                poneiScript.PoneiEvent();
                break;
            case 1:
                Debug.Log("Realiza efeito " + (diceFace + 1));
                dino.DinoEvent();
                break;
            case 2:
                Debug.Log("Realiza efeito " + (diceFace + 1));
                dino.DinoEvent();
                break;
            case 3:
                Debug.Log("Realiza efeito " + (diceFace + 1));
                dino.DinoEvent();
                break;
            case 4:
                Debug.Log("Realiza efeito " + (diceFace + 1));
                dino.DinoEvent();
                break;
            case 5:
                Debug.Log("Realiza efeito " + (diceFace + 1));
                dino.DinoEvent();
                break;
        }
    }

    public static void Dino()
    {

    }
        
}
