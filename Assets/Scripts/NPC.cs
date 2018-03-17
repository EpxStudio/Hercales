using UnityEngine;

public class NPC : MonoBehaviour, IMouseClickable
{
	public string[] dialogueLines;
	public bool[] isPlayerSpeaking;

	public bool OnClick()
	{
		DialogueSystem.Speak(dialogueLines, isPlayerSpeaking);
        return true;
	}
}
