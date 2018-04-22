using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rei : Token
{
    private List<Vector3> moves;
    override protected void Start()
    {
        base.Start();
        moves = new List<Vector3>();
        moves.Add(new Vector3( 1, 1, 0));
        moves.Add(new Vector3( 1, 0, 0));
        moves.Add(new Vector3( 1,-1, 0));
        moves.Add(new Vector3( 0,-1, 0));
        moves.Add(new Vector3(-1,-1, 0));
        moves.Add(new Vector3(-1, 0, 0));
        moves.Add(new Vector3(-1, 1, 0));
        moves.Add(new Vector3( 0, 1, 0));
    }
    public override void CalculateMovablePositions()
    {
        /* //ta com erro! checar deppois
        for(int i = 0; i < moves.Count; i++)
        {
            if (IsValid(moves[i]))
            {
                Vector3 relative = transform.position + moves[i];
                TileInfo tileDestination = GridManager.Tiles[(int)relative.y][(int)relative.x];
                Token aux;
                if (tileDestination.IsFree() || (aux = tileDestination.inside.GetComponent<Token>()) && aux.player != player)
                {
                    movablePositions.Add(new Vector2Int((int)relative.x, (int)relative.y));
                }
            }
        }*/
        Token aux;
        // CIMA ************************
        if (transform.position.y + 1 < 8)
        {
            if (GridManager.Tiles[(int)transform.position.x][(int)transform.position.y + 1].IsFree())
            {
                movablePositions.Add(new Vector2Int((int)transform.position.x, (int)transform.position.y + 1));
            }
             else if((aux=   GridManager.Tiles[(int)transform.position.x][(int)transform.position.y + 1].inside.GetComponent<Token>()) && aux.player != player)
            {
                movablePositions.Add(new Vector2Int((int)transform.position.x, (int)transform.position.y + 1));
            }
        }

        // BAIXO *************************
        if (transform.position.y - 1 > -1)
        {
            if (GridManager.Tiles[(int)transform.position.x][(int)transform.position.y - 1].IsFree())
            {
                movablePositions.Add(new Vector2Int((int)transform.position.x, (int)transform.position.y - 1));
            }
             else if((aux=   GridManager.Tiles[(int)transform.position.x][(int)transform.position.y - 1].inside.GetComponent<Token>()) && aux.player != player)
            {
                movablePositions.Add(new Vector2Int((int)transform.position.x, (int)transform.position.y - 1));
            }
        }

        // DIREITA *********************
        if (transform.position.x + 1 < 8)
        {
            if (GridManager.Tiles[(int)transform.position.x + 1][(int)transform.position.y].IsFree())
            {
                movablePositions.Add(new Vector2Int((int)transform.position.x + 1, (int)transform.position.y));
            }
            else if((aux=    GridManager.Tiles[(int)transform.position.x + 1][(int)transform.position.y].inside.GetComponent<Token>()) && aux.player != player)
            {
                movablePositions.Add(new Vector2Int((int)transform.position.x + 1, (int)transform.position.y));
            }
        }

        // ESQUERDA **********************
        if (transform.position.x - 1 > -1)
        {
            if (GridManager.Tiles[(int)transform.position.x - 1][(int)transform.position.y].IsFree())
            {
                movablePositions.Add(new Vector2Int((int)transform.position.x - 1, (int)transform.position.y));
            }
            else if((aux=    GridManager.Tiles[(int)transform.position.x - 1][(int)transform.position.y].inside.GetComponent<Token>()) && aux.player != player)
            {
                movablePositions.Add(new Vector2Int((int)transform.position.x - 1, (int)transform.position.y));
            }
        }

        // CIMA E DIREITA ***********************************************
        if (transform.position.x + 1 < 8 && transform.position.y + 1 < 8)
        {
            if (GridManager.Tiles[(int)transform.position.x + 1][(int)transform.position.y + 1].IsFree())
            {
                movablePositions.Add(new Vector2Int((int)transform.position.x + 1, (int)transform.position.y + 1));
            }
             else if((aux=   GridManager.Tiles[(int)transform.position.x + 1][(int)transform.position.y + 1].inside.GetComponent<Token>()) && aux.player != player)
            {
                movablePositions.Add(new Vector2Int((int)transform.position.x + 1, (int)transform.position.y + 1));
            }            
        }

        // CIMA E ESQUERDA **********************************************
        if (transform.position.x - 1 > -1 && transform.position.y + 1 < 8)
        {
            if (GridManager.Tiles[(int)transform.position.x - 1][(int)transform.position.y + 1].IsFree())
            {
                movablePositions.Add(new Vector2Int((int)transform.position.x - 1, (int)transform.position.y + 1));
            }
            else if((aux=    GridManager.Tiles[(int)transform.position.x - 1][(int)transform.position.y + 1].inside.GetComponent<Token>()) && aux.player != player)
            {
                movablePositions.Add(new Vector2Int((int)transform.position.x - 1, (int)transform.position.y + 1));
            }
        }

        // BAIXO E ESQUERDA **********************************************
        if (transform.position.x - 1 > -1 && transform.position.y - 1 > -1)
        {
            if (GridManager.Tiles[(int)transform.position.x - 1][(int)transform.position.y - 1].IsFree())
            {
                movablePositions.Add(new Vector2Int((int)transform.position.x - 1, (int)transform.position.y - 1));
            }
            else if((aux=    GridManager.Tiles[(int)transform.position.x - 1][(int)transform.position.y - 1].inside.GetComponent<Token>()) && aux.player != player)
            {
                movablePositions.Add(new Vector2Int((int)transform.position.x - 1, (int)transform.position.y - 1));
            }

        }

        // BAIXO E DIREITA **********************************************
        if (transform.position.x + 1 < 8 && transform.position.y - 1 > -1)
        {
            if (GridManager.Tiles[(int)transform.position.x + 1][(int)transform.position.y - 1].IsFree())
            {
                movablePositions.Add(new Vector2Int((int)transform.position.x + 1, (int)transform.position.y - 1));
            }
            else if((aux=GridManager.Tiles[(int)transform.position.x + 1][(int)transform.position.y - 1].inside.GetComponent<Token>()) && aux.player != player)
            {
                movablePositions.Add(new Vector2Int((int)transform.position.x + 1, (int)transform.position.y - 1));
            }
        }
    }
}