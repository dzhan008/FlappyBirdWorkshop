using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public Transform SpawnPoint;
    public GameObject PipeSet;

	// Use this for initialization
	void Start () {
        InvokeRepeating("SpawnPipe", 2, 1);
	}
	
	// Update is called once per frame
	void Update ()
    {
      
	}

    void SpawnPipe()
    {
        GameObject new_pipes = GameObject.Instantiate(PipeSet, SpawnPoint.position, PipeSet.transform.rotation);
    }
}
