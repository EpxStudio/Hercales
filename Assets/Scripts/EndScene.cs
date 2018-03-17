using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScene : MonoBehaviour
{
	public string gotoScene;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.name == "Player")
			SceneManager.LoadScene(gotoScene);
	}
}