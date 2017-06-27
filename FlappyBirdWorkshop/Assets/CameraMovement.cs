using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    public float SpeedAmount = 5f;
    public Transform SpawnPoint;
    private Vector3 Speed;
    private bool GameEnd = true;

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

    public void Move()
    {
        gameObject.transform.position = SpawnPoint.position;
        GameEnd = false;
    }

    public void Halt()
    {
        GameEnd = true;
    }
}
