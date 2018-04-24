using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByTurn : MonoBehaviour
{
    public int spawnTurn;

    private void Update()
    {
        if (TurnManager.TurnCount - spawnTurn > 1)
        {
            Destroy(gameObject);
        }
    }

    public void SetSpawnTurn(int num)
    {
        spawnTurn = num;
    }
}
