using UnityEngine;
using UnityEditor;

public class MouseController : MonoBehaviour
{
	public static bool WaitingOnDialogue { get; private set; }

	public LayerMask mask;
	public Texture2D defaultCursor;
	public Texture2D chatCursor;

	private void Awake()
	{
		WaitingOnDialogue = false;
	}

	public void Update()
	{
		if(WaitingOnDialogue)
		{
			Cursor.SetCursor(chatCursor, Vector2.zero, CursorMode.Auto);
			if (Input.GetMouseButtonDown(0))
			{
				WaitingOnDialogue = false;
				Time.timeScale = 1;
				DialogueSystem.NextClick();
			}
			return;
		}

		Texture2D cursor = defaultCursor;

		Vector3 point = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
		point = new Vector3(point.x, point.y, 0);

		Collider2D[] colls = Physics2D.OverlapPointAll(point, mask, 10);
		foreach (Collider2D c in colls)
		{
			CursorSetter s = c.GetComponent<CursorSetter>();
			if (s != null)
			{
				cursor = s.myCursor;
				if (Input.GetMouseButtonDown(0))
				{
					IMouseClickable m = s.GetComponent<IMouseClickable>();
					if (m != null)
						m.OnClick();
				}
			}
		}
		Cursor.SetCursor(cursor, Vector2.zero, CursorMode.Auto);
	}

	public void OpenDialogue()
	{
		WaitingOnDialogue = true;
		Time.timeScale = 0;
	}
}