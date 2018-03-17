using UnityEngine;
using UnityEngine.SceneManagement;

public class Destination : MonoBehaviour
{
	public static string LastLevel = "LastLevel";

	public string levelName;
	public Color finishedColor;
	public Transform finishedLocation;
	public Transform player;

	private void Awake()
	{
		if (PlayerPrefs.HasKey(levelName) && PlayerPrefs.GetInt(levelName) == 1)
			GetComponent<SpriteRenderer>().color = finishedColor;
		if (PlayerPrefs.HasKey(LastLevel) && PlayerPrefs.GetString(LastLevel) == levelName)
			player.position = finishedLocation.position;
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		Invoke("EnterLevel", 0.75f);
	}

	private void EnterLevel()
	{
		PlayerPrefs.SetString(LastLevel, levelName);
		SceneManager.LoadScene(levelName);
	}

	private void OnApplicationQuit()
	{
		if (PlayerPrefs.HasKey(LastLevel))
			PlayerPrefs.DeleteKey(LastLevel);
	}
}