using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Marker : MonoBehaviour {
    public Token creator;
    public SpriteRenderer spriteRenderer;
    public Sprite[] sprites;
    bool capturePosition = false;


    void Start ()
    {
        Token aux;

        spriteRenderer = GetComponent<SpriteRenderer>();
        if (GridManager.Tiles[(int)transform.position.x][(int)transform.position.y].IsFree())
        {
            spriteRenderer.sprite = sprites[0];
        }

        else if ((aux = GridManager.Tiles[(int)transform.position.x][(int)transform.position.y].inside.GetComponent<Token>()) &&
            aux.player != creator.player)
        {
            GridManager.Tiles[(int)transform.position.x][(int)transform.position.y].inside.GetComponent<Token>();
            spriteRenderer.sprite = sprites[1];
            capturePosition = true;
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void SetCreator(Token creator)
    {
        this.creator = creator;
    }

    private void OnMouseDown()
    {
        if(capturePosition)
        {
            Token tk = GridManager.Tiles[(int)transform.position.x][(int)transform.position.y].inside.GetComponent<Token>();
            int index = 0;
            for (int i = 0; i < GridManager.Tokens[creator.player - 1].Count; i++)
            {
                if (GridManager.Tokens[creator.player - 1][i] == tk)
                {
                    index = i;
                    break;
                }
            }
            GridManager.Tokens[creator.player - 1].RemoveAt(index);
            //if rei
            Destroy(tk.gameObject);
            Debug.Log("Objeto " + name + " destruido");
            if(tk.name == "Rei")
            {
                GameManager.EndGame(creator.player);
            }
        }
        creator.MoveTo(transform.position);
    }
}
