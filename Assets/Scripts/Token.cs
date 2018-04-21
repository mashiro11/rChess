using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Token : MonoBehaviour {

    protected static Token selected = null;
    protected List<Vector2Int> movablePositions = new List<Vector2Int>();
    private List<Marker> markers = new List<Marker>();
    public int player;
    // Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    abstract public void CalculateMovablePositions();

    private void OnMouseDown()
    {
        if (selected == null)
        {
            selected = this;
            CalculateMovablePositions();
            ShowMovablePosition();
        }
    }

    protected void ShowMovablePosition()
    {
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
    }
}
