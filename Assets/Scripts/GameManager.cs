using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    static public GameObject winPanel;
    public static Text winText;
    static GameObject capa;
	void Start ()
    {
        winPanel = GameObject.Find("WinPanel");
        winText = GameObject.Find("WinText").GetComponent<Text>();
        capa = GameObject.Find("Capa");
        winPanel.SetActive(false);
    }
	
    public static void EndGame(int winner)
    {
        winPanel.SetActive(true);
        winText.text = "PLAYER " + winner + " WINS!";
        Debug.Log("Player " + winner + " wins");
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            capa.SetActive(false);
            Token.canplay = true;
        }
    }

}
