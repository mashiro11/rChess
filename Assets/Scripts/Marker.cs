using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Marker : MonoBehaviour {
    public Token creator;
    public SpriteRenderer spriteRenderer;
    bool capturePosition = false;
    // Use this for initialization
	void Start () {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (GridManager.Tiles[(int)transform.position.x][(int)transform.position.y].IsFree())
        {
            spriteRenderer.color = new Color(0, 1, 0);
        }else if (GridManager.Tiles[(int)transform.position.x][(int)transform.position.y].inside.GetComponent<Token>().player != creator.player)
        {
            spriteRenderer.color = new Color(1, 0, 0);
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
            Destroy(GridManager.Tiles[(int)transform.position.x][(int)transform.position.y].inside);
        }
        creator.MoveTo(transform.position);

    }
}
