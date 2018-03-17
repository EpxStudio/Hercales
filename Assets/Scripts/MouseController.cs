using UnityEngine;

public class MouseController : MonoBehaviour
{
	public static bool WaitingOnDialogue { get; private set; }

	public LayerMask mask;
	public Texture2D defaultCursor;
	public Texture2D defaultNoCursor;
	public Texture2D chatCursor;

	[HideInInspector]
	public Grabbable grabbed;

	private bool clickAction;

	private void Awake()
	{
		WaitingOnDialogue = false;
	}

	public void Update()
	{
		if (WaitingOnDialogue)
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

		if (grabbed != null && grabbed.isGrabbed)
		{
			Cursor.SetCursor(grabbed.defaultCursor, Vector2.zero, CursorMode.Auto);
			if (Input.GetMouseButtonDown(0))
			{
				grabbed.OnClick();
			}
			return;
		}

		Vector3 point = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
		point = new Vector3(point.x, point.y, 0);

		Texture2D cursor = defaultCursor;
		if (point.y <= transform.position.y)
			cursor = defaultNoCursor;

		Collider2D[] colls = Physics2D.OverlapPointAll(point, mask, 10);
		clickAction = false;
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
					{
						clickAction = m.OnClick() || clickAction;
					}
				}
			}
		}
		Cursor.SetCursor(cursor, Vector2.zero, CursorMode.Auto);

		if (Input.GetMouseButtonDown(0) && !clickAction)
		{
			Arc.Apex(this.GetComponent<Rigidbody2D>(), Camera.main.ScreenToWorldPoint(Input.mousePosition));
		}
	}

	public void OpenDialogue()
	{
		WaitingOnDialogue = true;
		Time.timeScale = 0;
	}
}
