using UnityEngine;

public class PlayerGrab : MonoBehaviour
{
	public MouseController mouse;

	void OnTriggerEnter2D(Collider2D inRange)
	{
		Grabbable g = inRange.GetComponent<Grabbable>();
		if (g != null)
		{
			mouse.grabbed = g;
			g.isGrabbable = true;
		}
	}

	void OnTriggerExit2D(Collider2D inRange)
	{
		Grabbable g = inRange.GetComponent<Grabbable>();
		if (g != null)
		{
			if (mouse.grabbed == g)
				mouse.grabbed = null;
			g.isGrabbable = false;
		}
	}
}
