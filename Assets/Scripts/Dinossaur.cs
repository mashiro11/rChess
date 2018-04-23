using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dinossaur : MonoBehaviour {

    public Transform dinoJaw;
    public Vector3 startPosition;
    public Vector3 endPosition;
    public float speed = 1;
    public List<Vector3> gonnaDie;
    private bool canWalk = false;

    private enum DinoStates
    {
        WALK,
        EAT,
        IDLE
    }
    DinoStates currentState = DinoStates.IDLE;

    private void Start()
    {
        startPosition = transform.position;
        dinoJaw = transform;
        endPosition = new Vector3(-10, 0, 0);
        transform.position = startPosition;
        gonnaDie = new List<Vector3>();
    }

    private void Update()
    {
        switch (currentState)
        {
            case DinoStates.WALK:
                Vector3 dest;
                if(gonnaDie.Count > 0)
                {
                    dest = gonnaDie[0];
                }
                else
                {
                    dest = endPosition;
                }

                Vector3 inc = Vector3.zero;
                if(dest.x <= transform.position.x)
                {
                    inc += Vector3.left;
                }
                if (dest.y <= transform.position.y)
                {
                    inc += Vector3.down;
                }else if(dest.y >= transform.position.y)
                {
                    inc += Vector3.up;
                }

                inc = transform.position + inc*Time.deltaTime*speed;
                inc.x = Mathf.Clamp(inc.x, dest.x, transform.position.x);
                inc.y = Mathf.Clamp(inc.y, dest.y, transform.position.y);
                inc.z = Mathf.Clamp(inc.z, dest.z, transform.position.z);
                transform.position = inc;

                Debug.Log("Dest: " + dest);
                if (Vector3.Distance( transform.position, dest) < 0.01f)
                {
                    currentState = DinoStates.EAT;
                }
                if (gonnaDie.Count == 0 && Vector3.Distance(transform.position, dest) < 0.01f)
                {
                    canWalk = false;
                    currentState = DinoStates.IDLE;
                    transform.position = startPosition;
                }
                break;
            case DinoStates.EAT:
                Eat();
                currentState = DinoStates.WALK;
                break;
            case DinoStates.IDLE:
                transform.position = startPosition;
                break;
        }
    }

    void Eat()
    {
        Destroy(GridManager.Tiles[(int)gonnaDie[0].x][(int)gonnaDie[0].y].inside);
        gonnaDie.RemoveAt(0);
    }

    void DieLottery()
    {
        for (int i = 0; i < 2; i++)
        {
            int sorteado = Random.Range(0, GridManager.Tokens[i].Count - 1);
            gonnaDie.Add(GridManager.Tokens[i][sorteado].transform.position);
        }
        SortTargets();
        Debug.Log("sorteado: " + gonnaDie[0]);
        Debug.Log("sorteado: " + gonnaDie[1]);
    }

    public void DinoEvent()
    {
        DieLottery();
        currentState = DinoStates.WALK;
    }

    // ordenar vecto3 do maior pro menor de acordo com o x
    public void SortTargets()
    {
        // PERMUTAÇÃO - BUBBLE SORT
        for (int i = 0; i < gonnaDie.Count - 1; i++)
        {
            for (int j = i + 1; j < gonnaDie.Count; j++)
            {
                if (gonnaDie[j].x > gonnaDie[i].x)
                {
                    Vector3 temp = gonnaDie[i];
                    gonnaDie[i] = gonnaDie[j];
                    gonnaDie[j] = temp;
                }
            }
        }
    }

}
