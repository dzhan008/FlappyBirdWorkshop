using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {


    public float ForceAmount = 3f;
    public Transform SpawnPoint;
    private Vector2 Force;
    private bool Alive = false;
    private AudioClip flap;

    public Sprite AliveSprite;
    public Sprite DeadSprite;

	// Use this for initialization
	void Start ()
    {
        Force = new Vector2(0, ForceAmount);
        flap = (AudioClip)Resources.Load("Audio/Flap");
	}
	
	// Update is called once per frame
	void Update () {


        if(Alive)
        {
            if (Input.GetButtonDown("Jump") || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began))
            {
                this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                this.gameObject.GetComponent<Rigidbody2D>().AddForce(Force, ForceMode2D.Impulse);
                this.gameObject.GetComponent<AudioSource>().PlayOneShot(flap);
            }
        }

		
	}

    public void Kill()
    {
        Alive = false;
        this.GetComponent<SpriteRenderer>().sprite = DeadSprite;
    }

    public void Reset()
    {
        Alive = true;
        gameObject.transform.position = SpawnPoint.position;
        GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
        this.GetComponent<SpriteRenderer>().sprite = AliveSprite;
    }

}
