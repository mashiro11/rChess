using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileInfo : MonoBehaviour {

    public GameObject inside;
    bool blocked;
    public Vector2Int position;

	// Use this for initialization
	void Start () {
 
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ReceiveObject(GameObject objectReceived)
    {
        inside = objectReceived;
    }

    public bool IsFree()
    {
        return inside == null;
    }

    public void SetPosition(Vector2Int v)
    {
        position = v;
    }
    public Vector3 GetPosition()
    {
        return new Vector3(position.x, position.y, 0);
    }
}
