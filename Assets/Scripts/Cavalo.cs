using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cavalo : Token {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}

    public override void CalculateMovablePositions()
    {
        List<Vector2Int> list = new List<Vector2Int>();
        //checar movimentações possiveis do cavalo
        //checar se essa posição é válida no grid
        //ver quais estão livres
        //adicionar em list
        if (transform.position.x + 2 < 8 )//Direita
        {
            if (transform.position.y + 1 < 8)//Cima
            {
                if (GridManager.Tiles[(int)transform.position.x + 2][(int)transform.position.y + 1].IsFree())
                {
                    movablePositions.Add(new Vector2Int((int)transform.position.x + 2,(int)transform.position.y + 1));
                }
            }
            if(transform.position.y - 1 > -1)//Baixo
            {
                if (GridManager.Tiles[(int)transform.position.x + 2][(int)transform.position.y - 1].IsFree())
                {
                    movablePositions.Add(new Vector2Int((int)transform.position.x + 2, (int)transform.position.y - 1));
                }
            }

        }
        if (transform.position.x - 2 > -1)//Esquerda
        {
            if (transform.position.y + 1 < 8)//Cima
            {
                if (GridManager.Tiles[(int)transform.position.x - 2][(int)transform.position.y + 1].IsFree())
                {
                    movablePositions.Add(new Vector2Int((int)transform.position.x - 2, (int)transform.position.y + 1));
                }
            }
            if (transform.position.y - 1 > -1)//Baixo
            {
                if (GridManager.Tiles[(int)transform.position.x - 2][(int)transform.position.y - 1].IsFree())
                {
                    movablePositions.Add(new Vector2Int((int)transform.position.x - 2, (int)transform.position.y - 1));
                }
            }
        }


        if (transform.position.y + 2 < 8)//Cima
        {
            if (transform.position.x + 1 < 8)//Direita
            {
                if (GridManager.Tiles[(int)transform.position.x + 1][(int)transform.position.y + 2].IsFree())
                {
                    movablePositions.Add(new Vector2Int((int)transform.position.x + 1, (int)transform.position.y + 2));
                }
            }
            if (transform.position.x - 1 > -1)//Esquerda
            {
                if (GridManager.Tiles[(int)transform.position.x - 1][(int)transform.position.y + 2].IsFree())
                {
                    movablePositions.Add(new Vector2Int((int)transform.position.x - 1, (int)transform.position.y + 2));
                }
            }

        }
        if (transform.position.y - 2 > -1)//Baixo
        {
            if (transform.position.x + 1 < 8)//Direita
            {
                if (GridManager.Tiles[(int)transform.position.x + 1][(int)transform.position.y - 2].IsFree())
                {
                    movablePositions.Add(new Vector2Int((int)transform.position.x + 1, (int)transform.position.y - 2));
                }
            }
            if (transform.position.x - 1 > -1)//Esquerda
            {
                if (GridManager.Tiles[(int)transform.position.x - 1][(int)transform.position.y - 2].IsFree())
                {
                    movablePositions.Add(new Vector2Int((int)transform.position.x - 1, (int)transform.position.y - 2));
                }
            }
        }


    }
}
