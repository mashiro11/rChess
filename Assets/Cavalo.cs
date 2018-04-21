using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cavalo : Token {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public override List<Vector2Int> MovablePositions()
    {
        List<Vector2Int> list = new List<Vector2Int>();
        //checar movimentações possiveis do cavalo
        //checar se essa posição é válida no grid
        //ver quais estão livres
        //adicionar em list
        Vector2Int cavaloMovement = new Vector2Int(2,1);
        if (transform.position.x + 2 < 8 )
        {
            if (GridManager.Tiles[(int)transform.position.x + 2][(int)transform.position.x + 1].IsFree())
            {

            }
        }
        if (transform.position.x - 3 > -1)
        {
            if (GridManager.Tiles[(int)transform.position.x - 3][(int)transform.position.x + 1].IsFree())
            {

            }
        }
        return list;
    }
}
