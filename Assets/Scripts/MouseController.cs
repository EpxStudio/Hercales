using UnityEngine;
using UnityEditor;

public class MouseController : MonoBehaviour
{
	public LayerMask mask;
	public Texture2D defaultCursor;

	public void Update()
	{
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
}