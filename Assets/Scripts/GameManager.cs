using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    static public GameObject winPanel;
    public static Text winText;

	void Start ()
    {
        winPanel = GameObject.Find("WinPanel");
        winText = GameObject.Find("WinText").GetComponent<Text>();
        winPanel.SetActive(false);
    }
	
    public static void EndGame(int winner)
    {
        winPanel.SetActive(true);
        winText.text = "PLAYER " + winner + " WINS!";
        Debug.Log("Player " + winner + " wins");
    }
}
