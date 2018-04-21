using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rei : MonoBehaviour
{
/*
    public override void CalculateMovablePositions()
    {
        // CIMA ********************************************
        if (transform.position.y + 1 < 8)
        {
            if (GridManager.Tiles[(int)transform.position.x][(int)transform.position.y + 1].IsFree())
            {
                movablePositions.Add(new Vector2Int((int)transform.position.x, (int)transform.position.y + 1));
            }
        }

        // DIREITA ********************************************
        if (transform.position.x + 1 < 8)
            {
                if (GridManager.Tiles[(int)transform.position.x + 1][(int)transform.position.y].IsFree())
                {
                    movablePositions.Add(new Vector2Int((int)transform.position.x + 1, (int)transform.position.y));
                }
            }

        // CIMA E DIREITA *********************************************************************
        if (transform.position.x + 1 < 8 && transform.position.y + 1 < 8)
        {
            if (GridManager.Tiles[(int)transform.position.x + 1][(int)transform.position.y + 1].IsFree())
            {
                movablePositions.Add(new Vector2Int((int)transform.position.x + 1, (int)transform.position.y + 1));
            }            
        }

        // BAIXO **********************************************
        if (transform.position.y - 1 > -1)
        {
            if (GridManager.Tiles[(int)transform.position.x][(int)transform.position.y - 1].IsFree())
            {
                movablePositions.Add(new Vector2Int((int)transform.position.x, (int)transform.position.y - 1));

            }
        }

        // BAIXO E DIREITA *************************************************************************
        if (transform.position.x + 1 < 8 && transform.position.y - 1 > -1)
        {
            if (GridManager.Tiles[(int)transform.position.x + 1][(int)transform.position.y - 1].IsFree())
            {
                movablePositions.Add(new Vector2Int((int)transform.position.x + 1, (int)transform.position.y - 1));
            }
        }

        // ESQUERDA *******************************************
        if (transform.position.x - 1 > -1)
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
    }

    */
}