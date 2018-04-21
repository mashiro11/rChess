using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rei : Token
{
    public override void CalculateMovablePositions()
    {
        // CIMA ************************
        if (transform.position.y + 1 < 8)
        {
            if (GridManager.Tiles[(int)transform.position.x][(int)transform.position.y + 1].IsFree())
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
        }

        // DIREITA *********************
        if (transform.position.x + 1 < 8)
        {
            if (GridManager.Tiles[(int)transform.position.x + 1][(int)transform.position.y].IsFree())
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
        }

        // CIMA E DIREITA ***********************************************
        if (transform.position.x + 1 < 8 && transform.position.y + 1 < 8)
        {
            if (GridManager.Tiles[(int)transform.position.x + 1][(int)transform.position.y + 1].IsFree())
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
        }

        // BAIXO E ESQUERDA **********************************************
        if (transform.position.x - 1 > -1 && transform.position.y - 1 > -1)
        {
            if (GridManager.Tiles[(int)transform.position.x - 1][(int)transform.position.y - 1].IsFree())
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
        }
    }
}