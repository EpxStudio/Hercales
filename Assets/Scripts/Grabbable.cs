using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabbable : MonoBehaviour
{
    private Rigidbody2D rb;
	void Start () {
        rb = this.GetComponent<Rigidbody2D>();
	}
	
	void Update () {
		if (Input.GetMouseButtonDown(1)) {
			Arc.Apex(rb, Camera.main.ScreenToWorldPoint(Input.mousePosition));
        }
	}
}
