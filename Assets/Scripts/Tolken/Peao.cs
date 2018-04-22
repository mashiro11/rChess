using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Peao : Token {

    override protected void Start()
    {
        base.Start();
    }
    public override void CalculateMovablePositions()
    {
        int sign = (player == 1) ? 1 : -1;
        int start = (player == 1) ? 1 : 6;
        int times = (transform.position.y == start) ? 2 : 1;

        Vector3 forward = sign * Vector3.up;
        Vector3 next;
        for (int i = 0; i < times; i++) {
            next = (i + 1) * forward;
            if (IsValid(next))
            {
                next += transform.position;
                TileInfo tileDestination = GridManager.Tiles[(int)next.x][(int)next.y];
                if (tileDestination.IsFree())
                {
                    movablePositions.Add(new Vector2Int((int)next.x, (int)next.y));
                }
            }
        }
        next = forward + Vector3.right;
        Token aux;
        if (IsValid(next))
        {
            next += transform.position;
            TileInfo tileDestination = GridManager.Tiles[(int)next.x][(int)next.y];
            if (!tileDestination.IsFree() && (aux = tileDestination.inside.GetComponent<Token>()) && aux.player != player)
            {
                movablePositions.Add(new Vector2Int((int)next.x, (int)next.y));
            }
        }
        next = forward + Vector3.left;
        if (IsValid(next))
        {
            next += transform.position;
            TileInfo tileDestination = GridManager.Tiles[(int)next.x][(int)next.y];
            if (!tileDestination.IsFree() && (aux = tileDestination.inside.GetComponent<Token>()) && aux.player != player)
            {
                movablePositions.Add(new Vector2Int((int)next.x, (int)next.y));
            }
        }
    }
}

