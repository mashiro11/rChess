using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour {

    public static List<List<TileInfo>> Tiles;
    public GameObject token;
	// Use this for initialization
	void Start () {
        Tiles = new List<List<TileInfo>>();
		for(int i = 0; i < 8; i++)
        {
            Tiles.Add(new List<TileInfo>());
            for(int j = 0; j < 8; j++)
            {
                Tiles[i].Add(new TileInfo());
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.LeftArrow) ||
            Input.GetKeyDown(KeyCode.RightArrow) ||
            Input.GetKeyDown(KeyCode.UpArrow) ||
            Input.GetKeyDown(KeyCode.DownArrow))
        {
            Vector3 position = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0);
            token.transform.position += position;
        }
        
    }
}
