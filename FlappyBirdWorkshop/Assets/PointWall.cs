using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointWall : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("FIX ME I DON'T WORK SOMETIMES");
        if (other.tag == "Player")
        {
            other.gameObject.GetComponent<Player>().IncrementScore(1);
        }
    }
}
