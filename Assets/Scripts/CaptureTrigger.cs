using UnityEngine;
using UnityEngine.SceneManagement;


public class CaptureTrigger : MonoBehaviour {
	public GameObject[] captureObjs;
	private bool[] captured;

	private void Awake()
	{
		captured = new bool[captureObjs.Length];
	}

	void OnTriggerEnter2D (Collider2D other) {
        for(int i = 0; i < captureObjs.Length; i++)
		{
			if (captureObjs[i] == other.gameObject)
			{
				captured[i] = true;
				Debug.Log(other.name + " captured");
			}
		}
		bool finished = true;
		foreach (bool c in captured)
			finished = finished && c;
		if(finished)
		{
			Debug.Log("Level "+ SceneManager.GetActiveScene().name + " Complete!");
			PlayerPrefs.SetInt(SceneManager.GetActiveScene().name, 1);
		}

        if (other.name == "Player") {
            SceneManager.LoadScene("overworld");
        }
    }
}
