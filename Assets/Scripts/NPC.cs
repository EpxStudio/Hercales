using UnityEngine;

public class NPC : MonoBehaviour, IMouseClickable
{
	public string[] dialogueLines;
	public bool[] isPlayerSpeaking;

	public void OnClick()
	{
		DialogueSystem.Speak(dialogueLines, isPlayerSpeaking);
	}
}