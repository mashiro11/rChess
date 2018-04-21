using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rainha : Token
{
    bool upFlag = false;
    bool rightFlag = false;
    bool downFlag = false;
    bool leftFlag = false;

    bool upRightFlag = false;
    bool downRightFlag = false;
    bool upLeftFlag = false;
    bool downLeftFlag = false;
    
    public override void CalculateMovablePositions()
    {
        for (int i = 1; i < 8; i++)
        {
            if (upFlag == false && transform.position.y + i < 8)//Cima
            {
                // chamar função que fala que aquele tile está null
                if (GridManager.Tiles[(int)transform.position.x][(int)transform.position.y + i].IsFree())
                {
                    movablePositions.Add(new Vector2Int((int)transform.position.x, (int)transform.position.y + i));
                }

                else
                {
                    if (upFlag == true && rightFlag == true && downFlag == true && leftFlag == true)
                    {
                        break;
                    }

                    else
                    {
                        upFlag = true;
                    }
                }
            }

            if (rightFlag == false && transform.position.x + i < 8)//Direita
            {
                if (GridManager.Tiles[(int)transform.position.x + i][(int)transform.position.y].IsFree())
                {
                    movablePositions.Add(new Vector2Int((int)transform.position.x + i, (int)transform.position.y));
                }

                else
                {
                    if (rightFlag == true && downFlag == true && leftFlag == true && upFlag == true)
                    {
                        break;
                    }

                    else
                    {
                        rightFlag = true;
                    }
                }
            }

            // CIMA E DIREITA
            if (upRightFlag == false && transform.position.x + i < 8 && transform.position.y + i < 8)
            {
                if (GridManager.Tiles[(int)transform.position.x + i][(int)transform.position.y + i].IsFree())
                {
                    movablePositions.Add(new Vector2Int((int)transform.position.x + i, (int)transform.position.y + i));
                }

                else
                {
                    if (rightFlag == true && downFlag == true && leftFlag == true && upFlag == true)
                    {
                        break;
                    }

                    else
                    {
                        upRightFlag = true;
                    }
                }
            }

            if (downFlag == false && transform.position.y - i > -1)//Baixo
            {
                if (GridManager.Tiles[(int)transform.position.x][(int)transform.position.y - i].IsFree())
                {
                    movablePositions.Add(new Vector2Int((int)transform.position.x, (int)transform.position.y - i));

                }

                else
                {
                    if (downFlag == true && leftFlag == true && upFlag == true && rightFlag == true)
                    {
                        break;
                    }

                    else
                    {
                        downFlag = true;
                    }
                }
            }

            // BAIXO E DIREITA
            if (downRightFlag == false && transform.position.x + i < 8 && transform.position.y - i > -1)
            {
                if (GridManager.Tiles[(int)transform.position.x + i][(int)transform.position.y - i].IsFree())
                {
                    movablePositions.Add(new Vector2Int((int)transform.position.x + i, (int)transform.position.y - i));
                }

                else
                {
                    if (rightFlag == true && downFlag == true && leftFlag == true && upFlag == true)
                    {
                        break;
                    }

                    else
                    {
                        downRightFlag = true;
                    }
                }
            }

            if (leftFlag == false && transform.position.x - i > -1)//Esquerda
            {
                if (GridManager.Tiles[(int)transform.position.x - i][(int)transform.position.y].IsFree())
                {
                    movablePositions.Add(new Vector2Int((int)transform.position.x - i, (int)transform.position.y));
                }

                else
                {
                    if (leftFlag == true && upFlag == true && rightFlag == true && downFlag == true)
                    {
                        break;
                    }

                    else
                    {
                        leftFlag = true;
                    }
                }
            }

            // CIMA E ESQUERDA
            if (upLeftFlag == false && transform.position.x - i > -1 && transform.position.y + i < 8)
            {
                if (GridManager.Tiles[(int)transform.position.x - i][(int)transform.position.y + i].IsFree())
                {
                    movablePositions.Add(new Vector2Int((int)transform.position.x - i, (int)transform.position.y + i));
                }

                else
                {
                    if (rightFlag == true && downFlag == true && leftFlag == true && upFlag == true)
                    {
                        break;
                    }

                    else
                    {
                        upLeftFlag = true;
                    }
                }
            }

            // BAIXO E ESQUERDA
            if (downLeftFlag == false && transform.position.x - i > -1 && transform.position.y - i > -1)
            {
                if (GridManager.Tiles[(int)transform.position.x - i][(int)transform.position.y - i].IsFree())
                {
                    movablePositions.Add(new Vector2Int((int)transform.position.x - i, (int)transform.position.y - i));
                }

                else
                {
                    if (rightFlag == true && downFlag == true && leftFlag == true && upFlag == true)
                    {
                        break;
                    }

                    else
                    {
                        downLeftFlag = true;
                    }
                }
            }


        }
        upFlag = false;
        downFlag = false;
        leftFlag = false;
        rightFlag = false;

        upRightFlag = false;
        downRightFlag = false;
        upLeftFlag = false;
        downLeftFlag = false;
    }


}
