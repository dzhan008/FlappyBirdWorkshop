using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    public float SpeedAmount = 5f;
    private Vector3 Speed;
    private bool GameEnd = false;

    // Use this for initialization
    void Start () {
        Speed = new Vector2(SpeedAmount, 0);

    }
	
	// Update is called once per frame
	void Update () {
        if(!GameEnd)
        {
            this.transform.Translate(Speed);
        }


    }

    public void Halt()
    {
        GameEnd = true;
    }
}
