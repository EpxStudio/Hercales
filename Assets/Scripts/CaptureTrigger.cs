using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;


public class CaptureTrigger : MonoBehaviour {
    void OnTriggerEnter2D (Collider2D other) {
        Debug.Log("Trigger");
        if (other.name == "Bull") {
            Debug.Log("Bull captured");
        }

        if (other.name == "Player") {
            SceneManager.LoadScene("overworld");
        }
    }
}
