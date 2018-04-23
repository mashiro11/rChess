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
            // if(rei)

            Destroy(GridManager.Tiles[(int)transform.position.x][(int)transform.position.y].inside);
        }
        creator.MoveTo(transform.position);

    }
}
