using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Token : MonoBehaviour {

    protected static Token selected = null;
    protected List<Vector2Int> movablePositions = new List<Vector2Int>();
    private List<Marker> markers = new List<Marker>();
    private List<Marker> capturable = new List<Marker>();
    public int player;
    public Sprite[] sprites;
    public static GameObject selector = null;

	virtual protected void Start () {
        if(selector == null)
        {
            selector = (GameObject)Instantiate(Resources.Load("SelectorPrefab"),Vector3.zero,Quaternion.identity);
            selector.SetActive(false);
        }
        Debug.Log(this.name + " position: " + transform.position);
        if (player == 2)
        {
            //GetComponent<SpriteRenderer>().color = new Color(0, 1, 0, 0.5f);
            GetComponent<SpriteRenderer>().sprite = sprites[1];
        }
	}
	
    abstract public void CalculateMovablePositions();

    private void OnMouseDown()
    {
        Debug.Log("Foi clicado");
        Debug.Log("CurrentState: " + (int)TurnManager.CurrentState);
        Debug.Log("player: " + player);

        if ((int)TurnManager.CurrentState == player)
        {
            Debug.Log("Agora é o turno do: " + TurnManager.CurrentState + " e a peça clicada foi: " + player);

            if (selected == null)
            {
                selected = this;
                selector.transform.position = transform.position;
                selector.SetActive(true);
                CalculateMovablePositions();
                ShowMovablePosition();
            }
        }
    }

    protected void ShowMovablePosition()
    {
        if (movablePositions.Count == 0)
        {
            selected = null;
            return;
        }
        Vector3 v = new Vector3();
        for(int i = 0; i < movablePositions.Count; i++)
        {
            v.Set(movablePositions[i].x, movablePositions[i].y, 0);
            markers.Add(((GameObject)Instantiate(Resources.Load("Marker"), v, Quaternion.identity)).GetComponent<Marker>());
            markers[markers.Count-1].creator = this;
        }
    }
    public void RemoveMarkers()
    {
        for(int i = 0; i < markers.Count; i++)
        {
            Destroy(markers[i].gameObject);
        }
        markers.Clear();
        selected = null;
        movablePositions.Clear();
    }
    public void MoveTo(Vector3 v)
    {
        GridManager.Tiles[(int)transform.position.x][(int)transform.position.y].inside = null;
        transform.position = v;
        GridManager.Tiles[(int)transform.position.x][(int)transform.position.y].inside = gameObject;
        selected = null;
        selector.SetActive(false);
        RemoveMarkers();

        if (IsCheck())
        {
            Debug.Log("Xeque!");
        }
        TurnManager.LastState = TurnManager.CurrentState;
        Debug.Log("O turno do: " + TurnManager.CurrentState + "acabou");
        TurnManager.TurnCount++;
        Debug.Log("O turno é: " + TurnManager.TurnCount);
        TurnManager.CurrentState = TurnManager.TurnState.DiceRoll;
        Debug.Log("Agora os dados vão rolar");
    }
    protected bool IsValid(Vector3 position)
    {
        Vector3 temp = transform.position + position;
        if (-1 < temp.x && temp.x < 8 &&
            -1 < temp.y && temp.y < 8)
        {
            return true;
        }
        return false;
    }
    bool IsCheck()
    {
        Debug.Log("Testando o Check");
        CalculateMovablePositions();
        for(int i = 0; i < movablePositions.Count; i++)
        {
            Debug.Log("Movable: " + movablePositions[i]);
        }
        Token aux;
        for (int i = 0; i < movablePositions.Count; i++)
        {
            if(!GridManager.Tiles[movablePositions[i].x][movablePositions[i].y].IsFree() &&
               (aux = GridManager.Tiles[movablePositions[i].x][movablePositions[i].y].inside.GetComponent<Rei>()))
            {
                movablePositions.Clear();
                return true;
            }
        }
        movablePositions.Clear();
        return false;
    }
}
