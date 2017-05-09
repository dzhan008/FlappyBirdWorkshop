using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour {

    public float SpeedAmount = 5f;
    private Vector3 Speed;

    // Use this for initialization
    void Start () {
        Speed = new Vector2(SpeedAmount, 0);

    }
	
	// Update is called once per frame
	void Update () {
        this.transform.Translate(Speed);

    }
}
