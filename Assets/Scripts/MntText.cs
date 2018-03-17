using UnityEngine;

public class MntText : MonoBehaviour
{

	private void Start()
	{
		DialogueSystem.Speak(new string[] { "Time to climb Mt. Olympus and find Zues!" }, new bool[] { true });
	}
}