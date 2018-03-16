using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGrab : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}

    void OnTriggerEnter2D (Collider2D inRange) {
        if (inRange.gameObject.layer != 9) {
            return;
        }
        
        inRange.gameObject.AddComponent(typeof(Grabbable));
    }

    void OnTriggerExit2D (Collider2D inRange) {
        if (inRange.gameObject.layer != 9) {
            return;
        }
        
        Destroy(inRange.gameObject.GetComponent<Grabbable>());
    }
}
