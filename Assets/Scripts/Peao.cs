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
        int limit = (player == 1) ? 8 : -1;
        int start = (player == 1) ? 1 : 6;
        int times = (transform.position.y == start) ? 2 : 1;
        for (int i = 1; i < times+1; i++)
        {
            bool walkOk = (player == 1) ? transform.position.y + sign*times < limit : transform.position.y + sign*times > limit;
            // limitar o deslocamento do peão frente
            if (walkOk)
            {
                // limitar o deslocamento do peao para a direita
                if (transform.position.x + 1 < 8)//Direita
                {
                    // verificar se aquela posição no grid está livre
                    if (GridManager.Tiles[(int)transform.position.x][(int)transform.position.y + sign*i].IsFree())
                    {
                        //adicionar todas possíveis posições andáveis à lista de Vector2Int
                        movablePositions.Add(new Vector2Int((int)transform.position.x, (int)transform.position.y + sign*i));
                    }
                }

                // COMER PARA DIREITA E PARA CIMA
                if (transform.position.x + 1 < 8 && transform.position.y + 1 < 8)
                {
                    Vector3 relative = transform.position + new Vector3(1,1,0);
                    TileInfo tileDestination = GridManager.Tiles[(int)relative.x][(int)relative.y];
                    Token aux;
                    // se a possível posição de destino está ocupada &&
                    // se o meu tile possui um objeto do tipo token &&
                    // se o token aux não for do player &&
                    if (!tileDestination.IsFree() && (aux = tileDestination.inside.GetComponent<Token>()) && aux.player != player)
                    {
                        movablePositions.Add(new Vector2Int((int)relative.x, (int)relative.y));
                    }
                }

                // COMER PARA ESQUERDA E PARA CIMA
                if (transform.position.x - 1 > -1 && transform.position.y + 1 < 8)
                {
                    Vector3 relative = transform.position + new Vector3(-1, 1, 0);
                    TileInfo tileDestination = GridManager.Tiles[(int)relative.x][(int)relative.y];
                    Token aux;
                    // se a possível posição de destino está ocupada &&
                    // se o meu tile possui um objeto do tipo token &&
                    // se o token aux não for do player &&
                    if (!tileDestination.IsFree() && (aux = tileDestination.inside.GetComponent<Token>()) && aux.player != player)
                    {
                        movablePositions.Add(new Vector2Int((int)relative.x, (int)relative.y));
                    }
                }

                // limitar o deslocamento do peao para a esquerda
                if (transform.position.x - 1 > -1)//Esquerda
                {
                    // verificar se aquela posição no grid está livre
                    if (GridManager.Tiles[(int)transform.position.x][(int)transform.position.y + sign*i].IsFree())
                    {
                        //adicionar todas possíveis posições andáveis à lista de Vector2Int
                        movablePositions.Add(new Vector2Int((int)transform.position.x, (int)transform.position.y + sign*i));
                    }
                }


            }
        }
    }
}

