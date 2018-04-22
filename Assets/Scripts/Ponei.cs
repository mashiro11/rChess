using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ponei : MonoBehaviour
{
    public Transform spawnPoop;
    public Vector3 startPosition;
    public Vector3 endPosition;
    public float speed = 10;
    public List<Vector3> poopSpawnPositions;
    private bool canWalk = false;

    private void Start()
    {
        transform.position = startPosition;
        poopSpawnPositions = new List<Vector3>();
    }

    private void Update()
    {
        if (canWalk)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
            if (poopSpawnPositions.Count > 0 &&
                spawnPoop.position.x <= poopSpawnPositions[0].x)
            {
                SpawnPoop();
            }
        }
        if (transform.position.x <= endPosition.x)
        {
            canWalk = false;
            transform.position = startPosition;
        }
    }

    void SpawnPoop()
    {
        GameObject poneyPoop = (GameObject)Instantiate(Resources.Load("Poop"), poopSpawnPositions[0], Quaternion.identity);
        poopSpawnPositions.RemoveAt(0);
    }

    void PoopLottery()
    {
        for (int i = 0; i < 3; i++)
        {
            int sorteado = Random.Range(0, GridManager.GetFreeTiles().Count - 1);
            poopSpawnPositions.Add(GridManager.GetFreeTiles()[sorteado].GetPosition());
        }
        SortPoops();
    }

    public void PoneiEvent()
    {
        PoopLottery();
        canWalk = true;
    }

    // ordenar vecto3 do maior pro menor de acordo com o x
    public void SortPoops()
    {
        // PERMUTAÇÃO - BUBBLE SORT
        for(int i = 0; i < poopSpawnPositions.Count-1; i++)
        {
            for(int j = i+1; j < poopSpawnPositions.Count; j++)
            {
                if(poopSpawnPositions[j].x > poopSpawnPositions[i].x)
                {
                    Vector3 temp = poopSpawnPositions[i];
                    poopSpawnPositions[i] = poopSpawnPositions[j];
                    poopSpawnPositions[j] = temp;
                }
            }
        }
    }



}
