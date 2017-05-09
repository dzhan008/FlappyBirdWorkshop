using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {


    public float ForceAmount = 3f;
    private Vector2 Force;
    private int score = 0;
    private bool alive = true;

	// Use this for initialization
	void Start ()
    {
        Force = new Vector2(0, ForceAmount);
	}
	
	// Update is called once per frame
	void Update () {


        if(alive)
        {
            if (Input.GetButtonDown("Jump"))
            {
                this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                this.gameObject.GetComponent<Rigidbody2D>().AddForce(Force, ForceMode2D.Impulse);
            }
            else if (Input.GetButtonDown("Down"))
            {
                this.gameObject.transform.Translate(0, -0.5f, 0);
            }
        }

		
	}

    public void IncrementScore(int amount)
    {
        score += amount;
        Debug.Log(score);
    }

    public void EndGame()
    {
        alive = false;
        //End game, open some coroutine to pop up the menu
    }
}
