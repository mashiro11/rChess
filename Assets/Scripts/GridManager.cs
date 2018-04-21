using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour {

    public static List<List<TileInfo>> Tiles;
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
        GameObject aux;
        //Torres baixo
        aux = Tiles[0][0].inside = (GameObject)Instantiate(Resources.Load("Torre"), new Vector3(0, 0, 0), Quaternion.identity);
        aux.GetComponent<Token>().player = 1;
        aux = Tiles[7][0].inside = (GameObject)Instantiate(Resources.Load("Torre"), new Vector3(7, 0, 0), Quaternion.identity);
        aux.GetComponent<Token>().player = 1;
        //Cavalos baixo
        aux = Tiles[1][0].inside = (GameObject)Instantiate(Resources.Load("Cavalo"), new Vector3(1, 0, 0), Quaternion.identity);
        aux.GetComponent<Token>().player = 1;
        aux = Tiles[6][0].inside = (GameObject)Instantiate(Resources.Load("Cavalo"), new Vector3(6, 0, 0), Quaternion.identity);
        aux.GetComponent<Token>().player = 1;
        //Bispo baixo
        aux = Tiles[2][0].inside = (GameObject)Instantiate(Resources.Load("Bispo"), new Vector3(2, 0, 0), Quaternion.identity);
        aux.GetComponent<Token>().player = 1;
        aux = Tiles[5][0].inside = (GameObject)Instantiate(Resources.Load("Bispo"), new Vector3(5, 0, 0), Quaternion.identity);
        aux.GetComponent<Token>().player = 1;
        //Rainha baixo
        aux = Tiles[3][0].inside = (GameObject)Instantiate(Resources.Load("Rainha"), new Vector3(3, 0, 0), Quaternion.identity);
        aux.GetComponent<Token>().player = 1;


        //Torres cima
        aux = Tiles[0][7].inside = (GameObject)Instantiate(Resources.Load("Torre"), new Vector3(0, 7, 0), Quaternion.identity);
        aux.GetComponent<Token>().player = 2;
        aux = Tiles[7][7].inside = (GameObject)Instantiate(Resources.Load("Torre"), new Vector3(7, 7, 0), Quaternion.identity);
        aux.GetComponent<Token>().player = 2;
        //Cavalos cima
        aux = Tiles[1][7].inside = (GameObject)Instantiate(Resources.Load("Cavalo"), new Vector3(1, 7, 0), Quaternion.identity);
        aux.GetComponent<Token>().player = 2;
        aux = Tiles[6][7].inside = (GameObject)Instantiate(Resources.Load("Cavalo"), new Vector3(6, 7, 0), Quaternion.identity);
        aux.GetComponent<Token>().player = 2;
        //Bispo cima
        aux = Tiles[2][7].inside = (GameObject)Instantiate(Resources.Load("Bispo"), new Vector3(2, 7, 0), Quaternion.identity);
        aux.GetComponent<Token>().player = 2;
        aux = Tiles[5][7].inside = (GameObject)Instantiate(Resources.Load("Bispo"), new Vector3(5, 7, 0), Quaternion.identity);
        aux.GetComponent<Token>().player = 2;
        //Rainha cima
        aux = Tiles[3][7].inside = (GameObject)Instantiate(Resources.Load("Rainha"), new Vector3(3, 7, 0), Quaternion.identity);
        aux.GetComponent<Token>().player = 2;


        //Peoes
        for (int i = 0; i < 8; i++)
        {
            //baixo
            aux = Tiles[i][1].inside = (GameObject)Instantiate(Resources.Load("Peao"), new Vector3(i, 1, 0), Quaternion.identity);
            aux.GetComponent<Token>().player = 1;
            //cima
            aux = Tiles[i][6].inside = (GameObject)Instantiate(Resources.Load("Peao"), new Vector3(i, 6, 0), Quaternion.identity);
            aux.GetComponent<Token>().player = 2;
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
