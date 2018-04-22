using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour {

    public static List<List<TileInfo>> Tiles;
    public static List<List<Token>> Tokens;
	// Use this for initialization
	void Start () {
        Tiles = new List<List<TileInfo>>();
		for(int i = 0; i < 8; i++)
        {
            Tiles.Add(new List<TileInfo>());
            for(int j = 0; j < 8; j++)
            {
                Tiles[i].Add(new TileInfo());
                Tiles[i][j].SetPosition(new Vector2Int(i, j));
            }
        }
        StartTable();
    }
	
	// Update is called once per frame
	void Update () {
    }
    private void StartTable()
    {
        //linha varia com x
        //coluna varia com y
        //linhas serão da direita
        //colunas serão da esquerda
        //Torres baixo

        List<string> Pecas = new List<string>();
        Pecas.Add("Pecas/Torre");
        Pecas.Add("Pecas/Cavalo");
        Pecas.Add("Pecas/Bispo");
        Pecas.Add("Pecas/Rainha");
        Pecas.Add("Pecas/Rei");

        Tokens = new List<List<Token>>();
        Tokens.Add(new List<Token>());
        Tokens.Add(new List<Token>());

        GameObject aux;
        for (int j = 0; j < 2; j++)
        {
            int line = (j == 0) ? 0 : 7;
            for (int i = 0; i < Pecas.Count + 3; i++)
            {
                int peca = (i > 4) ? 7 - i : i;
                aux = Tiles[i][line].inside = (GameObject)Instantiate(Resources.Load(Pecas[peca]), new Vector3(i, line, 0), Quaternion.identity);
                Tokens[j].Add(aux.GetComponent<Token>());
                Tokens[j][Tokens[j].Count - 1].player = j + 1;
            }
            line = (line == 0) ? 1 : 6;
            for (int i = 0; i < 8; i++)
            {
                aux = Tiles[i][line].inside = (GameObject)Instantiate(Resources.Load("Pecas/Peao"), new Vector3(i, line, 0), Quaternion.identity);
                Tokens[j].Add(aux.GetComponent<Token>());
                Tokens[j][Tokens[j].Count - 1].player = j + 1;
            }
        }
        
        for (int i = 0; i < Tiles.Count; i++)
        {
            for(int j = 0; j < Tiles[i].Count; j++)
            {
                GameObject auxObj = Tiles[i][j].inside;
                Token auxTok;
                if (auxObj && (auxTok = auxObj.GetComponent<Token>()) )
                {
                    Debug.Log("[" + i + "][" + j + "]: " + auxTok.name + "| " + auxTok.transform.position + "player: " + auxTok.player);
                }
            }
        }
    }
    public static List<TileInfo> GetFreeTiles()
    {
        List<TileInfo> freeTiles = new List<TileInfo>();
        for(int i = 0; i < Tiles.Count; i++)
        {
            for(int j = 0; j < Tiles[i].Count; j++)
            {
                if (Tiles[i][j].IsFree())
                {
                    freeTiles.Add(Tiles[i][j]);
                }
            }
        }
        return freeTiles;
    }
}


