using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().EndGame();
            other.GetComponent<AudioSource>().PlayOneShot((AudioClip)Resources.Load("Audio/Smack Chicken"));

        }
    }

    void OnColliderEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("BIRDIE DOWN I REPEAT BIRDIE DOWN");
        }
    }
}
