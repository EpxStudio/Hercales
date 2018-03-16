using UnityEngine;

public class MouseController : MonoBehaviour
{
	public LayerMask mask;

	public void Update()
	{
		bool isHovering = false;
		Collider2D[] colls = Physics2D.OverlapPointAll(Input.mousePosition, mask);
		foreach (Collider2D c in colls)
		{
			
		}

		if (!isHovering)
			Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
	}
}