using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileInfo : MonoBehaviour {

    GameObject inside = null;
    bool blocked = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void ReceiveToken(GameObject token)
    {
        inside = token;
    }

    public bool IsFree()
    {
        return inside == null;
    }
}
