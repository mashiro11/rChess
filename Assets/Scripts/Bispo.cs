using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bispo : Token
{
    bool upRightFlag = false;
    bool downRightFlag = false;
    bool upLeftFlag = false;
    bool downLeftFlag = false;

    public override void CalculateMovablePositions()
    {
        for (int i = 1; i < 8; i++)
        {

            // CIMA E DIREITA *********************************************************************
            if (upRightFlag == false && transform.position.x + i < 8 && transform.position.y + i < 8)
            {
                if (GridManager.Tiles[(int)transform.position.x + i][(int)transform.position.y + i].IsFree())
                {
                    movablePositions.Add(new Vector2Int((int)transform.position.x + i, (int)transform.position.y + i));
                }

                else
                {
                    if (upRightFlag == true && downRightFlag == true && upLeftFlag == true && downLeftFlag == true)
                    {
                        break;
                    }

                    else
                    {
                        upRightFlag = true;
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
                    if (upRightFlag == true && downRightFlag == true && upLeftFlag == true && downLeftFlag == true)
                    {
                        break;
                    }

                    else
                    {
                        downRightFlag = true;
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
                    if (upRightFlag == true && downRightFlag == true && upLeftFlag == true && downLeftFlag == true)
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
                    if (upRightFlag == true && downRightFlag == true && upLeftFlag == true && downLeftFlag == true)
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
        upRightFlag = false;
        downRightFlag = false;
        upLeftFlag = false;
        downLeftFlag = false;
    }
}
