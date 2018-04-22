using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torre : Token
{
    bool upFlag = false;
    bool downFlag = false;
    bool rightFlag = false;
    bool leftFlag = false;
    List<Vector3> moves;
    override protected void Start()
    {
        base.Start();
        moves = new List<Vector3>();
        moves.Add(new Vector3(1, 0));
        moves.Add(new Vector3(-1, 0));
        moves.Add(new Vector3(0, 1));
        moves.Add(new Vector3(0,-1));
    }

    public override void CalculateMovablePositions()
    {   
        Token aux;
        for (int i = 1; i < 8; i++)
        {
            if (upFlag == false && transform.position.y + i < 8)//Cima
            {
                if (GridManager.Tiles[(int)transform.position.x][(int)transform.position.y + i].IsFree())
                {
                    movablePositions.Add(new Vector2Int((int)transform.position.x, (int)transform.position.y + i));
                }
                 else if((aux = GridManager.Tiles[(int)transform.position.x][(int)transform.position.y + i].inside.GetComponent<Token>()) && aux.player != player)
                {
                    movablePositions.Add(new Vector2Int((int)transform.position.x, (int)transform.position.y + i));
                    upFlag = true;
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
                else if((aux = GridManager.Tiles[(int)transform.position.x + i][(int)transform.position.y].inside.GetComponent<Token>()) && aux.player != player)
                {
                    movablePositions.Add(new Vector2Int((int)transform.position.x + i, (int)transform.position.y));
                    rightFlag = true;
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

            if (downFlag == false && transform.position.y - i > -1)//Baixo
            {
                if (GridManager.Tiles[(int)transform.position.x][(int)transform.position.y - i].IsFree())
                {
                    movablePositions.Add(new Vector2Int((int)transform.position.x, (int)transform.position.y - i));
                } 
                else if((aux=GridManager.Tiles[(int)transform.position.x][(int)transform.position.y - i].inside.GetComponent<Token>()) && aux.player != player)
                {
                    movablePositions.Add(new Vector2Int((int)transform.position.x, (int)transform.position.y - i));
                    downFlag = true;
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
            
            if (leftFlag == false && transform.position.x - i > -1)//Esquerda
            {
                if (GridManager.Tiles[(int)transform.position.x - i][(int)transform.position.y].IsFree())
                {
                    movablePositions.Add(new Vector2Int((int)transform.position.x - i, (int)transform.position.y));
                }
                else if((aux=GridManager.Tiles[(int)transform.position.x - i][(int)transform.position.y].inside.GetComponent<Token>()) && aux.player != player)
                {
                    movablePositions.Add(new Vector2Int((int)transform.position.x - i, (int)transform.position.y));
                    leftFlag = true;
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

        }
        upFlag = false;
        downFlag = false;
        leftFlag = false;
        rightFlag = false;
    }
}
