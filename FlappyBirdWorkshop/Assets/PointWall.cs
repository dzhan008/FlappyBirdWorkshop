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
        if (other.tag == "Player")
        {
            other.gameObject.GetComponent<ScoreManager>().IncrementScore(1);
            other.gameObject.GetComponent<AudioSource>().PlayOneShot((AudioClip)Resources.Load("Audio/Point"));
        }
    }
}
