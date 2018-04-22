using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cavalo : Token {

    List<Vector3> moves = new List<Vector3>();
    // Update is called once per frame
    override protected void Start()
    {
        base.Start();
        moves.Add(new Vector3(-2, 1, 0));
        moves.Add(new Vector3(-1, 2, 0));
        moves.Add(new Vector3( 1, 2, 0));
        moves.Add(new Vector3( 2, 1, 0));
        moves.Add(new Vector3( 2,-1, 0));
        moves.Add(new Vector3(-1,-2, 0));
        moves.Add(new Vector3( 1,-2, 0));
        moves.Add(new Vector3(-2,-1, 0));

    }
    void Update () {
	}

    public override void CalculateMovablePositions()
    {
        //checar movimentações possiveis do cavalo
        //checar se essa posição é válida no grid
        //ver quais estão livres
        //adicionar em list
        //Verifica se é uma posição que existe no grid
        for(int i = 0; i < moves.Count; i++)
        {
            if (IsValid(moves[i]))
            {
                Vector3 relative = transform.position + moves[i];
                TileInfo tileDestination = GridManager.Tiles[(int)relative.x][(int)relative.y];
                Token aux;
                if (tileDestination.IsFree() || (aux = tileDestination.inside.GetComponent<Token>()) && aux.player != player)
                {
                    movablePositions.Add(new Vector2Int((int)relative.x, (int)relative.y));
                }
            }
        }
    }
}
