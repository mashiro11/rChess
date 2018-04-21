using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Peao : Token {

    public override void CalculateMovablePositions()
    {
        // limitar o deslocamento do peão para cima
        if (transform.position.y + 1 < 8)//Cima
        {
            // limitar o deslocamento do peao para a direita
            if (transform.position.x + 1 < 8)//Direita
            {
                // verificar se aquela posição no grid está livre
                if (GridManager.Tiles[(int)transform.position.x][(int)transform.position.y + 1].IsFree())
                {
                    //adicionar todas possíveis posições andáveis à lista de Vector2Int
                    movablePositions.Add(new Vector2Int((int)transform.position.x, (int)transform.position.y + 1));
                }
            }

            // limitar o deslocamento do peao para a esquerda
            if (transform.position.x - 1 > -1)//Esquerda
            {
                // verificar se aquela posição no grid está livre
                if (GridManager.Tiles[(int)transform.position.x][(int)transform.position.y + 1].IsFree())
                {
                    //adicionar todas possíveis posições andáveis à lista de Vector2Int
                    movablePositions.Add(new Vector2Int((int)transform.position.x, (int)transform.position.y + 1));
                }
            }
        }
    }
}

