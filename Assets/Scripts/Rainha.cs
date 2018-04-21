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
            // CIMA ********************************************
            if (upFlag == false && transform.position.y + i < 8)
            {
                if (GridManager.Tiles[(int)transform.position.x][(int)transform.position.y + i].IsFree())
                {
                    movablePositions.Add(new Vector2Int((int)transform.position.x, (int)transform.position.y + i));
                }

                else
                {
                    if (upFlag == true && rightFlag == true && downFlag == true && leftFlag == true && upRightFlag == true &&
                      downRightFlag == true && upLeftFlag == true && downLeftFlag == true)
                    {
                        break;
                    }

                    else
                    {
                        upFlag = true;
                    }
                }
            }

            // DIREITA ********************************************
            if (rightFlag == false && transform.position.x + i < 8)
            {
                if (GridManager.Tiles[(int)transform.position.x + i][(int)transform.position.y].IsFree())
                {
                    movablePositions.Add(new Vector2Int((int)transform.position.x + i, (int)transform.position.y));
                }

                else
                {
                    if (upFlag == true && rightFlag == true && downFlag == true && leftFlag == true && upRightFlag == true &&
                      downRightFlag == true && upLeftFlag == true && downLeftFlag == true)
                    {
                        break;
                    }

                    else
                    {
                        rightFlag = true;
                    }
                }
            }

            // CIMA E DIREITA *********************************************************************
            if (upRightFlag == false && transform.position.x + i < 8 && transform.position.y + i < 8)
            {
                if (GridManager.Tiles[(int)transform.position.x + i][(int)transform.position.y + i].IsFree())
                {
                    movablePositions.Add(new Vector2Int((int)transform.position.x + i, (int)transform.position.y + i));
                }

                else
                {
                    if (upFlag == true && rightFlag == true && downFlag == true && leftFlag == true && upRightFlag == true &&
                      downRightFlag == true && upLeftFlag == true && downLeftFlag == true)
                    {
                        break;
                    }

                    else
                    {
                        upRightFlag = true;
                    }
                }
            }

            // BAIXO **********************************************
            if (downFlag == false && transform.position.y - i > -1)
            {
                if (GridManager.Tiles[(int)transform.position.x][(int)transform.position.y - i].IsFree())
                {
                    movablePositions.Add(new Vector2Int((int)transform.position.x, (int)transform.position.y - i));

                }

                else
                {
                    if (upFlag == true && rightFlag == true && downFlag == true && leftFlag == true && upRightFlag == true &&
                      downRightFlag == true && upLeftFlag == true && downLeftFlag == true)
                    {
                        break;
                    }

                    else
                    {
                        downFlag = true;
                    }
                }
            }

            // BAIXO E DIREITA *************************************************************************
            if (downRightFlag == false && transform.position.x + i < 8 && transform.position.y - i > -1)
            {
                if (GridManager.Tiles[(int)transform.position.x + i][(int)transform.position.y - i].IsFree())
                {
                    movablePositions.Add(new Vector2Int((int)transform.position.x + i, (int)transform.position.y - i));
                }

                else
                {
                    if (upFlag == true && rightFlag == true && downFlag == true && leftFlag == true && upRightFlag == true &&
                      downRightFlag == true && upLeftFlag == true && downLeftFlag == true)
                    {
                        break;
                    }

                    else
                    {
                        downRightFlag = true;
                    }
                }
            }

            // ESQUERDA *******************************************
            if (leftFlag == false && transform.position.x - i > -1)
            {
                if (GridManager.Tiles[(int)transform.position.x - i][(int)transform.position.y].IsFree())
                {
                    movablePositions.Add(new Vector2Int((int)transform.position.x - i, (int)transform.position.y));
                }

                else
                {
                    if (upFlag == true && rightFlag == true && downFlag == true && leftFlag == true && upRightFlag == true &&
                      downRightFlag == true && upLeftFlag == true && downLeftFlag == true)
                    {
                        break;
                    }

                    else
                    {
                        leftFlag = true;
                    }
                }
            }

            // CIMA E ESQUERDA *********************************************************************
            if (upLeftFlag == false && transform.position.x - i > -1 && transform.position.y + i < 8)
            {
                if (GridManager.Tiles[(int)transform.position.x - i][(int)transform.position.y + i].IsFree())
                {
                    movablePositions.Add(new Vector2Int((int)transform.position.x - i, (int)transform.position.y + i));
                }

                else
                {
                    if (upFlag == true && rightFlag == true && downFlag == true && leftFlag == true && upRightFlag == true &&
                      downRightFlag == true && upLeftFlag == true && downLeftFlag == true)
                    {
                        break;
                    }

                    else
                    {
                        upLeftFlag = true;
                    }
                }
            }

            // BAIXO E ESQUERDA ***********************************************************************
            if (downLeftFlag == false && transform.position.x - i > -1 && transform.position.y - i > -1)
            {
                if (GridManager.Tiles[(int)transform.position.x - i][(int)transform.position.y - i].IsFree())
                {
                    movablePositions.Add(new Vector2Int((int)transform.position.x - i, (int)transform.position.y - i));
                }

                else
                {
                    if (upFlag == true && rightFlag == true && downFlag == true && leftFlag == true && upRightFlag == true &&
                      downRightFlag == true && upLeftFlag == true && downLeftFlag == true)
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
