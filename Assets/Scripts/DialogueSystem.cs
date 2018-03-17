using UnityEngine;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour
{
	private static DialogueSystem me;
	public static void Speak(string[] s, bool[] p) { me.speak(s, p); }
	public static void NextClick() { me.nextClick(); }

	public MouseController mouse;

	public GameObject npcWindow;
	public GameObject playerWindow;

	public Text npcText;
	public Text playerText;

	private string[] chat;
	private bool[] isPlayerSpeaking;
	private int i;

	private void Awake()
	{
		me = this;
		npcWindow.SetActive(false);
		playerWindow.SetActive(false);
	}

	private void speak(string[] s, bool[] p)
	{
		chat = s;
		isPlayerSpeaking = p;
		i = 0;
		updateChat();
	}

	public void nextClick()
	{
		i++;
		if (i >= chat.Length)
		{
			npcWindow.SetActive(false);
			playerWindow.SetActive(false);
		}
		else
		{
			updateChat();
		}
	}

	private void updateChat()
	{
		npcText.text = chat[i];
		bool isPlayer = isPlayerSpeaking[i];
		npcWindow.SetActive(!isPlayer);
		playerWindow.SetActive(isPlayer);

		mouse.OpenDialogue();
	}
}