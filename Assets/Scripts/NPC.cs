using UnityEngine;

public class NPC : MonoBehaviour, IMouseClickable
{
	public void OnClick()
	{
		Debug.Log("hi");
	}
}