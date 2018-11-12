using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour {

    public Transform[] Goals;
    public GameObject ObjectToMove;
    public float Speed;

    private int RandomInx;
    private int PrevRandom;

	// Use this for initialization
	void Start () {
        RandomInx = Random.Range(0, (Goals.Length));
        PrevRandom = -1;
	}
	
	// Update is called once per frame
	void  LateUpdate () {

        ObjectToMove.transform.LookAt(Goals[RandomInx].transform.position);

        if (Vector3.Distance(ObjectToMove.transform.position, Goals[RandomInx].transform.position) >2f)
        {

            ObjectToMove.transform.Translate(0,0,Speed * Time.deltaTime);
        }
        else
        {
            RandomInx = CreateRandomIndex();
        }
	}


    private int CreateRandomIndex()
    {
        RandomInx = Random.Range(0, (Goals.Length));

        while (RandomInx == PrevRandom)
        {
            RandomInx = Random.Range(0, (Goals.Length));
        }

        PrevRandom = RandomInx;

        return RandomInx;

    }
}