/*
        aux = Tiles[0][0].inside = (GameObject) Instantiate(Resources.Load("Torre"), new Vector3(0, 0, 0), Quaternion.identity);
        Tokens[0].Add(aux.GetComponent<Token>());
        Tokens[0][0].player = 1;

        aux = Tiles[7][0].inside = (GameObject)Instantiate(Resources.Load("Torre"), new Vector3(7, 0, 0), Quaternion.identity);
        Tokens[0].Add(aux.GetComponent<Token>());
        Tokens[0][1].player = 1;
        
        //Cavalos baixo
        aux = Tiles[1][0].inside = (GameObject)Instantiate(Resources.Load("Cavalo"), new Vector3(1, 0, 0), Quaternion.identity);
        Tokens[0].Add(aux.GetComponent<Token>());
        Tokens[0][2].player = 1;

        aux = Tiles[6][0].inside = (GameObject)Instantiate(Resources.Load("Cavalo"), new Vector3(6, 0, 0), Quaternion.identity);
        Tokens[0].Add(aux.GetComponent<Token>());
        Tokens[0][3].player = 1;
        
        //Bispo baixo
        aux = Tiles[2][0].inside = (GameObject)Instantiate(Resources.Load("Bispo"), new Vector3(2, 0, 0), Quaternion.identity);
        Tokens[0].Add(aux.GetComponent<Token>());
        Tokens[0][4].player = 1;

        aux = Tiles[5][0].inside = (GameObject)Instantiate(Resources.Load("Bispo"), new Vector3(5, 0, 0), Quaternion.identity);
        Tokens[0].Add(aux.GetComponent<Token>());
        Tokens[0][5].player = 1;
        
        //Rainha baixo
        aux = Tiles[3][0].inside = (GameObject)Instantiate(Resources.Load("Rainha"), new Vector3(3, 0, 0), Quaternion.identity);
        Tokens[0].Add(aux.GetComponent<Token>());
        Tokens[0][6].player = 1;
        
        
        //Rei baixo
        aux = Tiles[4][0].inside = (GameObject)Instantiate(Resources.Load("Rei"), new Vector3(4, 0, 0), Quaternion.identity);
        Tokens[0].Add(aux.GetComponent<Token>());
        Tokens[0][7].player = 1;


        
        //Torres cima
        aux = Tiles[0][7].inside = (GameObject)Instantiate(Resources.Load("Torre"), new Vector3(0, 7, 0), Quaternion.identity);
        Tokens[1].Add(aux.GetComponent<Token>());
        Tokens[1][0].player = 2;

        aux = Tiles[7][7].inside = (GameObject)Instantiate(Resources.Load("Torre"), new Vector3(7, 7, 0), Quaternion.identity);
        Tokens[1].Add(aux.GetComponent<Token>());
        Tokens[1][1].player = 2;

        
        //Cavalos cima
        aux = Tiles[1][7].inside = (GameObject)Instantiate(Resources.Load("Cavalo"), new Vector3(1, 7, 0), Quaternion.identity);
        Tokens[1].Add(aux.GetComponent<Token>());
        Tokens[1][2].player = 2;

        aux = Tiles[6][7].inside = (GameObject)Instantiate(Resources.Load("Cavalo"), new Vector3(6, 7, 0), Quaternion.identity);
        Tokens[1].Add(aux.GetComponent<Token>());
        Tokens[1][3].player = 2;
        
        //Bispo cima
        aux = Tiles[2][7].inside = (GameObject)Instantiate(Resources.Load("Bispo"), new Vector3(2, 7, 0), Quaternion.identity);
        Tokens[1].Add(aux.GetComponent<Token>());
        Tokens[1][4].player = 2;

        aux = Tiles[5][7].inside = (GameObject)Instantiate(Resources.Load("Bispo"), new Vector3(5, 7, 0), Quaternion.identity);
        Tokens[1].Add(aux.GetComponent<Token>());
        Tokens[1][5].player = 2;
        
        //Rainha cima
        aux = Tiles[3][7].inside = (GameObject)Instantiate(Resources.Load("Rainha"), new Vector3(3, 7, 0), Quaternion.identity);
        Tokens[1].Add(aux.GetComponent<Token>());
        Tokens[1][6].player = 2;
        
        //Rei cima
        aux = Tiles[4][7].inside = (GameObject)Instantiate(Resources.Load("Rei"), new Vector3(4, 7, 0), Quaternion.identity);
        Tokens[1].Add(aux.GetComponent<Token>());
        Tokens[1][7].player = 2;
        */
/*
    //Peoes
    for (int i = 0; i < 8; i++)
    {
        //baixo
        aux = Tiles[i][1].inside = (GameObject)Instantiate(Resources.Load("Peao"), new Vector3(i, 1, 0), Quaternion.identity);
        Tokens[0].Add(aux.GetComponent<Token>());
        Tokens[0][i+8].player = 1;
        //cima
        aux = Tiles[i][6].inside = (GameObject)Instantiate(Resources.Load("Peao"), new Vector3(i, 6, 0), Quaternion.identity);
        Tokens[1].Add(aux.GetComponent<Token>());
        Tokens[1][i + 8].player = 2;
        Debug.Log("i: " + i);
    }
    */
