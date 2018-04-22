using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Token : MonoBehaviour {

    protected static Token selected = null;
    protected List<Vector2Int> movablePositions = new List<Vector2Int>();
    private List<Marker> markers = new List<Marker>();
    private List<Marker> capturable = new List<Marker>();
    public int player;
    // Use this for initialization
	virtual protected void Start () {
        Debug.Log(this.name + " position: " + transform.position);
        if (player == 2)
        {
            GetComponent<SpriteRenderer>().color = new Color(0, 1, 0, 0.5f);
        }
	}
	
    abstract public void CalculateMovablePositions();

    private void OnMouseDown()
    {
        if ((int)TurnManager.CurrentState == player)
        {
            Debug.Log("Agora é o turno do: " + TurnManager.CurrentState + " e a peça clicada foi: " + player);

            if (selected == null)
            {
                selected = this;
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
        RemoveMarkers();
        TurnManager.LastState = TurnManager.CurrentState;
        Debug.Log("O turno do: " + TurnManager.CurrentState + "acabou");
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
}
