using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabbable : Arc {
    Rigidbody2D rb;
	// Use this for initialization
	void Start () {
        rb = this.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(1)) {
			this.Apex(rb, Camera.main.ScreenToWorldPoint(Input.mousePosition));
        }
	}
}
