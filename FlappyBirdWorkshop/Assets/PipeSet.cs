using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSet : MonoBehaviour {

    public GameObject Pipes;
    public Transform SpawnPoint1;
    public Transform SpawnPoint2;

	// Use this for initialization
	void Start () {

        float point = Random.Range(SpawnPoint2.transform.position.y, SpawnPoint1.transform.position.y);
        Pipes.transform.position = new Vector2(Pipes.transform.position.x, point);
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
