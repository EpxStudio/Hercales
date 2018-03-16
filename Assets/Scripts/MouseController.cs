using UnityEngine;

public class MouseController : MonoBehaviour
{
	public LayerMask mask;
	public Texture2D defaultCursor;

	public void Update()
	{
		Texture2D cursor = defaultCursor;
		Collider2D[] colls = Physics2D.OverlapPointAll(Camera.main.ScreenToWorldPoint(Input.mousePosition), mask, 10);
		foreach (Collider2D c in colls)
		{
			Debug.Log(c.name);
			CursorSetter s = c.GetComponent<CursorSetter>();
			if (s != null)
				cursor = s.myCursor;
		}
		Cursor.SetCursor(cursor, Vector2.zero, CursorMode.Auto);
	}
}