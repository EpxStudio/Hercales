using UnityEngine;
using UnityEngine.SceneManagement;

public class Destination : MonoBehaviour
{
	public string levelName;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		Invoke("EnterLevel", 0.75f);
	}

	private void EnterLevel()
	{
		SceneManager.LoadScene(levelName);
	}
}