using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour {

    public List<Sprite> Backgrounds;
    public GameObject Edge;

	// Use this for initialization
	void Start () {
        this.GetComponent<SpriteRenderer>().sprite = Backgrounds[Random.Range(0, Backgrounds.Count)];
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
