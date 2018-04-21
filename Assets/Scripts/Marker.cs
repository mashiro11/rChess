using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Marker : MonoBehaviour {

    public Token creator;
    // Use this for initialization
	void Start () {
		
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
        creator.MoveTo(transform.position);
    }
}
